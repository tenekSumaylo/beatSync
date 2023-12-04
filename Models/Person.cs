using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beatSync.Models
{
    public class Person : BaseModel
    {
        string firstName;
        string lastName;
        DateTime dateBirth;
        string userID;
        string password;
        string address;
        string email;
        int age;
        int personIndex;
        public Person() {
            DateBirth = DateTime.Now;
        }

        public Person( string firstname, string middlename, string lastname, int age, DateTime birth, string password, string address, string email )
        {
            FirstName = firstname;
            LastName = lastname;
            DateBirth = birth;
            UserID = userID;
            Password = password;
            Address = address;
            Email = email;
            Age = age;
        }

        public Person( Person person )
        {
            FirstName = person.FirstName;
            LastName = person.LastName;
            DateBirth = person.DateBirth;
            UserID = person.UserID;
            Password = person.Password;
            Address = person.Address;
            Email = person.Email;
            Age = person.Age;
        }

        public int PersonIndex
        {
            get => this.personIndex;
            set
            {
                this.personIndex = value;
                OnPropertyChanged(nameof(PersonIndex));
            }
        }

        public int Age
        {
            get => this.age;
            set
            {
                this.age = value;
                OnPropertyChanged(nameof(Age));
            }
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
                OnPropertyChanged(nameof(FirstName));
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
                OnPropertyChanged(nameof(LastName));    
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
                OnPropertyChanged(nameof(DateBirth));
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
                OnPropertyChanged(nameof(UserID));
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
                OnPropertyChanged(nameof(Password));
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
                OnPropertyChanged(nameof(Address));
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
                OnPropertyChanged(nameof(Email));
            }
        }

        public bool ClearFields()
        {
            FirstName = string.Empty; 
            LastName = string.Empty;
            UserID = string.Empty;
            Password = string.Empty;
            Address = string.Empty;
            Email = string.Empty;
            DateBirth = DateTime.Now;
            return true;
        }
        
    }
}
