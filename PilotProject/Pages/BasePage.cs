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
        protected MenuController controller;
        protected InputHandler inputHandler;
        protected string TitlePage { get; set; }

        public BasePage(MenuController controller)
        {
            this.controller = controller;
            inputHandler = new();
        }

        public virtual void Enter()
        {
            ResetColor();
        }

        public virtual void UpdateMenu()
        {
            do
            {
                WriteLine($"~-~-[{TitlePage}]-~-~\n");
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
            WriteLine($"~-~-[{TitlePage}]-~-~\n");
            ForegroundColor = ConsoleColor.Green;

        }

        public virtual void Exit()
        {
            inputHandler.ResetSelectIndex();
            Clear();
        }
    }
}
