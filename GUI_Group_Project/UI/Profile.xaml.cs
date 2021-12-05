using GUI_Group_Project.Database;
using GUI_Group_Project.Models;
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
    }
}
