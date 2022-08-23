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
    internal sealed class OrderBasketRepository: IOrderBasketRepository<Product, uint>
    {
        private static Dictionary<Product, uint> _products = new();
         
        public static string UserName { get; set; } = string.Empty;

        public static bool IsAuthorization() => !UserName.Equals(string.Empty);

        public void AddProduct(Product product, uint count = 1) 
        {
            if (_products.ContainsKey(product))
            {
                _products[product] += count;
            }
            else
            {
                _products.Add(product, count);
            }
        }

        public void DeleteProduct(Product product, uint count = 1) => _products.Remove(product);


        public Dictionary<Product, uint> GetProducts() => _products;    
  

        public void UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
