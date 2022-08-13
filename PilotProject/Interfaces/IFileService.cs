using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilotProject.Interfaces
{
    internal interface IFileService<T1, T2>
    {
        string ReadFile(T1 fileName);
        void WriteFile(T1 fileName, T2 jsonString);
    }
}
