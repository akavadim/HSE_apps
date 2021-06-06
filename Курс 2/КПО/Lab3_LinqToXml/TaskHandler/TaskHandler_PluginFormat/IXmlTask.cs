using System;
using System.Xml.Linq;

namespace XmlTask
{
    public interface IXmlTask
    {
        string Name { get; }

        string Description { get; }

        string Result(XDocument document);
    }
}
