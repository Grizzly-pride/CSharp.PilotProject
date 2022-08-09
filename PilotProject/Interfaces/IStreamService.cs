using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilotProject.Interfaces
{
    internal interface IStreamService<T>
    {
        void ReadFile(string path);
        void WriteFile(T other);
    }
}
