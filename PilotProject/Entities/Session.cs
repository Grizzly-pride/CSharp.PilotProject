using System.Text.Json.Serialization;
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

        [JsonPropertyName("session id")]
        public Guid SessionId { get; set; }


        [JsonConverter(typeof(JsonStringEnumConverter))]
        [JsonPropertyName("session status")]
        public SessionStatus Status { get; set; }


        [JsonConverter(typeof(DateTimeConverterService))]
        [JsonPropertyName("time status change")]
        public DateTime Time { get; set; }

        [JsonPropertyName("user")]
        public User? CurrentUser { get; set; }  

        public string? GetUserName() => IsAuthorization() ? CurrentUser?.Name : new string("login");
        public string? GetUserBalance() => IsAuthorization() ? string.Format("{0:0.0}", CurrentUser?.Balance) : new string("0");
        public bool IsAuthorization() => Status == SessionStatus.LogIn;

    }
}