namespace PilotProject.FoodMenu
{
    internal sealed class Drink : Product
    {
        public double Volume { get; set; }
        public override string Category { get; set; } = "Drink";

        public Drink(string name, string subcategory, double volume, double price) : base(name, subcategory, price)
        {
            Volume = volume;
        }
    }
}