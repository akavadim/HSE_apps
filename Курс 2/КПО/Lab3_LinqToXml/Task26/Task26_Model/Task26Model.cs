using System;
using System.Xml.Linq;
using System.Linq;
using XmlTask;

namespace Task26_Model
{
    /// <summary>
    /// Задача: Для всех элементов документа удалить все их атрибуты, кроме первого.
    /// </summary>
    public class Task26Model:IXmlTask
    {
        public string Name { get; } = "Task26";
        public string Description { get; } = "Для всех элементов документа удалить все их атрибуты, кроме первого." +
            " Указание. В предикате метода Where, отбирающем все атрибуты элемента, кроме первого.";

        /// <summary>
        /// Для всех элементов документа удаляются все их атрибуты, кроме первого.
        /// </summary>
        /// <param name="xDocument">Документ XML</param>
        /// <returns>Статус выполнения</returns>
        public string Result(XDocument xDocument)
        {
            foreach(var element in xDocument.Descendants())
                element.Attributes()
                    .Where(atr => atr.PreviousAttribute != null)
                    .Remove();

            return "Для всех элементов документа удалены все их атрибуты, кроме первого.";
        }
    }
}
