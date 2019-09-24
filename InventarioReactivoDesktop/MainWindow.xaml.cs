using InventarioReactivoDesktop.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace InventarioReactivoDesktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            //var x = new MainWindow2();
            //x.ShowDialog();

            //var x = new SearchContainerWindow();
            //x.Show();
            //this.Close();

        }


        private void ValidateLogin()
        {
            string username = tbUsername.Text;
            string password = tbPassword.Password;

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("The field Username is required", "Info", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            else if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("The field Password is required", "Info", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            using (var _context = new ApplicationDbContext())
            {
                var user = _context.RI_USERS.Where(x => x.Name == username && x.Password == password).FirstOrDefault();
                if (user == null)
                {
                    MessageBox.Show("User Invalid", "Info");
                }
                else
                {
                    new SearchContainerWindow().Show();
                    this.Close();
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ValidateLogin();
        }

        private void HandleEnterPressed(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) ValidateLogin();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tbUsername.Focus();
        }
    }
}
