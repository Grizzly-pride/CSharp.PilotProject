using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using PilotProject.FoodMenu;
using PilotProject.Services;

namespace PilotProject.Entities
{
    internal class Order
    {
        [JsonPropertyName("order id")]
        public Guid Id { get; private set; }

        [JsonPropertyName("time")]
        [JsonConverter(typeof(DateTimeConverterService))]
        public DateTime Time { get; private set; }

        [JsonPropertyName("buyer name")]
        public string BuyerName { get; private set; }

        [JsonPropertyName("delivery address")]
        public string DeliveryAddress { get; private set; }

        [JsonPropertyName("total price")]
        public double TotalPrice { get; private set; }

        [JsonPropertyName("order list")]
        public List<OrderItem> OrderList { get; private set;}  

        public Order(List<OrderItem> orderList, string buyer, string address)
        {
            Id = Guid.NewGuid();
            Time = DateTime.UtcNow;
            BuyerName = buyer;
            DeliveryAddress = address;
            OrderList = orderList;
            TotalPrice = OrderList.Sum(x => x.PriceItem);
        }
    }
}
