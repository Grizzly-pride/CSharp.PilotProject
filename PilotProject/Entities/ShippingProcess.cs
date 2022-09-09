using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilotProject.Entities
{
    internal sealed class ShippingProcess
    {
        public delegate Task LetterDeliverer(string address, Letter letter);
        public event LetterDeliverer? DelivMessage;

        public string UserEmail { get; set; } 

        public void Run()
        {
            Thread.Sleep(60000);
            DelivMessage?.Invoke(UserEmail, Letter.GetTemplateLatter(Template.OrderCompletion));

            Thread.Sleep(60000);
            DelivMessage?.Invoke(UserEmail, Letter.GetTemplateLatter(Template.OrderDelivered));

            //Thread.Sleep(60000);
            //DelivMessage?.Invoke(Session.GetStatic().Email, Letter.GetTemplateLatter(Template.OrderPaid));
        }
    }
}
