using System;
using System.Text;
using System.Xml.Linq;
using Task38_Model;

namespace Task38_View
{
    class Program
    {
        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            XDocument xDocument = XDocument.Load("text.xml");
            Task38Model model = new Task38Model();
            var res = model.Result(xDocument);
            Console.WriteLine(res);
            xDocument.Save("res.xml");
        }
    }
}
