using System;
using System.Xml.Linq;
using XmlTask;

namespace Task38_Model
{
    /// <summary>
    /// Решает задачу 38
    /// </summary>
    public class Task38Model:IXmlTask
    {
        public string Name { get; } = "Task38";
        public string Description { get; } = " Для каждого элемента, кроме корня, изменить его имя, добавив к нему" +
            " слева исходные имена всех его предков, разделенные символом «-» (дефис)." +
            " Например, если корневой элемент имеет имя root, то элемент bb второго уровня," +
            " родительский элемент которого имеет имя aa, должен получить имя root-aa-bb.";

        /// <summary>
        /// Для каждого элемента, кроме корня, изменяет его имя, добавляя к нему слева исходные имена всех его предков, 
        /// разделенные символом «-» (дефис). 
        /// </summary>
        /// <param name="document">XDocument</param>
        /// <returns>Статус выполениня</returns>
        public string Result(XDocument document)
        {
            foreach (var descendant in document.Root.Descendants())
                descendant.Name = descendant.Parent.Name.LocalName + "-" + descendant.Name.LocalName;
            return "Для каждого элемента, кроме корня, изменено его имя," +
                " к нему слева добавлены исходные имена всех его предков, разделенные символом «-» (дефис).";
        }
    }
}
