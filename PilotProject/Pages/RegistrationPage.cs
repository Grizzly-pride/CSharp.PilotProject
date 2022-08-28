using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Console;
using PilotProject.Services;
using PilotProject.DBContext;
using static PilotProject.Pages.PageItems;

namespace PilotProject.Pages
{
    internal class RegistrationPage : BasePage
    {
        private string _name;
        private string _password;
        private string _email;

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

        public override void UpdateForm()
        {
            base.UpdateForm();

            for (int i = 0; i < itemsForm.Length; i++)
            {
                Write($" {itemsForm[i]}: ");

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
                dataBase = new();
                dataBase.Add(newUser);
                dataBase.SaveChanges();
                dataBase.Dispose();

                WriteText("- Registration successful.", 1, ConsoleColor.Blue);
                ReadKey();
                controller.TransitionToPage(Page.Authorization);
            }
            else
            {
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
            moveTitle = 9;
            itemsForm = new string[]
            {
                ReturnText("Name",3),
                ReturnText("Email",3),
                ReturnText("Password",3),
            };
        }

        private bool CheckData()
        {
            bool isValid = true;
            int moveText = 2;
            RegistrationService authenticServ = new();

            if (!authenticServ.IsUniqueNameInDB(_name))
            {
                isValid = false;
                WriteText("- Name taken! Please enter another name.", moveText, ConsoleColor.Red);
            }
            if (!authenticServ.IsUniqueEmailInDB(_email))
            {
                isValid = false;
                WriteText("- This email is used another user! Please enter another email.", moveText, ConsoleColor.Red);
            }
            if (!authenticServ.IsValidName(_name))
            {
                isValid = false;
                WriteText("- Invalid Name! Name not provided.", moveText, ConsoleColor.Red);
            }
            if (!authenticServ.IsValidEmail(_email))
            {
                isValid = false;
                WriteText("- Invalid Email! example@mail.com", moveText, ConsoleColor.Red);
            }
            if (!authenticServ.IsValidPass(_password))
            {
                isValid = false;
                WriteText("- Invalid Password! Password length is less than 7 symbols.", moveText, ConsoleColor.Red);
            }
            return isValid;
        }

        public override void Exit()
        {
            //base.Exit();
        }



        /*
        private string ParsToNumber(string numberPhone)
        {
            PhoneNumberUtil phoneUtil = PhoneNumberUtil.GetInstance();
            PhoneNumber numberProto = phoneUtil.Parse(numberPhone, "BY");
            String formattedPhone = phoneUtil.Format(numberProto, PhoneNumberFormat.INTERNATIONAL);
            return formattedPhone;
        }
        */

        /*
       private bool IsValidPhone(string strNum)
       {
           int countNum = 9;
           int counter = 0;
           char[] chars = strNum.ToCharArray();

           for (int i = 0; i < chars.Length;)
           {
               if (!char.IsDigit(chars[i]))
               {
                   ForegroundColor = ConsoleColor.Red;
                   WriteLine("Invalid phone number! Must contain only digits.");
                   return false;
               }
               i++;
               counter = i;
           }

           if (!counter.Equals(countNum))
           {
               ForegroundColor = ConsoleColor.Red;
               WriteLine("Invalid phone number! Must contain 9 digits.");
               return false;
           }
           else
           {
               return true;
           }
       }
       */
    }
}
