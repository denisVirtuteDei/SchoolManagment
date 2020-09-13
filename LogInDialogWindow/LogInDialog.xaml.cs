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

namespace SchoolTableCursed.LogInDialogWindow
{
    /// <summary>
    /// Логика взаимодействия для LogInDialog.xaml
    /// </summary>
    public partial class LogInDialog : Window
    {
        private const string login = "admin";
        private const string password = "admin";

        public LogInDialog()
        {
            InitializeComponent();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void Autorization_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckLoginPassword())
                MessageBox.Show("Incorrect login or password");
            else
                this.DialogResult = true;
        }

        private bool CheckLoginPassword()
        {
            if ((Login.Text ?? "").Equals(login) && (Password.Password ?? "").Equals(password))
                return true;
            return false;
        }
    }
}
