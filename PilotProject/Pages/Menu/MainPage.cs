using PilotProject.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilotProject.Pages.Menu
{
    internal sealed class MainPage : BasePage
    {
        public MainPage(MenuController controller) : base(controller)
        {
            TitlePage = "MAIN MENU";
            inputHandler.ItemsMenu = new()
            {
                "Autentification",
                "Exit"
            };
        }

        public override void Enter()
        {
            Console.CursorVisible = false;
            UpdateMenu();
        }

        public override void UpdateMenu()
        {
            base.UpdateMenu();

            switch (selectedItem)
            {
                case 0:
                    controller.TransitionToPage(Page.Authentication);
                    break;
                case 1:
                    Environment.Exit(0);
                    break;
            }
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}
