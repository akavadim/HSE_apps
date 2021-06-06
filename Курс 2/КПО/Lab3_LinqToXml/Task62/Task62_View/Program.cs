using System;
using System.Xml.Linq;
using Task62_Model;
using System.Text;

namespace Task62_View
{
    class Program
    {
        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            XDocument document = XDocument.Load("text.xml");
            Task62Model task62 = new Task62Model();
            var res = task62.Result(document);
            Console.WriteLine(res);
            document.Save("res.xml");
        }
    }
}
