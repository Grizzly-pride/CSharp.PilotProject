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
        private static Session _Instance = new();

        [JsonPropertyName("session id")]
        public Guid SessionId { get; set; }

        [JsonPropertyName("session status")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public SessionStatus Status { get; set; }

        [JsonPropertyName("time status change")]
        [JsonConverter(typeof(DateTimeConverterService))]
        public DateTime Time { get; set; }

        [JsonPropertyName("username")]
        public string? UserName { get; set; }

        [JsonPropertyName("email")]
        public string? Email { get; set; }

        public static Session GetStatic() => _Instance;
        public string? GetUserName() => IsAuthorization() ? UserName : string.Empty;
        public bool IsAuthorization() => Status == SessionStatus.LogIn;
    }
}
