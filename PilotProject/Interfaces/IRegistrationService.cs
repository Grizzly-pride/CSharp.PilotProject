using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilotProject.Interfaces
{
    internal interface IRegistrationService
    {
        bool IsValidName(string name);
        bool IsValidEmail(string email);
        bool IsValidPass(string pass);
        bool IsUniqueNameInDB(string name);
        bool IsUniqueEmailInDB(string email);
    }
}
