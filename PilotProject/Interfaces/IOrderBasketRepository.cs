using PilotProject.Entities;


namespace PilotProject.Interfaces
{
    internal interface IOrderBasketRepository<T1> where T1 : OrderItem
    {
        List<T1> GetOrderItems();
        void AddOrderItem(T1 orderItem);
        void DeleteOrderItem(T1 orderItem);
        void ModifyCountOrderItem(T1 orderItem, int count);
    }
}