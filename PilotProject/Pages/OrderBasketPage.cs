using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PilotProject.FoodMenu;
using static PilotProject.Pages.PageItems;

namespace PilotProject.Pages
{
    internal class OrderBasketPage : BasePage
    {
        private bool _isShowTable = true;
        private int _productIndex;
        private Dictionary<Product, int> _products;
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

            if (_isShowTable)
            {
                switch (selectedItem)
                {
                    case -1: controller.TransitionToPage(Page.MyAccount); break;
                    default:
                        _isShowTable = false;
                        _productIndex = selectedItem;
                        Enter();
                        break;
                }
            }
            else
            {
                switch (selectedItem)
                {
                    //case 0: PageItems.RemoveFromCart(_products.ElementAt(_productIndex))
                }

            }



   
        }

        public override void Exit()
        {
            
        }

        public override void CreateWindow()
        {
            if (_isShowTable)
            {
                CreateTable();
            }
            else
            {
                moveTitle = 12;
                menu = new(2,11,false);
                menu.ItemsMenu = new()
                {
                    "Delete",
                    "Modify count"
                };
            }
        }

        private void CreateTable()
        {
            table = new(3);
            table.Headers = new string[] {"Product", "Count", "Price" };
            table.ColumnSizes = new int[] {-55, -5, -8 };

            moveTitle = 9;
            menu = new(2, 1, 3, 3, true);
            menu.ItemsMenu = new()
            {
                table.AddTopLine(),
                table.AddHeader(),
                table.AddMiddleLine()
            };

            _products = Account.OrderBasket.GetProducts();

            double totalPrice = 0;

            foreach (var product in _products)
            {
                if(product.Key is Pizza pizza)
                {
                    menu.ItemsMenu.Add(table.AddRow($"{pizza.Crust} crust pizza {pizza.Name} size {pizza.Size}cm.",product.Value, Math.Round(product.Value * pizza.Price, 2)));
                }
                else if(product.Key is Drink drink)
                {
                    menu.ItemsMenu.Add(table.AddRow($"Drink {drink.Name} valume {drink.Volume}l.", product.Value, Math.Round(product.Value * drink.Price, 2)));
                }
                totalPrice += Math.Round(product.Value * product.Key.Price);
            }
            
            menu.ItemsMenu.Add(table.AddCrossSmoothLine());
            menu.ItemsMenu.Add(table.AddTextLine($"Total: {totalPrice} $", 20));
            menu.ItemsMenu.Add(table.AddSmoothEndLine());           
        }
    }
}
