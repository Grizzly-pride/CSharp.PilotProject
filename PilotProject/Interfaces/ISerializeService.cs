using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilotProject.Interfaces
{
    internal interface ISerializeService<T1, T2>
    {
        string Serialize(T1 obj);
        T1 Deserialize(T2 jsonString);
    }
}