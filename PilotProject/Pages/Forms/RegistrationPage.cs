using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Console;
using PilotProject.Services;
using System.IO;

namespace PilotProject.Pages.Forms
{
    internal class RegistrationPage : BasePage
    {       
        private string name;
        private string password;
        private string email;       
        public override string TitlePage => "REGISTRATION";

        public RegistrationPage(PageController controller) : base(controller)
        {
            
            itemsForm = new string[]    
            {
                "Name",
                "Email",
                "Password"
            };

        }

        public override void Enter()
        {
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
                    case 0:
                        name = ReadLine();
                        break;
                    case 1:
                        email = ReadLine();
                        break;
                    case 2:
                        password = ReadLine();
                        break;
                }
            }
            WriteLine();

            bool isValidName = IsValidName(name);
            bool isValidEmail = IsValidEmail(email);
            bool isValidPass = IsValidPass(password);

            if (isValidName && isValidEmail && isValidPass)
            {
                ForegroundColor = ConsoleColor.Blue;
                WriteLine("All fields is correctly");
                ReadKey();
            }
            else
            {
                ReadKey();
                controller.TransitionToPage(Page.Cross);
            }
            
            ClientAccount newClient = new(name, email, password);
            DataService.WriteToJesonFile(newClient, DataFile.Account);

            controller.TransitionToPage(Page.Authentication);
        }

        public override void Exit()
        {
            controller.PreviousPage = Page.Registration;
            base.Exit();
            
        }

        #region Validation Methods
        private bool IsValidName(string name)
        {
            if (name.Length.Equals(0))
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("Invalid Name! line is empty.");
                return false;
            }

            char[] chars = name.ToCharArray();
            foreach (var c in chars)
            {
                if (!char.IsLetter(c))
                {
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine("Invalid Name! Must contain only letters.");
                    return false;
                }
            }

            return true;
        }
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
        private bool IsValidEmail(string email)
        {
            string pattern = "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}";
            Match isMatch = Regex.Match(email, pattern, RegexOptions.IgnoreCase);
            if (isMatch.Success)
            {
                return true;
            }
            else
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("Invalid email!");
                return false;
            }

        }

        private bool IsValidPass(string email)
        {
            if (email.Length > 0)
            {
                return true;
            }
            else
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("Invalid password!");
                return false;
            }
        }
        #endregion

     
        /*
        private string ParsToNumber(string numberPhone)
        {
            PhoneNumberUtil phoneUtil = PhoneNumberUtil.GetInstance();
            PhoneNumber numberProto = phoneUtil.Parse(numberPhone, "BY");
            String formattedPhone = phoneUtil.Format(numberProto, PhoneNumberFormat.INTERNATIONAL);
            return formattedPhone;
        }
        */       
    }
}
