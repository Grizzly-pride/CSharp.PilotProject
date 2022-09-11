using PilotProject.Builders;
using PilotProject.DBContext;
using PilotProject.Entities;
using static System.Console;


namespace PilotProject.Pages
{
    internal abstract class BasePage
    {
        private readonly int _logoPosX;
        private readonly int _logoPosY;
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
            _logoPosX = 0;
            _logoPosY = 0;
            _titlePosX = 24;
            _titlePosY = 9;
            _userDataPosX = 45;
            _userDataPosY = 9;
            menuPosX = 23;
            menuPosY = 11;
            tablePosX = 3;
            tablePosY = 13;
        }

        public virtual void Enter()
        {
            CursorVisible = false;
            ResetColor();
            Clear();
        }

        public virtual void UpdateMenu()
        {
            PageItems.CreateGraphic(Graphic.Logo, ConsoleColor.Magenta, _logoPosX, _logoPosY);

            PageItems.WriteText($"user: {Session.Instance.GetUserName()}",
                _userDataPosX, _userDataPosY, ConsoleColor.DarkCyan);

            PageItems.WriteText($"balance: {Session.Instance.GetUserBalance()}$",
                _userDataPosX, _userDataPosY + 1, ConsoleColor.DarkYellow);

            PageItems.WriteText($"~[{TitlePage}]~", _titlePosX, _titlePosY, ConsoleColor.White);

            selectedItem = menu.RunMenu();
        }

        public virtual void UpdateForm()
        {
            PageItems.CreateGraphic(Graphic.Logo, ConsoleColor.Magenta, _logoPosX, _logoPosY);

            PageItems.WriteText($"user: {Session.Instance.GetUserName()}",
                _userDataPosX, _userDataPosY, ConsoleColor.DarkCyan);

            PageItems.WriteText($"balance: {Session.Instance.GetUserBalance()}$",
                _userDataPosX, _userDataPosY + 1, ConsoleColor.DarkYellow);
           
            PageItems.WriteText($"~[{TitlePage}]~", _titlePosX, _titlePosY, ConsoleColor.White);

            ForegroundColor = ConsoleColor.Green;
        }

        public virtual void CreateWindow() { }

        public virtual void Exit() { }
    }
}