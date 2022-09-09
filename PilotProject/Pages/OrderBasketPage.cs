using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PilotProject.Entities;
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
                var element = _orderBasket.GetOrderItems().ElementAt(_productIndex);
                Clear();
                switch (selectedItem)
                {
                    case 0: PageItems.RemoveFromCart(element); break;
                    case 1: PageItems.ModifyCountInCart(element, element.CountItem); break;
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
                //moveTitle = 11;
                menu = new(menuPosX, menuPosY, false);
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

            //moveTitle = 25;
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
                        menu.ItemsMenu.Add(table.AddRow($"{pizza.Crust} crust pizza {pizza.Name} size {pizza.Size}cm.", orderItem.CountItem, string.Format("{0:0.0}", orderItem.PriceItem)));
                    }
                    else if (orderItem.Product is Drink drink)
                    {
                        menu.ItemsMenu.Add(table.AddRow($"Drink {drink.Name} valume {drink.Volume}l.", orderItem.CountItem, string.Format("{0:0.0}", orderItem.PriceItem)));
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
