using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Collections.Generic;
using XmlTask;

namespace Task14_Model
{
    //Логика для 14-й задачи
    public class Task14Model:IXmlTask
    { 

        public string Name { get; } = "Task14";

        public string Description { get; } = "Найти элементы второго уровня, имеющие дочерний текстовый узел," +
            " и вывести количество найденных элементов, а также имя каждого найденного элемента и значение его" +
            " дочернего текстового узла. Порядок вывода элементов должен соответствовать порядку их следования в документе.";

        //Результат для 14-й задачи
        public string Result(XDocument document)
        {
            var dictionaryRes = DictionaryResult(document);
            StringBuilder res = new StringBuilder();
            res.Append("Количество элементов: " + dictionaryRes.Count());
            foreach (var pair in dictionaryRes)
                res.Append($"\n\nName: { pair.Name}\nText:{pair.Text}");
            return res.ToString();
        }

        /// <summary>
        /// Результат в формате коллекции
        /// </summary>
        /// <param name="document">XmlDocument</param>
        /// <returns>Коллекция, где первый элемент - имя, а второе - текст</returns>
        public IEnumerable<(string Name, string Text)> DictionaryResult(XDocument document)
        {
            var res = document.Root.Elements()
                .SelectMany(nodeLvlOne => nodeLvlOne.Elements()
                .Where(nodeLvlTwo => nodeLvlTwo.FirstNode?.NodeType == System.Xml.XmlNodeType.Text)
                .Select(nodeLvlTwo => (nodeLvlTwo.Name.LocalName, nodeLvlTwo.Value))).ToArray();

            //var res = from nodeLvlOne in document.Root.Elements()
            //          from nodeLvlTwo in nodeLvlOne.Elements()
            //          where nodeLvlTwo.FirstNode?.NodeType == System.Xml.XmlNodeType.Text
            //          select (nodeLvlTwo.Name.LocalName, nodeLvlTwo.Value);
            return res;

        }
    }
}
