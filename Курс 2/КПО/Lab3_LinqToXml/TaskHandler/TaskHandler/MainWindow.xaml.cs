using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Xml.Linq;
using System.Reflection;
using Microsoft.Win32;
using XmlTask;

namespace TaskHandler
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const string PluginsPath = @"\plugins";


        private OpenFileDialog openFileDialog = new OpenFileDialog()
        {
            Filter = "Файл XML (*.xml)|*.xml|Текстовый файл (*.*)|*.*"
        };
        private SaveFileDialog saveFileDialog = new SaveFileDialog()
        {
            Filter = "Файл XML (*.xml)|*.xml"
        };
        private XDocument xmlDocument;
        private Dictionary<string, IXmlTask> keyXmlTasks = new Dictionary<string, IXmlTask>();


        public MainWindow()
        {
            InitializeComponent();

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            InitializePlugins();
        }


        public string ConsoleText { get => ConsoleTextBox.Text; set => ConsoleTextBox.Text = value; }
        public string XmlDocumentText { get => XmlDocumentTextBox.Text; set => XmlDocumentTextBox.Text = value; }
        public string DescriptionText { get => DescriptionTextBox.Text; set => DescriptionTextBox.Text = value; }

        private XDocument XmlDocument {
            get => xmlDocument;
            set
            {
                if (xmlDocument != null)
                    xmlDocument.Changed -= XmlDocument_Changed;
                if(value!=null)
                    XmlDocumentText=
                XmlDocumentText = value != null ? ((value.Declaration != null ? value.Declaration.ToString() + "\n" : "") + value.ToString()) : "";
                value.Changed += XmlDocument_Changed;
                xmlDocument = value;
            }
        }


        private void XmlDocument_Changed(object sender, XObjectChangeEventArgs e)
        {
            XmlDocumentText = xmlDocument.Declaration.ToString() + "\n" + xmlDocument.ToString();
        }
        private void TasksComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DescriptionText = ((IXmlTask)keyXmlTasks[TasksComboBox.SelectedItem.ToString()]).Description;
            ConsoleText = "";
        }

        private void OpenFileBtn_Click(object sender, RoutedEventArgs e)
        {
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    XmlDocument = XDocument.Load(openFileDialog.FileName);
                }
                catch
                {
                    ConsoleText = "Фходной файл имеет неправильный формат";
                }
            }
        }
        private void SaveFileBtn_Click(object sender, RoutedEventArgs e)
        {
            if (xmlDocument == null)
            {
                ConsoleText = "Сохранение невозможно. XML Документ пуст.";
                return;
            }
            if (saveFileDialog.ShowDialog() == true)
                xmlDocument.Save(saveFileDialog.FileName);
        }
        private void StartTaskBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = TasksComboBox.SelectedItem?.ToString();
            if (selectedItem == null)
            {
                ConsoleText = "Сначала выберите задачу, которую нужно запустить";
                return;
            }
            try
            {
                ConsoleText = ((IXmlTask)keyXmlTasks[selectedItem]).Result(xmlDocument);
            }
            catch(Exception ex)
            {
                ConsoleText = "Ошибка плагина: " + ex.Message;
            }
        }


        /// <summary>
        /// Инициализирует плагины из директории по умолчанию
        /// </summary>
        private void InitializePlugins()
        {
            keyXmlTasks.Clear();
            string filePath = Environment.CurrentDirectory + PluginsPath;
            if (!Directory.Exists(filePath))
            {
                ConsoleText = $"В папке {PluginsPath} не найдены плагины";
                Directory.CreateDirectory(filePath);
                return;
            }
            
            var plugins = PluginsFrom(filePath).OrderBy(plugin => plugin.Name);

            foreach (var plugin in plugins)
            {
                keyXmlTasks.Add(plugin.Name, plugin);
                TasksComboBox.Items.Add(plugin.Name);
            }
        }

        /// <summary>
        /// Загружает плагины из директории
        /// </summary>
        /// <param name="path">Директория с плагинами</param>
        /// <returns></returns>
        private IEnumerable<IXmlTask> PluginsFrom(string path)
        {
            var assemblies = from plugPath in Directory.GetFiles(path, "*.dll")
                             select Assembly.LoadFrom(plugPath);
            var res = from assembly in assemblies
                      from type in assembly.GetTypes()
                      where typeof(IXmlTask).IsAssignableFrom(type)
                      select (IXmlTask)Activator.CreateInstance(type);

            return res.ToArray();
        }

    }
}
