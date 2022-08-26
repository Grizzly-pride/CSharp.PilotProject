using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PilotProject.DBContext;
using PilotProject.Services;
using static System.Console;

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
            CursorVisible = true;
            Clear();
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
                ForegroundColor = ConsoleColor.Blue;
                WriteLine("- Successful login");
                ReadKey();
                controller.TransitionToPage(Page.Main);
            }
            else
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("- Invalid password or username!");
                ReadKey();
                Clear();

                CrossPage.Title("Do you want to try again?", 5, ConsoleColor.White);

                switch (CrossPage.YesOrNo(2, 12))
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
                " Name",
                " Password"
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
            base.Exit();
        }
    }
}
