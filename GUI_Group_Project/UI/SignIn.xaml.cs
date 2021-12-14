using GUI_Group_Project.Database;
using GUI_Group_Project.Models;
using GUI_Group_Project.UI;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace GUI_Group_Project
{
    public partial class SignIn : Window
    {
        public SignIn()
        {
            InitializeComponent();
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void SignupBtn_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();
            this.Close();

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

            using (DBContext context = new DBContext())
            {
               
                var custmer = context.Customers.FirstOrDefault(c => c.Username == UsernameTextBox.Text || c.Email == UsernameTextBox.Text || c.ID.ToString() == UsernameTextBox.Text);
                if (custmer != null)
                {
                    if (custmer.Password == LoginPasswordBox.Password)
                    {
                        Application.Current.Properties["ID"] = custmer.ID;
                        Application.Current.Properties["FirstName"] = custmer.FirstName;
                        MessageBox.Show("Login Successfull  " + custmer.FirstName);
                        Dashboard dashboard = new Dashboard();
                        
                        dashboard.Show();
                        this.Close();
                    }

                    else
                    {
                        MessageBox.Show("Invalid Password!");
                    }
                }

                else
                {
                    MessageBox.Show("Invalid Username or UserId!");
                }
            }
        }
    }
}
