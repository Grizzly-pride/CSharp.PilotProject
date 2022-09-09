using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using PilotProject.DBContext;
using PilotProject.Services;
using PilotProject.Entities;
using static System.Console;
using static PilotProject.Services.FilePathService;


namespace PilotProject.Pages
{
    internal class RegistrationPage : BasePage
    {
        private string _name;
        private string _password;
        private string _email;
        private int _lastLine;

        public override string TitlePage => "REGISTRATION";

        public RegistrationPage(PageController controller) : base(controller)
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
                PageItems.WriteText($"{itemsForm[i]}: ", menuPosX - 5, menuPosY + i, ConsoleColor.Green);

                switch (i)
                {
                    case 0: _name = ReadLine(); break;
                    case 1: _email = ReadLine(); break;
                    case 2: _password = ReadLine(); break;
                }
            }
            WriteLine();

            if (CheckData())
            {                
                User newUser = new(_name, _email, _password);

                Messenger.SendMessage(_email, Letter.GetTemplateLatter(Template.Registration));

                //string time = DateTime.UtcNow.ToString("MM/dd/yyyy HH:mm:ss UTC");
                //await FileService.ObjectToJsonAsync<String>(GetPathFile(Folder.DataJson, "SessionsData.json"), time);
                //await FileService.ObjectToJsonAsync<User>(GetPathFile(Folder.DataJson, "RegistrationUserData.json"), newUser);

                dataBase = new();
                dataBase.Add(newUser);
                dataBase.SaveChanges();
                dataBase.Dispose();

                PageItems.WriteText("Registration successful.", menuPosX - 5, 6,  ConsoleColor.Blue);
                PageItems.WriteText("An email has been sent to your mail.", menuPosX - 5, 7, ConsoleColor.Blue);
                ReadKey();
                controller.TransitionToPage(Page.Authorization);                
            }
            else
            {
                //ReadKey();
                //Clear();
                PageItems.WriteText("Do you want to try again?", menuPosX - 5, _lastLine + 1, ConsoleColor.White);

                switch (PageItems.YesOrNo(menuPosX - 7, _lastLine + 3))
                {
                    case true: Enter(); break;
                    case false: controller.TransitionToPage(Page.Authorization); break;
                }
            }
        }

        public override void CreateWindow()
        {
            //moveTitle = 11;
            itemsForm = new string[]
            {
                "Name",
                "Email",
                "Password"
            };
        }

        private static bool InputChecker(Func<string, bool> checkingValidation, string str) => checkingValidation(str);

        private bool CheckData()
        {
            bool isValid = true;
            int posX = menuPosX - 5;
            int posY = 6;
            CheckDataService authenticServ = new();
            
            if (!InputChecker(authenticServ.IsUniqueNameInDB, _name))
            {
                PageItems.WriteText("Name taken! Please enter another name.", posX, posY, ConsoleColor.Red);
                isValid = false;
                posY += 1;
            }
            if (!InputChecker(authenticServ.IsUniqueEmailInDB, _email))
            {
                PageItems.WriteText("This email is used another user! Please enter another email.", posX, posY, ConsoleColor.Red);
                isValid = false;
                posY += 1;
            }
            if (!InputChecker(authenticServ.IsValidName, _name))
            {
                PageItems.WriteText("Invalid Name! Name not provided.", posX, posY, ConsoleColor.Red);
                isValid = false;
                posY += 1;
            }
            if (!InputChecker(authenticServ.IsValidEmail, _email))
            {
                PageItems.WriteText("Invalid Email! example@mail.com", posX, posY, ConsoleColor.Red);
                isValid = false;
                posY += 1;
            }
            if (!InputChecker(authenticServ.IsValidPass, _password))
            {
                PageItems.WriteText("Invalid Password! Password length is less than 7 symbols.", posX, posY, ConsoleColor.Red);
                isValid = false;
                posY += 1;
            }
            _lastLine = posY;            
            return isValid;
        }

        public override void Exit()
        {
            
        }
    }
}