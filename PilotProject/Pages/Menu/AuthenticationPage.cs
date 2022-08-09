using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using PhoneNumbers;
using System.Text.RegularExpressions;
using PilotProject.Pages;

namespace PilotProject.Pages.Menu
{
    internal class AuthenticationPage : BasePage
    {
        private string name;
        private string password;
        private string email;
        private string phone;
        
        public AuthenticationPage(MenuController controller) : base(controller)
        {
            TitlePage = "Authentication";
            inputHandler.ItemsMenu = new()
            {
                "Login",
                "Registration",
                "Back"
            };
        }

        public override void Enter()
        {
            CursorVisible = false;
            UpdateMenu();
        }

        public override void UpdateMenu()
        {
            base.UpdateMenu();

            switch (selectedItem)
            {
                case 0:
                    LoginForm();
                    break;
                case 1:
                    controller.TransitionToPage(Page.Registration);
                    break;
                case 2:
                    controller.TransitionToPage(Page.Main);
                    break;
            }
        }

        public override void Exit()
        {
            base.Exit();
        }

        private void LoginForm()
        {
            Clear();
            ReadKey();
            controller.TransitionToPage(Page.Main);
        }

        private void RegistrationForm()
        {

            Clear();
            CursorVisible = true;
            ForegroundColor = ConsoleColor.Green;

            Write($"Name: "); name = ReadLine();
            while (!IsValidName(name))
            {
                Clear();
                Write("Name: Incorrecte data");
                ReadKey();

                Clear();
                Write("Name: "); name = ReadLine();
            }


            Write("Email: "); email = ReadLine();
            while (!isValidEmail(email))
            {
                Clear();
                WriteLine($"Name: {name}");
                Write("Email: Incorrecte data");
                ReadKey();

                Clear();
                WriteLine($"Name: {name}");
                Write("Email: "); email = ReadLine();
            }
         
                        
            Write("Phone: +375 "); phone = ReadLine();           
            while (!IsValidNumPhone(phone))
            {
                Clear();
                WriteLine($"Name: {name}");
                WriteLine($"Email: {email}");
                Write("Phone: Incorrecte data");
                ReadKey();

                Clear();
                WriteLine($"Name: {name}");
                WriteLine($"Email: {email}");
                Write("Phone: +375 "); phone = ReadLine();
            }
            phone = ParsToNumber(phone);

            Write($"Password: "); password = ReadLine();
            while (!isValidPass(password))
            {
                Clear();
                WriteLine($"Name: {name}");
                WriteLine($"Email: {email}");
                WriteLine($"Phone: {phone}");
                Write("Password: Incorrecte data");
                ReadKey();

                Clear();
                WriteLine($"Name: {name}");
                WriteLine($"Email: {email}");
                WriteLine($"Phone: {phone}");
                Write("Password: "); password = ReadLine();
            }

            Client newClient = new(name, email, password, phone);
            CursorVisible = false;
            controller.TransitionToPage(Page.Main);
        }

        private bool IsValidName(string name)
        {
            if(name.Length.Equals(0))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool IsValidNumPhone(string strNum)
        {
            int countNum = 9;
            bool isNum = false;
            char[] chars = strNum.ToCharArray();

            if(chars.Length < countNum)
            {
                return false;
            }
            
            foreach(char c in chars)
            {
                if (char.IsDigit(c))
                {
                    isNum = true;
                }
                else
                {
                    isNum = false;
                    break;
                }
            }
            return isNum;
        }

        private bool isValidEmail(string email)
        {
            string pattern = "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}";
            Match isMatch = Regex.Match(email, pattern, RegexOptions.IgnoreCase);
            return isMatch.Success;
        }

        private bool isValidPass(string email)
        {
            if(email.Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private string ParsToNumber(string numberPhone)
        {
            PhoneNumberUtil phoneUtil = PhoneNumberUtil.GetInstance();
            PhoneNumber numberProto = phoneUtil.Parse(numberPhone, "BY");
            String formattedPhone = phoneUtil.Format(numberProto, PhoneNumberFormat.INTERNATIONAL);
            return formattedPhone;
        }
    }
}
