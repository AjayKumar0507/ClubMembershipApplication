using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldValidationAPI
{
    public static class CommonRegularExpressionValidationPatterns
    {
        public const string Email_Address_RegEx_Pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

        public const string IND_PhoneNumber_RegEx_Pattern = @"^[+]{1}(?:[0-9\-\(\)\/\.]\s?){6, 15}[0-9]{1}$";

        public const string IND_Post_Code_RegEx_Pattern = @"^[1-9]{1}[0-9]{2}\s{0,1}[0-9]{3}$";

        public const string Strong_Password_RegEx_Pattern = @"(?=^.{6,10}$)(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\s).*$";

    }
}