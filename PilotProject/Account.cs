using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilotProject
{
    internal static class Account
    {
        public static OrderBasketRepository OrderBasket { get; set; } = new();
        public static string UserName { get; set; } = string.Empty;

        public static bool IsAuthorization() => !UserName.Equals(string.Empty);
    }
}
