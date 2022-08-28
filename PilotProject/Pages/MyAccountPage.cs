using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilotProject.Pages
{
    internal class MyAccountPage : BasePage
    {
        public override string TitlePage => "My Account";

        public MyAccountPage(PageController controller) : base(controller)
        {
            CreateWindow();
        }

        public override void Enter()
        {
            base.Enter();
            UpdateMenu();
        }

        public override void UpdateMenu()
        {
            base.UpdateMenu();

            switch (selectedItem)
            {
                case 0: controller.TransitionToPage(Page.OrderBasket); break;
                case 1: controller.TransitionToPage(Page.MakeOrder); break;
                case 2: controller.TransitionToPage(Page.Main); break;
            }
        }

        public override void Exit()
        {
            menu.ResetSelectIndex();
        }

        public override void CreateWindow()
        {
            moveTitle = 9;
            menu = new(2, 11, false);
            menu.ItemsMenu = new()
            {
                "Order basket",
                "Make an order",
                "Back"
            };
        }
    }
}
