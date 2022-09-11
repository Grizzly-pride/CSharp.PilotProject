using PilotProject.Interfaces;


namespace PilotProject.Entities
{
    internal sealed class OrderBasketRepository : IOrderBasketRepository<OrderItem>
    {
        private static readonly List<OrderItem> _orderList = new();

        public void AddOrderItem(OrderItem orderItem)
        {
            if (_orderList.Any(item => item.Product.Id.Equals(orderItem.Product.Id)))
            {               
                foreach (var item in _orderList)
                {
                    if(item.Product.Id == orderItem.Product.Id)
                    {
                        _orderList[_orderList.IndexOf(item)].CountItem += orderItem.CountItem;
                    }
                }
            }
            else
            {
                _orderList.Add(orderItem);
            }                         
        }

        public void DeleteOrderItem(OrderItem orderItem) => _orderList.Remove(orderItem);
        public List<OrderItem> GetOrderItems() => _orderList;
        public void ModifyCountOrderItem(OrderItem orderItem, int count) => _orderList[_orderList.IndexOf(orderItem)].CountItem = count;
    }
}