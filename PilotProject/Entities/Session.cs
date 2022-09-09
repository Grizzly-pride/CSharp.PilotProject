using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using PilotProject.FoodMenu;
using PilotProject.Services;

namespace PilotProject.Entities
{
    enum SessionStatus
    {
        LogOut,
        LogIn
    }

    internal sealed class Session
    {
        private static readonly Session _Instance = new();
        public static Session Instance => _Instance;

        public User? CurrentUser { get; set; }

        [JsonPropertyName("session id")]
        public Guid SessionId { get; set; }

        [JsonPropertyName("session status")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public SessionStatus Status { get; set; }

        [JsonPropertyName("time status change")]
        [JsonConverter(typeof(DateTimeConverterService))]
        public DateTime Time { get; set; }

        //[JsonPropertyName("username")]
        //public string? UserName { get; set; }

        //[JsonPropertyName("email")]
        //public string? Email { get; set; }

        //[JsonIgnore]
        //public double BalanceUser { get; set; }

        //public string? GetUserName() => IsAuthorization() ? UserName : string.Empty;

        public string? GetUserName() => IsAuthorization() ? CurrentUser?.Name : new string("login");
        public string? GetUserBalance() => IsAuthorization() ? CurrentUser?.Balance.ToString() : new string("0");
        public bool IsAuthorization() => Status == SessionStatus.LogIn;
    }
}
