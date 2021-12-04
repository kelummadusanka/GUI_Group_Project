using MaterialDesignThemes.Wpf.Transitions;
using System.Windows;
using System.Windows.Controls;

namespace GUI_Group_Project
{
    /// <summary>
    /// Interaction logic for PersonalInfo.xaml
    /// </summary>
    public partial class PersonalInfo : UserControl
    {


        public static PersonalInfo Current; 
        public PersonalInfo()
        {
            this.InitializeComponent();
            Current = this;
        }

        private void PersonalInfoNextBtn_Click(object sender, RoutedEventArgs e)
        {
           


        }

        public string FirstName()
        {
            return FirstNameText.Text.Trim().ToLower();
        }

        public string LastName()
        {
            return LastNameText.Text.Trim().ToLower();
        }
        public string IDCardNo()
        {
            return IDCard.Text.Trim();
        }

        public string Birth()
        {
            return DOB.Text.Trim();
        }

       
    }
}
