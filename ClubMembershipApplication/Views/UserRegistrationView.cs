using ClubMembershipApplication.Data;
using ClubMembershipApplication.FieldValidators;

namespace ClubMembershipApplication
{
    public class userRegistrationView
    {
        
        #pragma warning restore CS8601 // Possible null reference assignment.
        IFieldValidator? fieldValidator = null;

        IRegister? register = null;

        public IFieldValidator? FieldValidator { get => fieldValidator; }

        public userRegistrationView(IRegister register, IFieldValidator fieldValidator)
        {
            this.fieldValidator = fieldValidator;
            this.register = register;
        }

        
        #pragma warning restore CS8601 // Possible null reference assignment.
        #pragma warning disable CS8601 // Possible null reference assignment.
        public void RunView()
        {
            fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.EmailAddress] = GetInputFromUser(FieldConstants.UserRegistrationField.EmailAddress, "Please enter your email address: ");
            fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.FirstName] = GetInputFromUser(FieldConstants.UserRegistrationField.FirstName, "Please enter your first name: ");
            fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.LastName] = GetInputFromUser(FieldConstants.UserRegistrationField.LastName, "Please enter your last name: ");
            fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.Password] = GetInputFromUser(FieldConstants.UserRegistrationField.Password, $"Please enter your password.{Environment.NewLine}(Your password must contain at least 1 small-case letter,{Environment.NewLine}1 Capital letter, 1 digit, 1 special character{Environment.NewLine} and the length should be between 6-10 characters): ");
            fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.PasswordCompare] = GetInputFromUser(FieldConstants.UserRegistrationField.PasswordCompare, "Please re-enter your password: ");
            fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.DateOfBirth] = GetInputFromUser(FieldConstants.UserRegistrationField.DateOfBirth, "Please enter your date of birth: ");
            fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.PhoneNumber] = GetInputFromUser(FieldConstants.UserRegistrationField.PhoneNumber, "Please enter your phone number: ");
            fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.AddressFirstLine] = GetInputFromUser(FieldConstants.UserRegistrationField.AddressFirstLine, "Please enter the first line of your address: ");
            fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.AddressSecondLine] = GetInputFromUser(FieldConstants.UserRegistrationField.AddressSecondLine, "Please enter the second line of your address: ");
            fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.AddressCity] = GetInputFromUser(FieldConstants.UserRegistrationField.AddressCity, "Please enter the city where you live: ");
            fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.PostCode] = GetInputFromUser(FieldConstants.UserRegistrationField.PostCode, "Please enter your post code: ");

        }

        private string? GetInputFromUser(FieldConstants.UserRegistrationField field, string promptText)
        {
            string? fieldVal = "";

            do
            {
                Console.WriteLine(promptText);
                fieldVal = Console.ReadLine();
            }
            while (!FieldValid(field, fieldVal));

            return fieldVal;
        }


        #pragma warning restore CS8601 // Possible null reference assignment.
        private bool FieldValid(FieldConstants.UserRegistrationField field, string? fieldValue)
        {
            if (fieldValidator.ValidatorDel((int)field, fieldValue, fieldValidator.FieldArray, out string invalidMessage))
            {
                CommonOutputFormat.ChangeFontColor(FontTheme.Danger);
                Console.WriteLine(invalidMessage);
                CommonOutputFormat.ChangeFontColor(FontTheme.Default);

                return false;
            }

            return true;
        }
    }
}