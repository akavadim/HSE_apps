using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace Graphics_Editor
{
    public static class PluginManager
    {
        private static string _AutoMode = "Automode";

        public static string PluginPath => Environment.CurrentDirectory;
        public static string PluginFileName => "Plugins.txt";

        public static IEnumerable<Assembly> GetAssemblies()
        {
            List<Assembly> assemblies = new List<Assembly>();
            foreach (var file in GetPaths())
                assemblies.Add(Assembly.LoadFrom(file));
            return assemblies;
        }

        public static IEnumerable<string> GetPaths()
        {  
            var path= Path.Combine(PluginPath, PluginFileName);
            if (!File.Exists(Path.Combine(PluginPath, PluginFileName)))
            {
                using (var stream = File.CreateText(path))
                {
                    stream.Write(_AutoMode);
                }
            }

            var text = File.ReadAllText(path);
            var fileNames = text.Split('\n')?.Where(f => !string.IsNullOrWhiteSpace(f)).Select(f => f.Trim());
            if (fileNames.FirstOrDefault() ==_AutoMode)
                return Directory.GetFiles(PluginPath, "*.dll");

            List<string> files = new List<string>();
            foreach (var fileName in fileNames)
            {

                if (!fileName.EndsWith(".dll"))
                    throw new Exception($"{fileName} в {PluginFileName} не является *.dll");

                string filePath = Path.Combine(PluginPath, fileName);

                if (!File.Exists(filePath))
                    throw new Exception($"{filePath} не был найден");

                files.Add(filePath);
            }
            return files;
        }
    }
}
