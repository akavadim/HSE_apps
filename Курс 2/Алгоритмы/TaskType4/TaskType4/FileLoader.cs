using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TaskType4
{
    static class FileLoader
    {
        public static List<TaskItem> Getinput2()
        {
            return GetFile("input2.txt");
        }

        public static List<TaskItem> Getinput3()
        {
            return GetFile("input3.txt");
        }


        public static List<TaskItem> Getinput()
        {
           return GetFile("input.txt");
        }

        public static List<TaskItem> GetFile(string fileName)
        {
            string input = fileName;
            List<TaskItem> taskItems = new List<TaskItem>();
            using (StreamReader reader = new StreamReader(input))
            {
                while ((input = reader.ReadLine()) != null)
                    taskItems.Add(StrToTaskItem(input));
            }
            return taskItems;
        }

        public static TaskItem StrToTaskItem(string str)
        {
            var strs = str.Split(' ');
            TaskItem taskItem = new TaskItem(strs[0], int.Parse(strs[1]), int.Parse(strs[2]));
            return taskItem;
        }
    }
}
