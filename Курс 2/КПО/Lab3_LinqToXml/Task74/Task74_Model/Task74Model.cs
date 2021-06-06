using System;
using System.Linq;
using System.Xml.Linq;

namespace Task74_Model
{
    public class Task74Model
    {
        public string Result(XDocument document)
        {
            var origElements = document.Root.Elements().ToArray();
            var companies = (from elem in origElements
                             select elem.Attribute("station").Value.Split('_')[1]).Distinct().OrderBy(elem => elem).ToArray();
            var streets = (from elem in origElements
                           select elem.Attribute("station").Value.Split('_')[0]).Distinct().OrderBy(elem => elem).ToArray();
            var brands = (from elem in origElements
                          select elem.Name.LocalName).Distinct().OrderBy(elem => elem).ToArray();
            document.Root.RemoveNodes();

            foreach(var company in companies)
            {
                XElement companyElem = new XElement(company);
                foreach(var street in streets)
                {
                    XElement streetElem = new XElement(street);
                    foreach (var brand in brands)
                        streetElem.Add(new XAttribute(brand, "0"));
                    companyElem.Add(streetElem);
                }
                document.Root.Add(companyElem);
            }

            foreach(var elem in origElements)
            {
                var brand = elem.Name;
                var station = elem.Attribute("station").Value.Split("_");
                var company = station[1];
                var street = station[0];
                var price = elem.Attribute("price").Value;
                document.Root.Element(company).Element(street).Attribute(brand).SetValue(price);
            }

            return "Файл изменен в соответствии с заданием 74";
        }
    }
}
