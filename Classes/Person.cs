using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beatSync.Classes
{
    internal class Person
    {
        string firstName;
        string middleName;
        string lastName;
        int age;
        DateTime dateBirth;
        string gender;
        string userID;
        string password;
        bool isAdmin;
        string address;
        string number;
        string email;

        public Person( string firstname, string middlename, string lastname, int age, DateTime birth, string gender, string userID, string password, bool isAdmin, string address, string number, string email )
        {
            FirstName = firstname;
            MiddleName = middlename;
            LastName = lastname;
            Age = age;
            DateBirth = birth;
            Gender = gender;
            UserID = userID;
            Password = password;
            IsAdmin = isAdmin;
            Address = address;
            Number = number;
            Email = email;
        }

        public Person( Person person )
        {
            FirstName = person.FirstName;
            MiddleName = person.MiddleName; 
            LastName = person.LastName;
            Age = person.Age;
            DateBirth = person.DateBirth;
            Gender = person.Gender;
            UserID = person.UserID;
            Password = person.Password;
            IsAdmin = person.IsAdmin;
            Address = person.Address;
            Number = person.Number;
            Email = person.Email;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                this.firstName = value;
            }
        }

        public string MiddleName
        {
            get
            {
                return this.middleName;
            }
            set {
                this.middleName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                this.lastName = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                this.age = value;
            }
        }

        public DateTime DateBirth
        {
            get
            {
                return this.dateBirth;
            }
            set
            {
                this.dateBirth = value;
            }
        }

        public string Gender
        {
            get
            {
                return this.gender;
            }
            set
            {
                this.gender = value;
            }
        }

        public bool IsAdmin
        {
            get
            {
                return this.isAdmin;
            }
            set
            {
                this.isAdmin = value;
            }
        }

        public string UserID
        {
            get
            {
                return this.userID;
            }
            set
            {
                this.userID = value; 
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            }
            set
            {
                this.password = value;
            }
        }

        public string Address
        {
            get
            {
                return this.address;
            }
            set
            {
                this.address = value;
            }
        }

        public string Number
        {
            get
            {
                return this.number;
            }
            set
            {
                this.number = value;
            }
        }

        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                this.email = value;
            }
        }

        public string clearFields()
        {

            return "";
        }
    }
}
