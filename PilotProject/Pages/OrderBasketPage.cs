using PilotProject.Entities;
using PilotProject.FoodMenu;


namespace PilotProject.Pages
{
    internal class OrderBasketPage : BasePage
    {
        private bool _isEmptyTable;

        private readonly OrderBasketRepository _orderBasket = new();
        public override string TitlePage => "ORDER BASKET";

        public OrderBasketPage(PageController controller) : base(controller)
        {
        }

        public override void Enter()
        {
            base.Enter();
            CreateWindow();
            UpdateMenu();
        }

        public override void UpdateMenu()
        {
            base.UpdateMenu();

            if (selectedItem == -1)
            {
                controller.TransitionToPage(Page.MyAccount);
            }
            else
            {
                if (!_isEmptyTable)
                {
                    PageItems.ModifyCart(_orderBasket.GetOrderItems()
                        .ElementAt(selectedItem), tablePosX + 70, selectedItem + tablePosY + 2);
                }
                Enter();
            }
        }

        public override void Exit() { }

        public override void CreateWindow()
        {
            CreateTable();
        }

        private void CreateTable()
        {
            table = new(3);
            table.Headers = new string[] {"Product", "Count", "Price" };
            table.ColumnSizes = new int[] {-50, -5, -8 };

            menu = new(tablePosX, tablePosY, 3, 3, true);
            menu.ItemsMenu = new()
            {
                table.AddTopLine(),
                table.AddHeader(),
                table.AddMiddleLine()
            };

            if (_orderBasket.GetOrderItems().Count != 0)
            {
                _isEmptyTable = false;

                foreach (var orderItem in _orderBasket.GetOrderItems())
                {
                    if (orderItem.Product is Pizza pizza)
                    {
                        menu.ItemsMenu.Add(table.AddRow
                            ($"{pizza.Crust} crust pizza {pizza.Name} size {pizza.Size}cm.",
                            orderItem.CountItem, string.Format("{0:0.0}",
                            orderItem.PriceItem)));
                    }
                    else if (orderItem.Product is Drink drink)
                    {
                        menu.ItemsMenu.Add(table.AddRow
                            ($"Drink {drink.Name} valume {drink.Volume}l.",
                            orderItem.CountItem,
                            string.Format("{0:0.0}", orderItem.PriceItem)));
                    }
                }
            }
            else
            {
                _isEmptyTable = true;
                menu.ItemsMenu.Add(table.AddRow(" ", " ", " "));
            }
            menu.ItemsMenu.Add(table.AddCrossSmoothLine());
            menu.ItemsMenu.Add(table.AddTextLine($"Total: {string.Format("{0:0.0}", _orderBasket.GetOrderItems().Sum(x => x.PriceItem))} $", moveRight: 20));
            menu.ItemsMenu.Add(table.AddSmoothEndLine());
        }
    }
}