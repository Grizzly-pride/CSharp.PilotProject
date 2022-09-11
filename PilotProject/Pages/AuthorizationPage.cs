namespace PilotProject.Pages
{
    internal class AuthorizationPage : BasePage
    {
        public override string TitlePage => "AUTHORIZATION";

        public AuthorizationPage(PageController controller) : base(controller)
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
                case 0: controller.TransitionToPage(Page.LoginPage); break;
                case 1: controller.TransitionToPage(Page.Registration); break;
                case 2: controller.TransitionToPage(Page.Main); break;
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
                "Login",
                "Registration",
                "Back"
            };
        }
    }
}