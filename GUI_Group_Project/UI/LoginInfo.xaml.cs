using GUI_Group_Project;
using GUI_Group_Project.Database;
using GUI_Group_Project.Models;
using System;
//using System.Data.Linq;
using System.Windows;
using System.Windows.Controls;
namespace GUI_Group_Project
{
    /// <summary>
    /// Interaction logic for LoginInfo.xaml
    /// </summary>
    public partial class LoginInfo : UserControl
    {
        //CustomerViewModel.Instance CustomerViewModel.Instance = new CustomerViewModel.Instance();
        public LoginInfo()
        {
            InitializeComponent();

        }
        private void ToggleButton_Checked1(object sender, RoutedEventArgs e) => ShowPasswordFunction(PasswordTxtBox1, PasswordBox1);
        private void ToggleButton_UnChecked1(object sender, RoutedEventArgs e) => HidePasswordFunction(PasswordTxtBox1, PasswordBox1);
        private void ToggleButton_Checked2(object sender, RoutedEventArgs e) => ShowPasswordFunction(PasswordTxtBox2, PasswordBox2);
        private void ToggleButton_UnChecked2(object sender, RoutedEventArgs e) => HidePasswordFunction(PasswordTxtBox2, PasswordBox2);

        private void ShowPasswordFunction(TextBox textBox1,PasswordBox passwordbox1)
        {
            textBox1.Visibility = Visibility.Visible;
            passwordbox1.Visibility = Visibility.Hidden;
            textBox1.Text = passwordbox1.Password;
        }
        private void HidePasswordFunction(TextBox textBox1, PasswordBox passwordbox1)
        {
            textBox1.Visibility = Visibility.Hidden;
            passwordbox1.Visibility = Visibility.Visible;
            passwordbox1.Password = textBox1.Text;
        }

        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            PersonalInfo personalInfo = PersonalInfo.Current;
            ContactInfo contactInfo = ContactInfo.Current;
            DBContext Database = new DBContext();
            try
            {
                Customer newCustomer = new Customer()
                {

                    FirstName = personalInfo.FirstName(),
                    LastName = personalInfo.LastName(),
                    IDCard = personalInfo.IDCardNo(),
                    BirthDay = personalInfo.Birth(),

                    Address = contactInfo.Address(),
                    Street = contactInfo.Street(),
                    City = contactInfo.City(),
                    Zipcode = contactInfo.ZipCode(),
                    Email = contactInfo.Email(),
                    Mobile = contactInfo.Prefix()+contactInfo.Mobile(),

                    Username = UsernameText.Text,
                    ID = int.Parse(UserIDText.Text),
                    Password = PasswordBox1.Password,
                };
                Console.WriteLine("new customer username is "+ newCustomer.Username);
                Database.Customers.Add(newCustomer);
                Database.SaveChanges();
                var mywindow = Window.GetWindow(this);
                EmailSender.Emailsender(newCustomer.Email,newCustomer.Username, newCustomer.Password);
                MessageBox.Show("Successfully Registerd");
                mywindow.Hide();
                new SignIn().Show();

            }

            catch (Exception ex)
            {
                Console.WriteLine("Registration Failed!" + ex);
                MessageBox.Show(ex.Message, "Registration Failed!" );

                var mywindow = Window.GetWindow(this);
                mywindow.Close();
                SignIn mainWindow = new SignIn();
                mainWindow.Show();
            }


            

        }

    }

}
