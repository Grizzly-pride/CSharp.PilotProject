using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PilotProject.DBContext;
using PilotProject.FoodMenu;
using PilotProject.Services;

namespace PilotProject.Pages.Menu
{
    internal class DrinksPage : BasePage
    {
        
        public override string TitlePage => "DRINKS";

        public DrinksPage(PageController controller) : base(controller)
        {

        }

        public override void Enter()
        {
            TableBuilderService table = new();
            table.SetHeaders("Name", "Date", "Number");
            Console.ReadKey();
            UpdateMenu();
        }

        public override void UpdateMenu()
        {
            base.UpdateMenu();

        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}
