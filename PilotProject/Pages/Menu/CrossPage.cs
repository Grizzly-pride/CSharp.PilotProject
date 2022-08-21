using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilotProject.Pages.Menu
{
    internal class CrossPage : BasePage
    {
        public override string TitlePage => "Do you want to try again?";
        public CrossPage(PageController controller) : base(controller)
        {
            CreateWindow();
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
                case 0: controller.TransitionToPage(controller.PreviousPage); break;
                case 1: controller.TransitionToPage(Page.Main); break;
            }
        }

        public override void Exit()
        {
            base.Exit();
            menu.ResetSelectIndex();
        }

        public override void CreateWindow()
        {
            moveTitle = 5;
            menu = new(2, 13, false);
            menu.ItemsMenu = new()
            {
                "Yes",
                "No"
            };
        }
    }
}