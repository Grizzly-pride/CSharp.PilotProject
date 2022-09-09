using PilotProject.FoodMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilotProject.Entities
{
    internal class OrderItem
    {
        public Product Product { get; private set; }
        public int CountItem { get; set; }
        public double PriceItem
        {
            get { return CountItem * Product.Price; }
        }


        public OrderItem(Product product, int count)
        {
            Product = product;
            CountItem = count;            
        }
    }
}
