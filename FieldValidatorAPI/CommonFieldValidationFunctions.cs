using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FieldValidationAPI
{
    public delegate bool RequiredValidDel(string fieldVal);
    public delegate bool StringLengthValidDel(string fieldVal, int min, int max);
    public delegate bool DateValidDel(string fieldVal, out DateTime validDateTime);
    public delegate bool PatternMatchValidDel(string fieldVal, string pattern);
    public delegate bool CompareFieldsValidDel(string fieldVal, string fieldValCompare);

    public class CommonFieldValidatorFunctions
    {
        private static RequiredValidDel? requiredValidDel = null;
        private static StringLengthValidDel? stringLengthValidDel = null;
        private static DateValidDel? dateValidDel = null;
        private static PatternMatchValidDel? patternMatchValidDel = null;
        private static CompareFieldsValidDel? compareFieldsValidDel = null;

        public static RequiredValidDel RequiredFieldValidDel
        {
            get
            {
                if (requiredValidDel == null)
                    requiredValidDel = RequiredFieldValid;
                return requiredValidDel;
            }
        }

        public static StringLengthValidDel StringLengthFieldValidDel
        {
            get
            {
                if (stringLengthValidDel == null)
                    stringLengthValidDel = new StringLengthValidDel(StringFieldLengthValid);
                return stringLengthValidDel;
            }
        }

        public static DateValidDel DateFieldValidDel
        {
            get
            {
                if (dateValidDel == null)
                    dateValidDel = new DateValidDel(DateFieldValid);
                return dateValidDel;
            }
        }


        public static PatternMatchValidDel PatternMatchFieldValidDel
        {
            get
            {
                if (patternMatchValidDel == null)
                    patternMatchValidDel = new PatternMatchValidDel(PatternMatchValid);
                return patternMatchValidDel;
            }
        }


        public static CompareFieldsValidDel FieldsCompareValidDel
        {
            get
            {
                if (compareFieldsValidDel == null)
                    compareFieldsValidDel = new CompareFieldsValidDel(CompareFieldsValid);
                return compareFieldsValidDel;
            }
        }


        private static bool RequiredFieldValid(string fieldVal)
        {
            if (!string.IsNullOrEmpty(fieldVal))
            {
                return true;
            }
            return false;
        }

        private static bool StringFieldLengthValid(string fieldVal, int min, int max)
        {
            if (fieldVal.Length >= min && fieldVal.Length <= max)
                return true;
            return false;
        }

        private static bool DateFieldValid(string dateTime, out DateTime validDateTime)
        {
            if (DateTime.TryParse(dateTime, out validDateTime))
                return true;
            return false;
        }

        private static bool PatternMatchValid(string fieldVal, string regularExpressionPattern)
        {
            Regex regex = new Regex(regularExpressionPattern);

            if (regex.IsMatch(fieldVal))
                return true;
            return false;
        }

        private static bool CompareFieldsValid(string fieldVal1, string fieldVal2)
        {
            if (fieldVal1.Equals(fieldVal2))
                return true;
            return false;
        }
    }
}