using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PilotProject.Services;
using static System.Console;


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
                case 1: controller.TransitionToPage(Page.OrderNow); break;
                case 2: _ = LeaveAccount(); controller.TransitionToPage(Page.Main); break; 
                case 3: controller.TransitionToPage(Page.Main); break;
            }
        }

        public override void Exit()
        {
            menu.ResetSelectIndex();
        }

        public override void CreateWindow()
        {
            moveTitle = 11;
            menu = new(10, 2, false);
            menu.ItemsMenu = new()
            {
                "Order basket",
                "Order now",
                "leave account",
                "Back"
            };
        }

        private async Task LeaveAccount()
        {
            Session.GetStatic().Time = DateTime.UtcNow.ToString("MM/dd/yyyy HH:mm:ss UTC");
            Session.GetStatic().Status = SessionStatus.LogOut.ToString();
            SerializerFileService fd = new();
            await fd.ObjectToJsonAsync(DataFile.Sessions, Session.GetStatic());

            PageItems.WriteText("You are leaving your account.", 11, 7, ConsoleColor.Blue);
            ReadKey();  
        }
    }
}
