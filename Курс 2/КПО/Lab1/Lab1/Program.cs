using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab1
{
    class Program
    {
        const string Path = @"C:\Users\vadim\OneDrive\Рабочий стол\HSE\КПО\Lab1\Lab1\bin\Debug\input.txt";
        static void Main(string[] args)
        {
            try
            {

                ITree tree = new Tree();
                string input = GetInput(Path);
                IdentCreator identCreator = new IdentCreator(new SharpStringHandler());
                var idents = identCreator.GetIdentificators(input);
                tree.AddRange(idents);
            }
            catch(Exception e)
            {
                Console.WriteLine("Ошибка: " + e.Message);
            }
            

            //ITree tree = new Tree();

            //IParser parser = new Parser(_path);
            //string command;
            //while ((command = parser.GetNextCommand()) != null)
            //{
            //    IStringHandler stringHandler = new StringHandler(command);
            //    IIdentificator identificator = new Identificator(stringHandler);
            //    tree.Add(identificator);
            //}

            //Console.ReadKey();
        }

        static string GetInput(string path)
        {
            string input;

            using (StreamReader reader = new StreamReader(path))
            {
                input = reader.ReadToEnd();
            }
            return input;
        }
    }
}
