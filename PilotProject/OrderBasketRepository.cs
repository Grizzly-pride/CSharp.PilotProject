using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PilotProject.FoodMenu;
using PilotProject.Interfaces;
using PilotProject.DBContext;

namespace PilotProject
{
    internal sealed class OrderBasketRepository: IOrderBasketRepository<Product>
    {
        public static string UserName { get; set; } = string.Empty;
        private static List<Pizza> Pizzas { get; set; } = new List<Pizza>();
        private static List<Drink> Drinks { get; set; } = new List<Drink>();


        public static bool IsAuthorization() => !UserName.Equals(string.Empty);

        public void AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProduct()
        {
            throw new NotImplementedException();
        }

        public Product GetProductByID(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
