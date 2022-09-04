using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PilotProject.FoodMenu;
using static System.Console;
using static PilotProject.Pages.PageItems;

namespace PilotProject.Pages
{
    internal class OrderBasketPage : BasePage
    {
        private bool _isShowTable = true;
        private bool _isEmptyTable;
        private int _productIndex;
        
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

            if (_isShowTable)
            {
                if(selectedItem == -1)
                {
                    controller.TransitionToPage(Page.MyAccount);
                }
                else
                {
                    if (!_isEmptyTable)
                    {
                        _isShowTable = false;
                        _productIndex = selectedItem;
                    }
                    Enter();
                }
            }
            else
            {
                var element = _orderBasket.GetProducts().ElementAt(_productIndex);
                Clear();
                switch (selectedItem)
                {
                    case 0: PageItems.RemoveFromCart(element.Key); break;
                    case 1: PageItems.ModifyCountInCart(element.Key, element.Value); break;
                }              
                _isShowTable = true;
                Enter();
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
                moveTitle = 11;
                menu = new(10,2,false);
                menu.ItemsMenu = new()
                {
                    "Delete",
                    "Modify count",
                    "Back"
                };
            }
        }

        private void CreateTable()
        {
            table = new(3);
            table.Headers = new string[] {"Product", "Count", "Price" };
            table.ColumnSizes = new int[] {-55, -5, -8 };

            moveTitle = 25;
            menu = new(1, 2, 3, 3, true);
            menu.ItemsMenu = new()
            {
                table.AddTopLine(),
                table.AddHeader(),
                table.AddMiddleLine()
            };


            double totalPrice = default;

            if (_orderBasket.GetProducts().Count != 0)
            {
                _isEmptyTable = false;

                foreach (var product in _orderBasket.GetProducts())
                {
                    double price = product.Value * product.Key.Price;
                    totalPrice += price;

                    if (product.Key is Pizza pizza)
                    {
                        menu.ItemsMenu.Add(table.AddRow($"{pizza.Crust} crust pizza {pizza.Name} size {pizza.Size}cm.", product.Value, string.Format("{0:0.0}", price)));
                    }
                    else if (product.Key is Drink drink)
                    {
                        menu.ItemsMenu.Add(table.AddRow($"Drink {drink.Name} valume {drink.Volume}l.", product.Value, string.Format("{0:0.0}", price)));
                    }
                }
            }
            else
            {
                _isEmptyTable = true;
                menu.ItemsMenu.Add(table.AddRow(" ", " ", " "));
            }
            menu.ItemsMenu.Add(table.AddCrossSmoothLine());
            menu.ItemsMenu.Add(table.AddTextLine($"Total: {string.Format("{0:0.0}",totalPrice)} $", 20));
            menu.ItemsMenu.Add(table.AddSmoothEndLine());           
        }
    }
}
