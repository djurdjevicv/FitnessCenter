using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProjekatPlatforme.Validations
{
    public class JmbgValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if(value.ToString().Length != 7)
            {
                return new ValidationResult(false, "Jmbg must have 7 digits!");
            }


            foreach (Users.Beginner beginner in Application.Instance.Beginners)
            {

                if (value.ToString() == (beginner.Jmbg).ToString())
                {
                    return new ValidationResult(false, "Enter jmbg already exists!");
                }
                else
                {
                    return new ValidationResult(true, "");
                }
            }

            foreach (Users.Coach co in Application.Instance.Coaches)
            {

                if (value.ToString() == (co.Jmbg).ToString())
                {
                    return new ValidationResult(false, "Enter jmbg already exists!");
                }
                else
                {
                    return new ValidationResult(true, "");
                }
                
            }

            foreach (Users.Administrator ad in Application.Instance.Administrators)
            {
                if (value.ToString() == (ad.Jmbg).ToString())
                {
                    return new ValidationResult(false, "Enter jmbg already exists!");
                }
                else
                {
                    return new ValidationResult(true, "");
                }
            }



            long jmbg = 0;
            try
            {
                jmbg = Convert.ToInt64(value);
            }
            catch
            {
                return new ValidationResult(false, "Jmbg must be number!");
            }



            if (value.ToString() != string.Empty)
            {
                return new ValidationResult(true, "");
            }
            else
            {
                return new ValidationResult(false, "Jmbg is required!");
            }

           



        }

    }
}
