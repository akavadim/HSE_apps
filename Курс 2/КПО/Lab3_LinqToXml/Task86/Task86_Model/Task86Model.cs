using System;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;

namespace Task86_Model
{
    public class Task86Model
    {
        public string Result(XDocument document)
        {
            var origElements = document.Root.Elements().ToArray();

            var newElements =
                from elemLvlOne in origElements
                group elemLvlOne by new { Name = elemLvlOne.Attribute("name").Value, Class = elemLvlOne.Attribute("class").Value } into gr
                orderby gr.Key.Name, gr.Key.Class
                select
                new XElement(gr.Key.Name.Trim().Replace(' ', '_'),
                    new XAttribute("class", gr.Key.Class),
                    from elemLvlOne in gr
                    from elemLvlTwo in elemLvlOne.Elements()
                    orderby elemLvlTwo.Attribute("mark").Value descending
                    orderby elemLvlTwo.Attribute("subject").Value
                    select
                    new XElement($"mark{elemLvlTwo.Attribute("mark").Value}",
                        new XAttribute("subject", elemLvlTwo.Attribute("subject").Value)));

            document.Root.RemoveNodes();
            document.Root.Add(newElements);
            return "Документ преобразован в соответствии с задачей 86";
        }
    }
}
