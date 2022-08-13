using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilotProject
{
    internal sealed class OrderBasket
    {
        public static string UserName { get; set; } = string.Empty;
        public static List<object> OrderList { get; set; } = new();

        public static bool IsAuthorization() => !UserName.Equals(string.Empty);

    }
}
