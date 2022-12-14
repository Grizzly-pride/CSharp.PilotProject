using PilotProject.FoodMenu;


namespace PilotProject.Interfaces
{
    internal interface IFilterOrderItem<T1, T2> where T1 : Product
    {
        IEnumerable<T1> CategorySearch(T2 criterion);
    }
}
