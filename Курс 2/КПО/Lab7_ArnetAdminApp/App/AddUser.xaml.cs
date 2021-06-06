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
using System.Windows.Shapes;
using ArnetAdminApp.Data;

namespace ArnetAdminApp
{
    /// <summary>
    /// Логика взаимодействия для AddItem.xaml
    /// </summary>
    public partial class AddUser : Window
    {
        private LiteArnetModelContainer db;
        public AddUser(LiteArnetModelContainer db)
        {
            InitializeComponent();
            UserType.SelectedIndex = 0;
            this.db = db;
        }

        private void FirstName_TextChanged(object sender, TextChangedEventArgs e)
        {
            AddBtn.IsEnabled = !string.IsNullOrWhiteSpace(FirstName.Text);
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            User user = new User()
            {
                FirstName = FirstName.Text,
                MiddleName = MiddleName.Text,
                SecondName = SecondName.Text,
                Type = (UserTypes)UserType.SelectedIndex,
                DateFrom=DateTime.UtcNow
            };
            try
            {
                db.Users.Add(user);
                db.SaveChanges();
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }
    }
}
