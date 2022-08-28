using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PilotProject.FoodMenu;

namespace PilotProject.Interfaces
{
    internal interface IOrderBasketRepository<Tk,Tv> where Tk : Product
    {
        Dictionary<Tk,Tv> GetProducts();
        void AddProduct(Tk product, Tv count);
        void DeleteProduct(Tk product);
        void ModifyCountProduct(Tk product, Tv count);
    }
}
