using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PilotProject.Builders;
using PilotProject.DBContext;
using PilotProject.FoodMenu;
using static System.Console;



namespace PilotProject.Pages
{
    internal abstract class BasePage
    {
        protected int moveTitle;
        protected int selectedItem;
        protected string[] itemsForm;
        protected MenuBuilder menu;
        protected TableBuilder table;
        protected PageController controller;
        protected ApplicationContext dataBase;

        public abstract string TitlePage { get; }
        
        public BasePage(PageController controller)
        {
            this.controller = controller;
        }

        public virtual void Enter()
        {
            CursorVisible = false;
            ResetColor();
            Clear();
        }

        public virtual void UpdateMenu()
        {
            
            WriteLine($"{new String(' ', moveTitle)}~[{TitlePage}]~  user: {Account.UserName}\n");
            selectedItem = menu.RunMenu();
        }

        public virtual void UpdateForm()
        {           
            WriteLine($"{new String(' ', moveTitle)}~[{TitlePage}]~  user: {Account.UserName}\n");
            ForegroundColor = ConsoleColor.Green;
        }

        public virtual void CreateWindow()
        {

        }

        public virtual void Exit()
        {

        }

        /*
        private Page GetThisValuePageCollection()
        {
            return controller.PageCollection.FirstOrDefault(x => x.Value == this).Key;
        }
        */
    }
}
