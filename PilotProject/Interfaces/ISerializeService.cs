﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilotProject.Interfaces
{
    internal interface ISerializeService<T>
    {
        string Serialize(T obj);
        object Deserialize(string json);
    }
}
