﻿using System;
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
        string dateBirth;
        string userID;
        string password;
        string address;
        string email;

        public Person() {}

        public Person( string firstname, string middlename, string lastname, string age, string birth, string userID, string password, bool isAdmin, string address, string number, string email )
        {
            FirstName = firstname;
            LastName = lastname;
            DateBirth = birth;
            UserID = userID;
            Password = password;
            Address = address;
            Email = email;
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

        public string DateBirth
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
            DateBirth = string.Empty;
            return true;
        }
        
    }
}
