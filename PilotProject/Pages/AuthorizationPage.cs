using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Text.RegularExpressions;

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
            //moveTitle = 11;
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