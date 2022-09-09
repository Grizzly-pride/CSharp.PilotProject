using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilotProject.Interfaces
{
    internal interface ICheckDataService
    {
        bool IsValidName(string name);
        bool IsValidEmail(string email);
        bool IsValidPass(string pass);
        bool IsValidAddress(string address);
        bool IsUniqueNameInDB(string name);
    }
}
