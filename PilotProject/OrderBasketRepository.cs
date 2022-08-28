using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PilotProject.FoodMenu;
using PilotProject.Interfaces;
using PilotProject.DBContext;
using System.Collections.Specialized;

namespace PilotProject
{
    internal sealed class OrderBasketRepository: IOrderBasketRepository<Product, int>
    {
        private static Dictionary<Product, int> _products = new();

            
        public void AddProduct(Product product, int count)
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

        public void DeleteProduct(Product product) => _products.Remove(product);


        public Dictionary<Product, int> GetProducts() => _products;

        public void ModifyCountProduct(Product product, int count) => _products[product] = count;


    }
}
