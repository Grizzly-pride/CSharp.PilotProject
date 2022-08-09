using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilotProject
{
    internal sealed class Client
    {       
        public string Name { get; private set; }
        public string Email { get; private set; }       
        public string Password { get; private set; }
        public string Phone { get; private set; }
        public Client(string name, string email, string password, string phone)
        {
            Name = name;
            Email = email;
            Phone = phone;
            Password = password;
        }
    }
}
