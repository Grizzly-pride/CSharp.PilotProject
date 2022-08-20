using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PilotProject.DBContext;
using PilotProject.FoodMenu;
using PilotProject.Services;
using static System.Console;

namespace PilotProject.Pages.Menu
{
    internal class DrinksPage : BasePage
    {      
        public override string TitlePage => "DRINKS";

        public DrinksPage(PageController controller) : base(controller)
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
            //TODO
        }

        public override void Exit()
        {
            base.Exit();
            menu.ResetSelectIndex();
        }

        public override void CreateWindow()
        {
            ApplicationContext db = new();
            List<Drink> drink = db.Drinks.ToList();

            TableBuilder table = new(5);
            table.Headers = new string[] { "Id", "Name", "Value", "Price", "Category" };
            table.ColumnSizes = new int[] { -3, -18, -5, -5, -8 };

            moveTitle = 20;
            menu = new(2, 1, 3, 1);
            menu.ItemsMenu = new()
            {
                table.AddTopLine(),
                table.AddHeader(),
                table.AddMiddleLine()
            };

            for (int i = 0; i < drink.Count; i++)
            {
                menu.ItemsMenu.Add(table.AddRow(drink[i].Id, drink[i].Name, drink[i].Volume, drink[i].Price, drink[i].Category));

            }

            menu.ItemsMenu.Add(table.AddEndLine());
        }
    }
}
