using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProjekatPlatforme.Validations
{
    public class EmailValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");

            if (regex.IsMatch((string)value))
            {
                if(value.ToString() != string.Empty)
                {
                    return new ValidationResult(true, "");
                }
                
            }
            return new ValidationResult(false, "Email is in the wrong format!");

        }

    }
}
