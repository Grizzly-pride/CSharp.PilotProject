using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Text.RegularExpressions;
using PilotProject.Pages;

namespace PilotProject.Pages.Menu
{
    internal class AuthenticationPage : BasePage
    {
        public override string TitlePage => "AUTHENTICATION";

        public AuthenticationPage(PageController controller) : base(controller)
        {
            inputHandler.ItemsMenu = new()
            {
                "Login",
                "Registration",
                "Back"
            };
        }

        public override void Enter()
        {          
            UpdateMenu();
        }

        public override void UpdateMenu()
        {
            base.UpdateMenu();

            switch (selectedItem)
            {
                case 0:
                    controller.TransitionToPage(Page.LoginPage);
                    break;
                case 1:
                    controller.TransitionToPage(Page.Registration);
                    break;
                case 2:
                    controller.TransitionToPage(Page.Main);
                    break;
            }
        }

        public override void Exit()
        {
            base.Exit();
            
        } 
    }
}
