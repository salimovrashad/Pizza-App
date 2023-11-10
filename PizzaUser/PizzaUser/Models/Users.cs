using PizzaUser.Exceptions;
using System.Text.RegularExpressions;

namespace PizzaUser.Models
{
    public class Users
    {
        private static string _name;
        private static string _surname;
        private static string _username;
        private static string _password;
        private static int _id;
        public int Id;
        public Users()
        {
            _id++;
            Id = _id;
        }

        public string Name { 
            get => _name; 
            set 
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 3 || value.Length > 16) throw new UserNameInvalid("Name length must be greater than 3 and less than 16!!!");
                else
                {
                    _name = value;
                }
            } 
        }

        public string Surname {
            get => _surname;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 3 || value.Length > 16) throw new UserSurnameInvalid("Surname length must be greater than 3 and less than 16!!!");
                else
                {
                    _surname = value;
                }
            }
        }

        public string Username
        {
            get => _username;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5 || value.Length > 12) throw new UserUsernameInvalid("Username length must be greater than 6 and less than 12!!!");
                else
                {
                    _username = value;
                }
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || !Regex.IsMatch(value, @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{6,16}$"))
                    throw new PasswordInvalid("Password must be 6-16 in length, contain at least 1 uppercase, 1 lowercase letter and at least 1 number.");
                else
                {
                    _password = value;
                }
            }
        }

        public bool isAdmin { get; set; }

        public override string ToString()
        {
            return $"{Id}. {Name} {Surname} Pass: {Password}";
        }
    }
}
