using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using PilotProject.FoodMenu;


namespace PilotProject
{
    enum SessionStatus
    {
        LogOut,
        LogIn
    }

    internal sealed class Session
    {
        private static Session _Instance = new();

        [JsonPropertyName("session id")]
        public Guid SessionId { get; set; }
        [JsonPropertyName("session status")]
        public string? Status { get; set; }
        [JsonPropertyName("time status change")]
        public string? Time { get; set; }
        [JsonPropertyName("username")]
        public string? UserName { get; set; }
        [JsonPropertyName("email")]
        public string? Email { get; set; }

        //-----------------test---------------------------------------------------
        //private Dictionary<Product, int> _saveOrder;
        //public List<KeyValuePair<Product, int>> SaveOrder
        //{
        //    get { return _saveOrder.ToList(); }
        //    set { _saveOrder = value.ToDictionary(x => x.Key, x => x.Value); }
        //}
        //------------------------------------------------------------------------

        public static Session GetStatic() => _Instance;

        public string? GetUserName() => IsAuthorization() ? UserName : string.Empty;

        public bool IsAuthorization() => Status == SessionStatus.LogIn.ToString();
    }
}
