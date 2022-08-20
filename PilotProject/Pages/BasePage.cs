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
        protected MenuBuilder menuBilder;
        protected string[] itemsForm;
        
        public abstract string TitlePage { get; }
        
        public BasePage(PageController controller)
        {
            this.controller = controller;
            menuBilder = new(2, 1);
        }

        public virtual void Enter()
        {

        }

        public virtual void UpdateMenu()
        {
            WriteLine($"~-~-[{TitlePage}]-~-~ user: {OrderBasket.UserName}\n");
            selectedItem = menuBilder.RunMenu();
        }

        public virtual void UpdateForm()
        {
            ResetColor();
            WriteLine($"~-~-[{TitlePage}]-~-~ user: {OrderBasket.UserName}\n");
            ForegroundColor = ConsoleColor.Green;
        }

        public virtual void Exit()
        {
            menuBilder.ResetSelectIndex();
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
