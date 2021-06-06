using System;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;

namespace Task62_Model
{
    public class Task62Model
    {

        /// <summary>
        /// Меняет дочернии элементы из
        /// [time year="2000" month="5" id="10"]PT5H13M[/time]
        /// в
        /// [id10 date="2000-05-01T00:00:00"]313[/id10] 
        /// и сортирует по id и по date
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        public string Result(XDocument document)
        {
            var newElements = (from elem in document.Root.Elements()
                               orderby (int)elem.Attribute("id"), (int)elem.Attribute("year"), (int)elem.Attribute("month")
                               select
                               new XElement("id" + elem.Attribute("id").Value,
                                 new XAttribute("date",
                                     new DateTime((int)elem.Attribute("year"), (int)elem.Attribute("month"), 1)),
                                 ((TimeSpan)elem).TotalMinutes))
                              .ToArray();
            document.Root.RemoveNodes();
            document.Root.Add(newElements);

            return "Элементы первого уровня изменены в другой формат в соответствии с задачей";
        }
    }
}
