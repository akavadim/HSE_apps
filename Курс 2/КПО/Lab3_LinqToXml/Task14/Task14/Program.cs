using System;
using Task14_Model;
using System.Xml.Linq;
using System.Text;

namespace Task14_View
{
    class Program
    {
        static void Main()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            XDocument xDocument = XDocument.Load("text.xml");
            Task14Model model = new Task14Model();
            var res = model.Result(xDocument);
            Console.WriteLine(res);
        }
    }
}
