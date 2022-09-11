namespace PilotProject.FoodMenu
{
    internal sealed class Pizza : Product
    {
        public double Size { get; set; }
        public string Crust { get; set; }
        public override string Category { get; set; } = "Pizza";

        public Pizza(string name, string subcategory, string crust, double size, double price) : base(name, subcategory, price)
        {    
            Size = size;
            Crust = crust;
        }
    }
}