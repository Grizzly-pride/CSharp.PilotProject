﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PilotProject.Entities
{
    internal class User
    {
        [JsonIgnore]
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public double Balance { get; private set; } 

        public User(string name, string email, string password)
        {     
            Name = name;
            Email = email;
            Password = password;
        }       
    }
}