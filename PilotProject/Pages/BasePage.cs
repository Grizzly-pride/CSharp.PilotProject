using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;



namespace PilotProject.Pages
{
    internal abstract class BasePage
    {
        protected int selectedItem;
        protected PageController controller;
        protected MenuBuilder menu;
        protected string[] itemsForm;
        protected int moveTitle;

        public abstract string TitlePage { get; }
        
        public BasePage(PageController controller)
        {
            this.controller = controller;
        }

        public virtual void Enter()
        {
           
        }

        public virtual void UpdateMenu()
        {
            
            WriteLine($"{new String(' ', moveTitle)}~[{TitlePage}]~  user: {OrderBasket.UserName}\n");
            selectedItem = menu.RunMenu();
        }

        public virtual void UpdateForm()
        {           
            WriteLine($"{new String(' ', moveTitle)}~[{TitlePage}]~  user: {OrderBasket.UserName}\n");
            ForegroundColor = ConsoleColor.Green;
        }

        public virtual void CreateWindow()
        {

        }


        public virtual void Exit()
        {            
            CursorVisible = false;
            ResetColor();
            Clear();
        }

        /*
        private Page GetThisValuePageCollection()
        {
            return controller.PageCollection.FirstOrDefault(x => x.Value == this).Key;
        }
        */
    }
}
