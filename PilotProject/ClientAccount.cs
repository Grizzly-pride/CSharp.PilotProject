using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilotProject
{
    [Serializable]
    internal sealed class ClientAccount
    {       
        public string Name { get; private set; }
        public string Email { get; private set; }       
        public string Password { get; private set; }
        public ClientAccount(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;

        }
    }
}
