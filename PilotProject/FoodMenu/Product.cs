using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilotProject.FoodMenu
{
    internal class Product
    {       
        public int Id { get; private set; }
        public string Name { get; private set; }
        public double Price { get; private set; }
        public string Subcategory { get; private set; }
        public virtual string Category { get; set; }

        public Product(string name, string subcategory,double price)
        {
            Name = name;
            Price = price;
            Subcategory = subcategory;
        }
    }
}