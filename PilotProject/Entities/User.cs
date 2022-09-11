using PilotProject.DBContext;
using System.Text.Json.Serialization;


namespace PilotProject.Entities
{
    internal sealed class User
    {
        public event LetterDeliverer? Notyfication;

        [JsonIgnore]
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public double Balance { get; set; } 

        public User(string name, string email, string password)
        {     
            Name = name;
            Email = email;
            Password = password;
            Balance = 1000.0;
        }
        
        public async Task Pay(double sum)
        {
            if(Balance >= sum)
            {
                Balance -= sum;

                ApplicationContext dB = new();
                await dB.ChangeUserBalance(Balance, Id);

                                    
                await Notyfication?.Invoke(Email,
                    new Letter("Balance Notification", $"Order has been paid. Account balance:" +
                    $" {string.Format("{0:0.0}", Balance)}$"));
            }
            else
            {
                await Notyfication?.Invoke(Email,
                    new Letter("Balance Notification", $"Your account has insufficient funds! Account balance:" +
                    $" {string.Format("{0:0.0}", Balance)}$"));
            }
        }
    }
}