using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using PhoneNumbers;
using static System.Console;

namespace PilotProject.Pages.Forms
{
    internal class RegistrationPage : BasePage
    {       
        private string name;
        private string password;
        private string email;
        private string phone;       
        public override string TitlePage => "REGISTRATION";

        public RegistrationPage(PageController controller) : base(controller)
        {
            
            itemsForm = new string[]    
            {
                "Name",
                "Password",
                "Email",
                "Phone"  
            };

            inputHandler.ItemsMenu = new()
            {
                "Continue",
                "Back"
            };
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
                    case 0:
                        name = ReadLine();
                        break;
                    case 1:
                        password = ReadLine();
                        break;
                    case 2:
                        email = ReadLine();
                        break;
                    case 3:
                        phone = ReadLine();
                        break;
                }
            }
            WriteLine();

            bool isValid = false;
            isValid = IsValidName(name);
            isValid = IsValidPass(password);
            isValid = IsValidEmail(email);
            isValid = IsValidPhone(phone);

            if (isValid)
            {
                WriteLine("All fields is correctly");
            }
            else
            {
                ReadKey();
                controller.TransitionToPage(Page.Cross);
            }

            Client newClient = new(name, email, password, ParsToNumber(phone));

            controller.TransitionToPage(Page.Authentication);
        }

        public override void Exit()
        {
            base.Exit();
        }

        #region Validation Methods
        private bool IsValidName(string name)
        {
            if (name.Length.Equals(0))
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("Invalid Name!");
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool IsValidPhone(string strNum)
        {
            int countNum = 9;
            bool isNum = false;
            char[] chars = strNum.ToCharArray();

            if (chars.Length < countNum)
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("Invalid number of digits!");
                return false;
            }

            foreach (char c in chars)
            {
                if (char.IsDigit(c))
                {
                    isNum = true;
                }
                else
                {
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine("Invalid phone number! Enter NDC and SN for your country.");
                    return false;
                }
            }
            return isNum;
        }

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

        #region Other Methods
        private string ParsToNumber(string numberPhone)
        {
            PhoneNumberUtil phoneUtil = PhoneNumberUtil.GetInstance();
            PhoneNumber numberProto = phoneUtil.Parse(numberPhone, "BY");
            String formattedPhone = phoneUtil.Format(numberProto, PhoneNumberFormat.INTERNATIONAL);
            return formattedPhone;
        }
        #endregion
    }
}
