using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace beatSync.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public static bool CheckNumbers(string word) => Regex.IsMatch(word, @"^\d+$") ? true : false;
        protected static bool EmailCheck(string word) => new EmailAddressAttribute().IsValid(word);
        public void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public int getAccurateAge( DateTime birthday )
        {
            var today = DateTime.Today;
            int age = today.Year - birthday.Year;
            if (birthday.Day < today.Day && birthday.Month < today.Month)
                --age;
            return age;
            
        }

         static public int GetIDNumber( string user )
        {
            if (!user.Equals("NONE SELECTED"))
            {
                string[] result = user.Split('-');
                return Int32.Parse(result[1]);
            }
            return 0;
        }
    }
}

