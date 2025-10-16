using ClubMembershipApplication.Data;
using FieldValidationAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembershipApplication.FieldValidators
{
    #pragma warning restore CS8625
    #pragma warning disable CS8625
    public class UserRegistrationValidator : IFieldValidator
    {
        const int FirstName_Min_Length = 2;
        const int FirstName_Max_Length = 2;
        const int LastName_Min_Length = 2;
        const int LastName_Max_Length = 2;

        IRegister register;

        delegate bool EmailExistsDel(string emailAddress);

        FieldValidatorDel fieldValidatorDel = null;

        RequiredValidDel requiredValidDel = null;
        StringLengthValidDel stringLengthValidDel = null;
        DateValidDel dateValidDel = null;
        PatternMatchValidDel patternMatchValidDel = null;
        CompareFieldsValidDel compareFieldsValidDel = null;

        EmailExistsDel emailExistsDel = null;

        string[] fieldArray = null;

        public string[] FieldArray
        {
            get
            {
                if (fieldArray == null)
                {
                    fieldArray = new string[Enum.GetValues(typeof(FieldConstants.UserRegistrationField)).Length];
                }
                return fieldArray;
            }
        }


        public FieldValidatorDel ValidatorDel => fieldValidatorDel;
        //These are also accepted

        //public FieldValidatorDel ValidatorDel
        //{
        //    get
        //    {
        //        if (fieldValidatorDel == null)
        //            fieldValidatorDel = ValidField;
        //        return fieldValidatorDel;
        //    }

        //}

        //public FieldValidatorDel ValidatorDel => fieldValidatorDel = new FieldValidatorDel(ValidField);


        public UserRegistrationValidator(IRegister register)
        {
            this.register = register;
        }

        public void InitialiseValidatorDelegates()
        {
            fieldValidatorDel = new FieldValidatorDel(ValidField);
            emailExistsDel = new EmailExistsDel(register.EmailExists);

            requiredValidDel = CommonFieldValidatorFunctions.RequiredFieldValidDel;
            stringLengthValidDel = CommonFieldValidatorFunctions.StringLengthFieldValidDel;
            dateValidDel = CommonFieldValidatorFunctions.DateFieldValidDel;
            patternMatchValidDel = CommonFieldValidatorFunctions.PatternMatchFieldValidDel;
            compareFieldsValidDel = CommonFieldValidatorFunctions.FieldsCompareValidDel;
        }

        private bool ValidField(int fieldIndex, string fieldValue, string[] fieldArray, out string fieldInvalidMessage)
        {
            fieldInvalidMessage = null;
            FieldConstants.UserRegistrationField userRegistrationField = (FieldConstants.UserRegistrationField)fieldIndex;

            switch (userRegistrationField)
            {
                case FieldConstants.UserRegistrationField.EmailAddress:
                    fieldInvalidMessage = (!requiredValidDel(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)}{Environment.NewLine}" : "";
                    fieldInvalidMessage = (fieldInvalidMessage == "" && !patternMatchValidDel(fieldValue, CommonRegularExpressionValidationPatterns.Email_Address_RegEx_Pattern) ? $"You must enter a valid email address{Environment.NewLine}" : fieldInvalidMessage);
                    fieldInvalidMessage = (fieldInvalidMessage == "" && emailExistsDel(fieldValue) ? $"This email already exists! Let's Register." : fieldInvalidMessage);
                    break;
                case FieldConstants.UserRegistrationField.FirstName:
                    fieldInvalidMessage = (!requiredValidDel(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)}{Environment.NewLine}" : "";
                    fieldInvalidMessage = (fieldInvalidMessage == "" && stringLengthValidDel(fieldValue, FirstName_Min_Length, FirstName_Max_Length) ? $"{Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)} must be between {FirstName_Min_Length} and {FirstName_Max_Length}{Environment.NewLine}" : fieldInvalidMessage);
                    break;
                case FieldConstants.UserRegistrationField.LastName:
                    fieldInvalidMessage = (!requiredValidDel(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)}{Environment.NewLine}" : "";
                    fieldInvalidMessage = (fieldInvalidMessage == "" && stringLengthValidDel(fieldValue, LastName_Min_Length, LastName_Max_Length) ? $"{Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)} must be between {LastName_Min_Length} and {LastName_Max_Length}{Environment.NewLine}" : fieldInvalidMessage);
                    break;
                case FieldConstants.UserRegistrationField.Password:
                    fieldInvalidMessage = (!requiredValidDel(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)}{Environment.NewLine}" : "";
                    fieldInvalidMessage = (fieldInvalidMessage == "" && !patternMatchValidDel(fieldValue, CommonRegularExpressionValidationPatterns.Strong_Password_RegEx_Pattern) ? $"Your password must contain at least 1 small-case letter, 1 capital letter, 1 special character and the length should be between 6-10 characters.{Environment.NewLine}" : fieldInvalidMessage);
                    break;
                case FieldConstants.UserRegistrationField.PasswordCompare:
                    fieldInvalidMessage = (!requiredValidDel(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)}{Environment.NewLine}" : "";
                    fieldInvalidMessage = (fieldInvalidMessage == "" && !compareFieldsValidDel(fieldValue, FieldArray[(int)FieldConstants.UserRegistrationField.Password]) ? $"Your entry did not match password{Environment.NewLine}" : fieldInvalidMessage);
                    break;
                case FieldConstants.UserRegistrationField.DateOfBirth:
                    fieldInvalidMessage = (!requiredValidDel(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)}{Environment.NewLine}" : "";
                    fieldInvalidMessage = (fieldInvalidMessage == "" && !dateValidDel(fieldValue, out DateTime validDateTime) ? $"You did not enter a valid date{Environment.NewLine}" : fieldInvalidMessage);
                    break;
                case FieldConstants.UserRegistrationField.PhoneNumber:
                    fieldInvalidMessage = (!requiredValidDel(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)}{Environment.NewLine}" : "";
                    fieldInvalidMessage = (fieldInvalidMessage == "" !&& patternMatchValidDel(fieldValue, CommonRegularExpressionValidationPatterns.IND_PhoneNumber_RegEx_Pattern) ? $"You should enter a valid phone number{Environment.NewLine}" : fieldInvalidMessage);
                    break;
                case FieldConstants.UserRegistrationField.AddressFirstLine:
                    fieldInvalidMessage = (!requiredValidDel(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)}{Environment.NewLine}" : "";
                    break;
                case FieldConstants.UserRegistrationField.AddressSecondLine:
                    fieldInvalidMessage = (!requiredValidDel(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)}{Environment.NewLine}" : "";
                    break;
                case FieldConstants.UserRegistrationField.AddressCity:
                    fieldInvalidMessage = (!requiredValidDel(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)}{Environment.NewLine}" : "";
                    break;
                case FieldConstants.UserRegistrationField.PostCode:
                    fieldInvalidMessage = (!requiredValidDel(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)}{Environment.NewLine}" : "";
                    fieldInvalidMessage = (fieldInvalidMessage == "" && !patternMatchValidDel(fieldValue, CommonRegularExpressionValidationPatterns.IND_Post_Code_RegEx_Pattern) ? $"You did not enter a valid postal number{Environment.NewLine}" : fieldInvalidMessage);
                    break;
                default:
                    throw new ArgumentException("This field does not exist");
            }

            return fieldInvalidMessage == "";
        }
    }
}