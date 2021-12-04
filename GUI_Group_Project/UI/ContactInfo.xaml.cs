using GUI_Group_Project.ViewModel;
using System.Windows.Controls;

namespace GUI_Group_Project
{
    /// <summary>
    /// Interaction logic for ContactInfo.xaml
    /// </summary>
    public partial class ContactInfo : UserControl
    {
        public static ContactInfo Current;
        public ContactInfo()
        {
            this.InitializeComponent();
            Current = this;

        }
        public string Address()
        {
            return AddressText.Text;
        }

        public string Street()
        {
            return StreetText.Text;
        }
        public string City()
        {
            return CityText.Text;
        }

        public string ZipCode()
        {
            return ZipCodeText.Text;
        }

        public string Email()
        {
            return EmailText.Text;
        }

        public string Prefix()
        {
            return PrefixText.Text;
        }

        public string Mobile()
        {
            return MobileText.Text;
        }
    }
}

