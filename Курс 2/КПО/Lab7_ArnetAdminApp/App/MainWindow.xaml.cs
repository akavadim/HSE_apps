using System;
using System.Collections;
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

using ArnetAdminApp.Data;

namespace ArnetAdminApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private LiteArnetModelContainer db;

        public MainWindow()
        {
            InitializeComponent();
            this.db = new LiteArnetModelContainer();

            SelectedTable.SelectedIndex = 0;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            IEnumerable data = null;
            switch (SelectedTable.SelectedIndex)
            {
                //.Select(d=>new {d.Id, d.Type, d.FirstName, d.SecondName, d.MiddleName, d.DateFrom, d.DateTo})
                case 0: data = db.Users.Local; break;
                case 1: data = db.Agencies.Local.Select(d=>new { d.Id, d.Name, d.OwnerId, d.DateFrom, d.DateTo}); break;
                case 2: data = db.Agents.Local.Select(d=>new { d.Id, d.AgencyId, d.UserId, d.DateFrom, d.DateTo }); break;
                case 3: data = db.Bans.Local.Select(d=>new { d.Id, d.UserId, d.Comment, d.DateFrom, d.DateTo }); break;
                case 4: data = db.Phones.Local.Select(d=>new { d.Id, d.UserId, d.Number, d.DateFrom, d.DateTo }); break;
                case 5: data = db.Emails.Local.Select(d => new { d.Id, d.UserId, d.Value, d.DateFrom, d.DateTo }); break;
                case 6: data = db.Passwords.Local.Select(d => new { d.Id, d.UserId, d.Value, d.DateFrom, d.DateTo }); break;
            }
            dataGrid.ItemsSource = data;
        }
        private void UpdateDataGrid()
        {

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Window addWindow = null;
            if (SelectedTable.SelectedIndex == 0)
                addWindow = new AddUser(db);
            addWindow.Show();
            addWindow.Closed += AddWindow_Closed;
        }

        private void AddWindow_Closed(object sender, EventArgs e)
        {
            ///ComboBox_SelectionChanged(SelectedTable, new SelectionChangedEventArgs())
        }
    }
}
