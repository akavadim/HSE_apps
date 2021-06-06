using System;
using System.Xml.Linq;
using System.Text;
using Task86_Model;

namespace Task86_View
{
    class Program
    {
        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            XDocument document = XDocument.Load("text.xml");
            Task86Model task86 = new Task86Model();
            var res = task86.Result(document);
            document.Save("res.xml");
            Console.WriteLine(res);
        }
    }
}
