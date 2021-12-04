using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GUI_Group_Project
{
    public class PhoneNumberValidate : ValidationRule
    {

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var Phone_Number = 0;
            string charstrng = value as string;

            try
            {
                if (((string)value).Length > 0)
                    Phone_Number = int.Parse((string)value);
            }
            catch (Exception e)
            {
                return new ValidationResult(false, $"Illegal characters or " + e.Message);
            }

            if (charstrng.Length != 7)
            {
                return new ValidationResult(false, "Phone Number should have 7 digits");
            }
            return new ValidationResult(true, null);
        }
    }
}
