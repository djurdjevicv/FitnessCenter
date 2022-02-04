using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProjekatPlatforme.Validations
{
    public class StringValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            bool isIntStringFirstName = value.ToString().Any(char.IsDigit);

            if (value.ToString() != string.Empty && !isIntStringFirstName)
            {
                return new ValidationResult(true, "");
            }
            return new ValidationResult(false, "This feild is required, and mustn't had numbers!");

        }
    }
}
