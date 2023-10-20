using Image_Practice.DB;
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

namespace Image_Practice.MyPages
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            List<User> users = new List<User>(DB.Connection.FotoEntities.User.ToList());

            string login = LoginTb.Text;
            string password = PasswordPb.Password;

            User currentUser = users.FirstOrDefault(i => i.Login == login && i.Password == password);
            if (currentUser != null)
            {
                NavigationService.Navigate(new AddPage());
            }
            else
                MessageBox.Show("Неверный логин или пароль");
        }
    }
}
