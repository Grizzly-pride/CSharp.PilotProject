using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace PilotProject.Pages
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
            base.Enter();
            if (Account.IsAuthorization() && menu.ItemsMenu.Contains("Authorization"))
            {
                int index = menu.ItemsMenu.FindIndex(i => i.Equals("Authorization"));
                menu.ItemsMenu[index] = "My Account";
            }

            CursorVisible = false;
            UpdateMenu();
        }

        public override void UpdateMenu()
        {
            base.UpdateMenu();

            if (Account.IsAuthorization())
            {
                switch (selectedItem)
                {
                    case 0: controller.TransitionToPage(Page.MyAccount); break;
                    case 1: controller.TransitionToPage(Page.Pizzas); break;
                    case 2: controller.TransitionToPage(Page.Drinks); break;
                    case 3: Environment.Exit(0); break;
                }
            }
            else
            {
                switch (selectedItem)
                {
                    case 0: controller.TransitionToPage(Page.Authorization); break;
                    case 1: controller.TransitionToPage(Page.Drinks); break;
                    case 2: controller.TransitionToPage(Page.Pizzas); break;
                    case 3: Environment.Exit(0); break;
                }
            }
        }

        public override void Exit()
        {
            menu.ResetSelectIndex();
        }

        public override void CreateWindow()
        {
            moveTitle = 11;
            menu = new(2, 11, false);
            menu.ItemsMenu = new()
            {
                "Authorization",
                "Pizzas",
                "Drinks",
                "Exit"
            };
        }
    }
}
