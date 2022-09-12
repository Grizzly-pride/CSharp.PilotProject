namespace PilotProject.Entities
{
    delegate Task LetterDeliverer(string address, Letter letter);

    internal sealed class ShippingProcess
    {
        public event LetterDeliverer? DelivMessage;
        public string UserEmail { get; set; } 

        public void Run()
        {
            Thread.Sleep(30000);
            DelivMessage?.Invoke(UserEmail, Letter.GetTemplateLatter(Template.OrderCompletion));

            Thread.Sleep(30000);
            DelivMessage?.Invoke(UserEmail, Letter.GetTemplateLatter(Template.OrderDelivered));
        }
    }
}