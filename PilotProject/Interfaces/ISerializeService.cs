using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilotProject.Interfaces
{
    internal interface ISerializeService<T1, T2>
    {
        Task ObjectToJsonAsync(T1 file, T2 obj);
        Task<T2> JsonToObjectAsync(T1 file);
    }
}