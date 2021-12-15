using GUI_Group_Project.Database;
using GUI_Group_Project.Models;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace GUI_Group_Project.UI
{
    /// <summary>
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : UserControl
    {
        public Profile()
        {
            
            InitializeComponent();
            int id = int.Parse(Application.Current.Properties["ID"].ToString());
            
            using (DBContext context = new DBContext())
            {
                var custmer = context.Customers.FirstOrDefault(c => c.ID == id);
                if (custmer != null)
                {
                    Customer loggedCustomer = new Customer()
                    {

                        FirstName = custmer.FirstName,
                        LastName = custmer.LastName,
                        IDCard = custmer.IDCard,
                        BirthDay = custmer.BirthDay,

                        Address = custmer.Address,
                        Street = custmer.Street,
                        City = custmer.City,
                        Zipcode = custmer.Zipcode,
                        Email = custmer.Email,
                        Mobile = custmer.Mobile,

                        Username = custmer.Username,
                        ID = custmer.ID,
                        Password = custmer.Password,
                    };

                    this.DataContext = loggedCustomer;
                }

                else
                {
                    MessageBox.Show("Invalid Username or UserId!");
                }
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.TeleEdit.Text = "";
            this.EmailEdit.Text = "";
            this.ShipCodeEdit.Text = "";
            this.CityEdit.Text = "";
            this.StreetEdit.Text = "";
            this.AddressEdit.Text = "";
            this.IDCardEdit.Text = "";
            this.LastNameEdit.Text = "";
            this.FirstNameEdit.Text = "";

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            DBContext Database = new DBContext();
            try
            {
                Customer UpdateCustomer = new Customer()
                {

                    FirstName = this.FirstNameEdit.Text,
                    LastName = this.LastNameEdit.Text,
                    IDCard = this.TeleEdit.Text,
                    BirthDay = this.TeleEdit.Text,

                    Address = this.TeleEdit.Text,
                    Street = this.TeleEdit.Text,
                    City = this.TeleEdit.Text,
                    Zipcode = this.TeleEdit.Text,
                    Email = this.TeleEdit.Text,
                    Mobile = this.TeleEdit.Text,

                    Username = this.TeleEdit.Text,
                };
                Console.WriteLine("new customer username is " + UpdateCustomer.Username);
                Database.Customers.Add(UpdateCustomer);
                Database.SaveChanges();
                var mywindow = Window.GetWindow(this);
                EmailSender.Emailsender(UpdateCustomer.Email, UpdateCustomer.Username, UpdateCustomer.Password);
                MessageBox.Show("Successfully Registerd");
                mywindow.Hide();
                new SignIn().Show();

            }

            catch (Exception ex)
            {
                Console.WriteLine("Registration Failed!" + ex);
                MessageBox.Show(ex.Message, "Registration Failed!");

                var mywindow = Window.GetWindow(this);
                mywindow.Close();
                SignIn mainWindow = new SignIn();
                mainWindow.Show();
            }
        }
    }
}
