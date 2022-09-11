using PilotProject.Entities;
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

            
            if (Session.Instance.IsAuthorization() && menu.ItemsMenu.Contains("Authorization"))
            {
                int index = menu.ItemsMenu.FindIndex(i => i.Equals("Authorization"));
                menu.ItemsMenu[index] = "My Account";
            }
            else if(!Session.Instance.IsAuthorization() && menu.ItemsMenu.Contains("My Account"))
            {
                int index = menu.ItemsMenu.FindIndex(i => i.Equals("My Account"));
                menu.ItemsMenu[index] = "Authorization";
            }
            
            CursorVisible = false;
            UpdateMenu();
        }

        public override void UpdateMenu()
        {
            base.UpdateMenu();

            if (Session.Instance.IsAuthorization())
            {
                switch (selectedItem)
                {
                    case 0: controller.TransitionToPage(Page.MyAccount); break;
                    case 1: controller.TransitionToPage(Page.Pizzas); break;
                    case 2: controller.TransitionToPage(Page.Drinks); break;
                    case 3: PageItems.Gratitude(); Environment.Exit(0); break;
                }
            }
            else
            {
                switch (selectedItem)
                {
                    case 0: controller.TransitionToPage(Page.Authorization); break;
                    case 1: controller.TransitionToPage(Page.Pizzas); break;
                    case 2: controller.TransitionToPage(Page.Drinks); break;
                    case 3: PageItems.Gratitude(); Environment.Exit(0); break;
                }
            }
        }

        public override void Exit()
        {
            menu.ResetSelectIndex();
        }

        public override void CreateWindow()
        {
            menu = new(menuPosX, menuPosY, false);
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