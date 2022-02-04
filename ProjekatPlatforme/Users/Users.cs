using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatPlatforme.Users
{
    public abstract class Users
    {
        protected string _firstName;
        protected string _lastName;
        protected string _email;
        protected long _jmbg;
        protected string _password;
        protected int _IDAddress;
        protected EGender _gender;
        protected EUserType _userType;
        protected bool _active;

        protected Users(string firstName, string lastName, string email, long jmbg, string password, int IDAddress, EGender gender, EUserType userType)
        {
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _jmbg = jmbg;
            _password = password;
            _IDAddress = IDAddress;
            _gender = gender;
            _userType = userType;
            _active = true;
        }

        protected Users()
        {

        }

        public long Jmbg
        {
            get { return _jmbg; }
            set { _jmbg = value; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        public EGender Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }
        public EUserType UserType
        {
            get { return _userType; }
            set { _userType = value; }
        }
        public int IDAddress
        {
            get { return _IDAddress; }
            set { _IDAddress = value; }
        }

        public bool Active
        {
            get { return _active; }
            set { _active = value; }
        }
    }


}
