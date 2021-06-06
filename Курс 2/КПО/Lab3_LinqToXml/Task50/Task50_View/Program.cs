using System;
using System.Xml.Linq;
using System.Text;
using Task50_Model;

namespace Task50_View
{
    class Program
    {
        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            XDocument xDocument = XDocument.Load("text.xml");
            Task50Model task50 = new Task50Model();
            var res = task50.Result(xDocument);
            Console.WriteLine(res);
            xDocument.Save("res.xml");
        }
    }
}
