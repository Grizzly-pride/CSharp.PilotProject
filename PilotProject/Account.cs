using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilotProject
{
    enum SessionStatus
    {
        Login,
        LogOut
    }
    internal sealed class Account
    {
        public static OrderBasketRepository OrderBasket { get; set; } = new();
        public static string UserName { get; set; } = string.Empty;
        //public static string UserName { get; set; } = "Alexander";//for tests
        public static bool IsAuthorization() => !UserName.Equals(string.Empty);



        public SessionStatus Status { get; set; }
        public string Time { get; set; } = DateTime.UtcNow.ToString("MM/dd/yyyy HH:mm:ss UTC");
        public User ActivUser { get; set; }

        public Account(SessionStatus status)
        {
            Status = status;
        }
    }
}
