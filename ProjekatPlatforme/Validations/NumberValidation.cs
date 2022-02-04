using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProjekatPlatforme.Validations
{
    public class NumberValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            long nnumber = 0;
            try
            {
                nnumber = Convert.ToInt32(value);
            }
            catch
            {
                return new ValidationResult(false, "Number must be number!");
            }

            if (value.ToString() != string.Empty)
            {
                return new ValidationResult(true, "");
            }
            return new ValidationResult(false, "Number is required!");

        }
    }
}
