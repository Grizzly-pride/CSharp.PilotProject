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
        public override async void UpdateForm()
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

            if (await Authentication())
            {
                WriteText(" - Successful login", 5, 5, ConsoleColor.Blue);
                ReadKey();
                controller.TransitionToPage(Page.Main);
            }
            else
            {
                WriteText("- Invalid password or username!", 5, 5, ConsoleColor.Red);
                ReadKey();
                Clear();

                WriteText("Do you want to try again?", 5, 0, ConsoleColor.White);

                switch (YesOrNo(10, 2))
                {
                    case true: Enter(); break;
                    case false: controller.TransitionToPage(Page.Authorization); break;
                }
            }
        }

        public override void Exit()
        {

        }

        public override void CreateWindow()
        {
            moveTitle = 11;
            itemsForm = new string[]
            {
                ReturnText("Name", 5),
                ReturnText("Password", 5),
            };
        }

        private async Task<bool> Authentication()
        {
            dataBase = new();
            List<User> users = dataBase.Users.ToList();
            dataBase.Dispose();

            foreach (var user in users)
            {
                if (user.Name.Equals(_name) && user.Password.Equals(_password))
                {
                    //FileDataService fd = new();
                    //Account.ActivUser = user;
                    //await fd.ObjectToJsonAsync(DataFile.Sessions, user);

                    Account.UserName = user.Name;
                    return true;
                }
            }
            return false;
        }
    }
}
