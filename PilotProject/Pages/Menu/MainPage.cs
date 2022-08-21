using PilotProject.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace PilotProject.Pages.Menu
{
    internal sealed class MainPage : BasePage
    {
        public override string TitlePage => "MAIN MENU";       

        public MainPage(PageController controller) : base(controller)
        {
            CreateWindow();
        }

        public override void Enter()
        {           
            if (!menu.ItemsMenu[0].Equals("Order Basket") && OrderBasketRepository.IsAuthorization())
            {
                menu.ItemsMenu.Insert(0, "Order Basket");                              
            }

            CursorVisible = false;
            UpdateMenu();
        }

        public override void UpdateMenu()
        {
            base.UpdateMenu();

            if (OrderBasketRepository.IsAuthorization())
            {
                switch (selectedItem)
                {
                    case 0: controller.TransitionToPage(Page.OrderBasket); break;
                    case 1: controller.TransitionToPage(Page.Pizzas); break;
                    case 2: controller.TransitionToPage(Page.Drinks); break;
                    case 3: controller.TransitionToPage(Page.Authorization); break;
                    case 4: Environment.Exit(0); break;
                }
            }
            else
            {                               
                switch (selectedItem)
                {
                    case 0: controller.TransitionToPage(Page.Pizzas); break;
                    case 1: controller.TransitionToPage(Page.Drinks); break;
                    case 2: controller.TransitionToPage(Page.Authorization); break;
                    case 3: Environment.Exit(0); break;
                }                
            }
        }
       
        public override void Exit()
        {
            base.Exit();
            menu.ResetSelectIndex();
        }

        public override void CreateWindow()
        {
            moveTitle = 11;
            menu = new(2, 11, false);
            menu.ItemsMenu = new()
            {
                "Pizzas",
                "Drinks",
                "Authorization",
                "Exit"
            };           
        }
    }
}
