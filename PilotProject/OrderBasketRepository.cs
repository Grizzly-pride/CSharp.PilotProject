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
    internal sealed class OrderBasketRepository: IOrderBasketRepository<Product, int>
    {
        private static Dictionary<Product, int> _products = new();
         
        public void AddProduct(Product product, int count = 1) 
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

        public void DeleteProduct(Product product, int count = 1) => _products.Remove(product);


        public Dictionary<Product, int> GetProducts() => _products;    
  

        public void UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
