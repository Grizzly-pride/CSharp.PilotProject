using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilotProject.FoodMenu
{
    internal sealed class Pizza : Product
    {
        public double Size { get; set; }
        public override string Category { get; set; } = "Pizza";

        public Pizza(string name, string subcategory, double size, double price) : base(name, subcategory, price)
        {    
            Size = size;
        }
    }
}
