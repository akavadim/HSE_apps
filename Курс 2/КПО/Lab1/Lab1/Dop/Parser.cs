using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab1
{
    interface IParser
    {
        string File { get; }
        string GetNextCommand();
    }

    class Parser:IParser
    {
        private List<string> _commands;
        int _currentCommand;

        public string File { get; }
        
        public Parser(string File)
        {
            FileInfo file = new FileInfo(File);
            if (!file.Exists)
                throw new Exception("Файл не существует");
            this.File = File;
            _commands = GetAllComands();
        }

        public string GetNextCommand()
        {
            if (_currentCommand >= _commands.Count - 1)
                return null;

            _currentCommand++;
            return _commands[_currentCommand-1];
        }

        private List<string> GetAllComands()
        {
            List<string> res = new List<string>();
            string allText;
            using (StreamReader reader = new StreamReader(File))
            {
                allText = reader.ReadToEnd();
            }
            res = new List<string>(allText.Split(';'));
            for(int i=0; i<res.Count; i++)
            {
                res[i] = res[i].Replace("\n", "");
                res[i] = res[i].Replace("\r", "");
                res[i] = res[i].Replace("\t", "");
            }
            return res;
        }
    }
}
