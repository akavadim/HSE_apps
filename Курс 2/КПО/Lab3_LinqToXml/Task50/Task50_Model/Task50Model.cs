using System;
using System.Linq;
using System.Xml.Linq;
using XmlTask;

/// <summary>
/// Задание:
/// Дан XML-документ. С каждым элементом документа связывается некоторый промежуток времени (в днях, часах, минутах и секундах). 
/// Этот промежуток либо явно указывается в атрибуте time данного элемента (в формате, принятом в стандарте XML), 
/// либо, если данный атрибут отсутствует, считается равным одному дню. Добавить в начало набора дочерних узлов 
/// корневого элемента элемент totaltime со значением, равным суммарному значению промежутков времени, 
/// связанных со всеми элементами первого уровня.
/// </summary>
namespace Task50_Model
{
    public class Task50Model:IXmlTask
    {
        public string Name { get; } = "Task50";
        public string Description { get; } = " С каждым элементом документа связывается некоторый промежуток времени " +
            "(в днях, часах, минутах и секундах). Этот промежуток либо явно указывается в атрибуте time данного элемента " +
            "(в формате, принятом в стандарте XML), либо, если данный атрибут отсутствует, считается равным одному дню." +
            " Добавить в начало набора дочерних узлов корневого элемента элемент totaltime со значением, равным суммарному" +
            " значению промежутков времени, связанных со всеми элементами первого уровня.";

        public string Result(XDocument document)
        {
            var totalTime = GetTotalTimeCurrentLvl(document.Root);
            document.Root.AddFirst(
                new XElement("total-time", totalTime));
            return "В начала документа добавлен элемент с общим времени для объектов первого уровня";
        }

        /// <summary>
        /// Находит вреия для элементов в текущем ддокументе, но не опускается ниже, чем на 1 уровень
        /// Если время не указано, в качестве значения по умолчанию 1 день
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public TimeSpan GetTotalTimeCurrentLvl(XElement element)
        {
            TimeSpan totalTime = new TimeSpan();

            foreach (var child in element.Elements())
            {
                TimeSpan time = (TimeSpan?)child.Attribute("time") ?? new TimeSpan(1, 0, 0, 0);
                totalTime = totalTime.Add(time);
            }
            return totalTime;
        }
    }
}
