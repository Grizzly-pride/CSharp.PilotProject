using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PilotProject.DBContext;
using PilotProject.Services;
using static System.Console;
using static PilotProject.Pages.PageItems;

namespace PilotProject.Pages
{
    internal class LoginPage : BasePage
    {
        private string _name;
        private string _password;
        public override string TitlePage => "LOGIN";
        public LoginPage(PageController controller) : base(controller)
        {
            CreateWindow();
        }
        public override void Enter()
        {
            base.Enter();
            CursorVisible = true;
            UpdateForm();
        }
        public override void UpdateForm()
        {
            base.UpdateForm();

            for (int i = 0; i < itemsForm.Length; i++)
            {
                Write($" {itemsForm[i]}: ");

                switch (i)
                {
                    case 0: _name = ReadLine(); break;
                    case 1: _password = ReadLine(); break;
                }
            }
            WriteLine();

            if (Authentication())
            {
                WriteText(" - Successful login", 1, ConsoleColor.Blue);
                ReadKey();
                controller.TransitionToPage(Page.Main);
            }
            else
            {
                WriteText("- Invalid password or username!", 1, ConsoleColor.Red);
                ReadKey();
                Clear();

                WriteText("Do you want to try again?", 5, ConsoleColor.White);

                switch (YesOrNo(2, 12))
                {
                    case true: Enter(); break;
                    case false: controller.TransitionToPage(Page.Authorization); break;
                }
            }
        }

        public override void CreateWindow()
        {
            moveTitle = 11;
            itemsForm = new string[]
            {
                ReturnText("Name", 3),
                ReturnText("Password", 3),
            };
        }

        private bool Authentication()
        {
            dataBase = new();
            List<User> users = dataBase.Users.ToList();
            dataBase.Dispose();

            foreach (var user in users)
            {
                if (user.Name.Equals(_name) && user.Password.Equals(_password))
                {
                    Account.UserName = user.Name;
                    return true;
                }
            }
            return false;
        }

        public override void Exit()
        {
           
        }
    }
}
