using System;
using System.Xml.Linq;
using System.Text;
using Task74_Model;

namespace Task74_View
{
    class Program
    {
        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            XDocument document = XDocument.Load("text.xml");
            Task74Model task74 = new Task74Model();
            var res = task74.Result(document);
            Console.WriteLine(res);
            document.Save("res.xml");
        }
    }
}
