using System;
using System.Text;
using System.Xml.Linq;
using Task26_Model;
using System.Linq;

namespace Task26_View
{
    class Program
    {
        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            XDocument xDocument = XDocument.Load("text.xml");
            Task26_Model.Task26Model model = new Task26Model();
            var res = model.Result(xDocument);
            Console.WriteLine(res);
            xDocument.Save("res.xml");
        }
    }
}
