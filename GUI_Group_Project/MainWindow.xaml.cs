using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace GUI_Group_Project
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void SignupBtn_Click(object sender, RoutedEventArgs e)
        {
            //RegisterWindow registerWindow = new RegisterWindow();
            //registerWindow.Show();
            //this.Hide();

        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e) => ShowPasswordFunction();
        private void ToggleButton_UnChecked(object sender, RoutedEventArgs e) => HidePasswordFunction();

        private void ShowPasswordFunction()
        {
            PasswordTxtBox.Visibility = Visibility.Visible;
            LoginPasswordBox.Visibility = Visibility.Hidden;
            PasswordTxtBox.Text = LoginPasswordBox.Password;
        }
        private void HidePasswordFunction()
        {
            PasswordTxtBox.Visibility = Visibility.Hidden;
            LoginPasswordBox.Visibility = Visibility.Visible;
            LoginPasswordBox.Password = PasswordTxtBox.Text;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LoginButton_Click_1(object sender, RoutedEventArgs e)
        {
            //using (CustomerContext context = new CustomerContext())
            //{
            //    var custmer = context.Customers.FirstOrDefault(c => c.Username == UsernameTextBox.Text || c.Email == UsernameTextBox.Text || c.ID.ToString() == UsernameTextBox.Text);
            //    if (custmer != null)
            //    {
            //        if (custmer.Password == LoginPasswordBox.Password)
            //        {
            //            Application.Current.Properties["custmer"] = custmer;
            //            MessageBox.Show("Login Successfull  " + custmer.FirstName);
            //            Profile profile = new Profile();
            //            profile.Show();
            //            this.Close();
            //        }

            //        else
            //        {
            //            MessageBox.Show("Invalid Password!");
            //        }
            //    }

            //    else
            //    {
            //        MessageBox.Show("Invalid Username or UserId!");
            //    }
            //}
        }
    }
}
