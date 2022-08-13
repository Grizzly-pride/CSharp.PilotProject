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
        protected InputHandler inputHandler;
        protected string[] itemsForm;
        
        public abstract string TitlePage { get; }
        

        public BasePage(PageController controller)
        {
            this.controller = controller;
            inputHandler = new();
        }

        public virtual void Enter()
        {

        }

        public virtual void UpdateMenu()
        {
            do
            {
                WriteLine($"~-~-[{TitlePage}]-~-~ user: {OrderBasket.UserName}\n");
                inputHandler.SelectionControl();
                ResetColor();
                Clear();
            }
            while (!inputHandler.IsChose);

            selectedItem = inputHandler.GetSelectIndex();
        }

        public virtual void UpdateForm()
        {
            ResetColor();
            WriteLine($"~-~-[{TitlePage}]-~-~ user: {OrderBasket.UserName}\n");
            ForegroundColor = ConsoleColor.Green;
        }

        public virtual void Exit()
        {
            inputHandler.ResetSelectIndex();
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
