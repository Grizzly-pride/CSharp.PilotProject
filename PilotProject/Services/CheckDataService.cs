using PilotProject.Interfaces;
using System.Text.RegularExpressions;
using PilotProject.DBContext;


namespace PilotProject.Services
{
    internal sealed class CheckDataService : ICheckDataService
    {
        private ApplicationContext _db = new();
        public bool IsUniqueEmailInDB(string email)
        {
            var users = _db.Users.Where(x => x.Email.Equals(email)).ToList();
            return users.Count switch
            {
                0 => true,
                _ => false,
            };
        }

        public bool IsUniqueNameInDB(string name)
        {
            var users = _db.Users.Where(x => x.Name.Equals(name)).ToList();
            return users.Count switch
            {
                0 => true,
                _ => false,
            };
        }

        public bool IsValidAddress(string address)
        {
            string pattern = @"^(\w|\s)+\s\S+,\s+\d+\s+-\s+\d+$";
            if (Regex.IsMatch(address, pattern, RegexOptions.IgnoreCase))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsValidEmail(string email)
        {
            string pattern = "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}";
            Match isMatch = Regex.Match(email, pattern, RegexOptions.IgnoreCase);
            if (isMatch.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsValidName(string name)
        {
            if (name.Length.Equals(0))
            {
                return false;
            }

            char[] chars = name.ToCharArray();
            foreach (var c in chars)
            {
                if (!char.IsLetter(c))
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsValidPass(string pass)
        {
            return pass.Length switch
            {
                >= 7 => true,
                _ => false,
            };
        }
    }
}