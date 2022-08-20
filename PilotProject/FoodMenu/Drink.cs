using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilotProject.FoodMenu
{
    internal sealed class Drink : Product
    {
        public double Volume { get; set; }
        public override string Category { get; set; } = "Drink";

        public Drink(string name, string subcategory, double volume, double price) : base(name, subcategory, price)
        {
            Volume = volume;
        }
    }
}
