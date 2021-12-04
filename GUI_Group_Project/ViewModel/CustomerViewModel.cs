using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using GUI_Group_Project.Infrastructure;
using MvvmValidation;

namespace GUI_Group_Project.ViewModel
{
    public class CustomerViewModel : ValidatableViewModelBase
    {

        private string fristName;
        private string lastName;
        private string birthDay;
        private string iDCardNo;

        private string email;
        private string prefix;
        private string phoneNumber;
        private string address;
        private string street;
        private string city;
        private string zipCode;
        private string password;
        private string passwordConfirmation;
        private string userName;

        private bool? isValid;
        private string validationErrorsString;

        public CustomerViewModel()
        {

            ConfigureValidationRules();
            //Validator.ResultChanged += OnValidationResultChanged;
        }





        public string UserName
        {
            get {return userName; }
            set
            {
                userName = value;
                RaisePropertyChanged(nameof(UserName));
                Validator.Validate(nameof(UserName));
            }
        }

        public string FristName
        {
            get { return fristName; }
            set
            {
                fristName = value;
                RaisePropertyChanged(nameof(FristName));
                Validator.Validate(nameof(FristName));
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                RaisePropertyChanged(nameof(LastName));
                Validator.Validate(nameof(LastName));
            }
        }

        public string BirthDay
        {
            get { return birthDay; }
            set
            {
                birthDay = value;
                RaisePropertyChanged(nameof(BirthDay));
                Validator.Validate(nameof(BirthDay));
            }
        }

        public string IDCardNo
        {
            get { return iDCardNo; }
            set
            {
                iDCardNo = value;
                RaisePropertyChanged(nameof(IDCardNo));
                Validator.Validate(nameof(IDCardNo));
            }
        }


        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                RaisePropertyChanged(nameof(Email));
                Validator.Validate(nameof(Email));
            }
        }

        public string ZipCode
        {
            get { return zipCode; }
            set
            {
                zipCode = value;
                RaisePropertyChanged(nameof(ZipCode));
                Validator.Validate(nameof(ZipCode));
            }
        }
        public string Address
        {

            get { return address; }
            set
            {
                address = value;
                RaisePropertyChanged(nameof(Address));
                Validator.Validate(nameof(Address));
            }

        }

        public string City
        {
            get { return city; }
            set
            {
                city = value;
                RaisePropertyChanged(nameof(City));
                Validator.Validate(nameof(City));
            }
        }

        public string Street
        {
            get { return street; }
            set
            {
                street = value;
                RaisePropertyChanged(nameof(Street));
                Validator.Validate(nameof(Street));
            }
        }

        public string Prefix
        {
            get { return prefix; }
            set
            {
                phoneNumber = value;
                RaisePropertyChanged(nameof(Prefix));
                Validator.Validate(nameof(Prefix));
            }
        }

        public string PhoneNumber
        {
           get { return phoneNumber; }
            set
            {
                phoneNumber = prefix + value;
                RaisePropertyChanged(nameof(PhoneNumber));
                Validator.Validate(nameof(PhoneNumber));
            }
        }


        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                RaisePropertyChanged(nameof(Password));
                Validator.Validate(nameof(Password));
            }
        }

        public string PasswordConfirmation
        {
            get { return passwordConfirmation; }
            set
            {
                passwordConfirmation = value;
                RaisePropertyChanged(nameof(PasswordConfirmation));
                Validator.Validate(nameof(PasswordConfirmation));
            }
        }

        public string ValidationErrorsString
        {
            get { return validationErrorsString; }
            private set
            {
                validationErrorsString = value;
                RaisePropertyChanged(nameof(ValidationErrorsString));
            }
        }

        public bool? IsValid
        {
            get { return isValid; }
            private set
            {
                isValid = value;
                RaisePropertyChanged(nameof(IsValid));
            }
        }

        public void ConfigureValidationRules()
        {
            Validator.AddRequiredRule(() => UserName, "Username is required");

            Validator.AddRule(nameof(UserName),
                () => RuleResult.Assert(UserName.Length >= 5,
                    "Username must contain at least 5 characters"));


            Validator.AddRequiredRule(() => FristName, "First Name is required");

            Validator.AddRequiredRule(() => LastName, "Last Name is required");
            Validator.AddRequiredRule(() => BirthDay, "Date of Birth is required");
            Validator.AddRequiredRule(() => IDCardNo, "ID Card number is required");

            Validator.AddRequiredRule(() => Email, "Email is required");

            Validator.AddRule(nameof(Email),
                () =>
                {
                    const string regexPattern =
                        @"^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$";
                    return RuleResult.Assert(Regex.IsMatch(Email, regexPattern),
                        "Email must by a valid email address");
                });

            Validator.AddRequiredRule(() => PhoneNumber, "PhoneNumber is required");

            Validator.AddRule(nameof(PhoneNumber),
                () => RuleResult.Assert(PhoneNumber.Length ==7,
                    "Phone Number must contain 7 Digits"));


            Validator.AddRequiredRule(() => Address, "Address is required");

            Validator.AddRequiredRule(() => Street, "Street is required");

            Validator.AddRequiredRule(() => City, "City is required");
            Validator.AddRequiredRule(() => ZipCode, "Zip Code is required");

            Validator.AddRequiredRule(() => Password, "Password is required");

            Validator.AddRule(nameof(Password),
                () => RuleResult.Assert(Password.Length >= 6,
                    "Password must contain at least 6 characters"));

            Validator.AddRule(nameof(Password),
                () => RuleResult.Assert((!Password.All(char.IsLower) &&
                                         !Password.All(char.IsUpper) &&
                                         !Password.All(char.IsDigit)),
                    "Password must contain both lower case and upper case letters"));

            Validator.AddRule(nameof(Password),
                () => RuleResult.Assert(Password.Any(char.IsDigit),
                    "Password must contain at least one digit"));

            Validator.AddRule(nameof(PasswordConfirmation),
                () =>
                {
                    if (!string.IsNullOrEmpty(Password) && string.IsNullOrEmpty(PasswordConfirmation))
                    {
                        return RuleResult.Invalid("Please confirm password!");
                    }

                    return RuleResult.Valid();
                });

            Validator.AddRule(nameof(Password),
                nameof(PasswordConfirmation),
                () =>
                {
                    if (!string.IsNullOrEmpty(Password) && !string.IsNullOrEmpty(PasswordConfirmation))
                    {
                        return RuleResult.Assert(Password == PasswordConfirmation, "Passwords do not match");
                    }

                    return RuleResult.Valid();
                });

        }

        private async void Validate()
        {
            await ValidateAsync();
        }

        private async Task ValidateAsync()
        {
            var result = await Validator.ValidateAllAsync();

            UpdateValidationSummary(result);
        }

        private void OnValidationResultChanged(object sender, ValidationResultChangedEventArgs e)
        {
            if (!IsValid.GetValueOrDefault(true))
            {
                ValidationResult validationResult = Validator.GetResult();

                UpdateValidationSummary(validationResult);
            }
        }

        private void UpdateValidationSummary(ValidationResult validationResult)
        {
            IsValid = validationResult.IsValid;
            ValidationErrorsString = validationResult.ToString();
        }
    }
}