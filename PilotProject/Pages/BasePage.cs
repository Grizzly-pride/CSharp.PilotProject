using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PilotProject.Builders;
using PilotProject.DBContext;
using PilotProject.FoodMenu;
using PilotProject.Entities;
using static System.Console;



namespace PilotProject.Pages
{
    internal abstract class BasePage
    {
        private readonly int _titlePosX;
        private readonly int _titlePosY;
        private readonly int _userDataPosX;
        private readonly int _userDataPosY;
        protected readonly int menuPosX;
        protected readonly int menuPosY;
        protected readonly int tablePosX;
        protected readonly int tablePosY;
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
            _titlePosX = 20;
            _titlePosY = 0;
            _userDataPosX = 41;
            _userDataPosY = 0;
            menuPosX = 18;
            menuPosY = 2;
            tablePosX = 1;
            tablePosY = 4;
        }

        public virtual void Enter()
        {
            CursorVisible = false;
            ResetColor();
            Clear();
        }

        public virtual void UpdateMenu()
        {           
            PageItems.WriteText($"~[{TitlePage}]~", _titlePosX, _titlePosY, ConsoleColor.White);
            PageItems.WriteText($"user: {Session.Instance.GetUserName()}", _userDataPosX, _userDataPosY, ConsoleColor.Magenta);
            PageItems.WriteText($"balance: {Session.Instance.GetUserBalance()}$", _userDataPosX, _userDataPosY + 1, ConsoleColor.Magenta);
            selectedItem = menu.RunMenu();
        }

        public virtual void UpdateForm()
        {
            PageItems.WriteText($"~[{TitlePage}]~", _titlePosX, _titlePosY, ConsoleColor.White);
            PageItems.WriteText($"user: {Session.Instance.GetUserName()}", _userDataPosX, _userDataPosY, ConsoleColor.Magenta);
            PageItems.WriteText($"balance: {Session.Instance.GetUserBalance()}$", _userDataPosX, _userDataPosY + 1, ConsoleColor.Magenta);
            ForegroundColor = ConsoleColor.Green;
        }

        public virtual void CreateWindow()
        {

        }

        public virtual void Exit()
        {

        }
    }
}