using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PilotProject.FoodMenu;

namespace PilotProject.Interfaces
{
    internal interface IFilterProduct<T1, T2> where T1 : Product
    {
        IEnumerable<T1> CategorySearch(T2 criterion);

    }
}
