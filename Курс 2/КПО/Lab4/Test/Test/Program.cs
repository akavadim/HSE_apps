using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Xsl;
using System.Xml.XPath;
using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var coll = new int[159].ToList();
            var rs = new List<IEnumerable<int>>();

            for (int i = 0; i < coll.Count / 50; i++)
                rs.Add(coll.GetRange(i * 50, 50));
            rs.Add(coll.GetRange(coll.Count - coll.Count % 50, coll.Count % 50));




            XDocument document = XDocument.Load("plan.xml");

            string text = "1. Выполнить XPath запросы" +
                "\n2. Выполнить xslt";

            Console.WriteLine(text);
            int response;
            while (!int.TryParse(Console.ReadLine(), out response) || response < 1 || response > 2) ;

            if (response == 1)
            {
                Console.WriteLine("Получить все занятия на данной неделе");
                var res = document.XPathSelectElements("//Day/Subjects/Subject/Name");
                foreach (var node in res)
                    Console.WriteLine(node.Value);

                Console.WriteLine("\nПолучить все аудитории, в которых проходят заняти");
                res = document.XPathSelectElements("//Day/Subjects/Subject/LectureHall");
                foreach (var node in res)
                    Console.Write(node.Value + " ");

                Console.WriteLine("\n\nНапишите номер аудитории (можно даже ту, в которой нет занятий)");

                while (!int.TryParse(Console.ReadLine(), out response)) ;

                Console.WriteLine("\nПолучить все практические занятия на неделе");
                res = document.XPathSelectElements("//Day/Subjects/Subject[Type='Seminar']/Name");
                foreach (var node in res)
                    Console.WriteLine(node.Value);

                Console.WriteLine($"\nПолучить все лекции, проводимые в указанной аудитории {response}");
                res = document.XPathSelectElements($"//Day/Subjects/Subject[LectureHall='{response}']/Name");
                foreach (var node in res)
                    Console.WriteLine(node.Value);

                Console.WriteLine($"\nПолучить список всех преподавателей, проводящих практики в указанной аудитории {response}");
                res = document.XPathSelectElements($"//Day/Subjects/Subject[LectureHall='{response}'][Type='Seminar']/Teacher");
                foreach (var node in res)
                    Console.WriteLine(node.Value);

                Console.WriteLine("\nПолучить последнее занятие для каждого дня делели");
                res = document.XPathSelectElements("//Day/Subjects/Subject[last()]/Name");
                foreach (var node in res)
                    Console.WriteLine(node.Value);

                Console.WriteLine("\nПолучить общее количество занятий за всю неделю.");

                var resCount = document.XPathEvaluate("count(//Day/Subjects/Subject)");
                Console.WriteLine(resCount);
            }
            else
            {
                XslTransform xslt = new XslTransform();
                xslt.Load("planTxt.xslt");
                xslt.Transform("plan.xml", "plan.txt");
                xslt.Load("planHtml.xslt");
                xslt.Transform("plan.xml", "plan.html");
                Console.WriteLine("Рядом с plan.xml созданы plan.txt и plan.html");
            }

        }
    }
}
