using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PilotProject.FoodMenu;

namespace PilotProject.Interfaces
{
    internal interface IOrderBasketRepository<T> where T : Product
    {
        List<T> GetProduct();
        T GetProductByID(int id);
        void AddProduct(T product);
        void DeleteProduct(T product);
        void UpdateProduct(T product);
    }
}
