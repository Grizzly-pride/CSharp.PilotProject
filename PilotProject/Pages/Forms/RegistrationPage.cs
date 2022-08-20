using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Console;
using PilotProject.Services;
using PilotProject.DBContext;

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
            CreateWindow();
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

            if (CheckData())
            {
                User newUser = new(name, email, password);
                ApplicationContext db = new();
                db.Add(newUser);
                db.SaveChanges();
              
                ForegroundColor = ConsoleColor.Blue;
                WriteLine("Registration successful.");
                ReadKey();
                controller.TransitionToPage(Page.Authorization);
            }
            else
            {
                ReadKey();
                controller.TransitionToPage(Page.Cross);
            }
        }

        public override void CreateWindow()
        {
            moveTitle = 9;
            itemsForm = new string[]
            {
                " Name",
                " Email",
                " Password"
            };
        }

        private bool CheckData()
        {
            bool isValid = true;
            ForegroundColor = ConsoleColor.Red;

            RegistrationService authenticServ = new();

            if (!authenticServ.IsUniqueNameInDB(name))
            {
                isValid = false;
                WriteLine("- Name taken! Please enter another name.");
            }
            if (!authenticServ.IsUniqueEmailInDB(email))
            {
                isValid = false;
                WriteLine("- This email is used another user! Please enter another email.");
            }
            if (!authenticServ.IsValidName(name))
            {
                isValid = false;
                WriteLine("- Invalid Name! Name not provided.");
            }
            if (!authenticServ.IsValidEmail(email))
            {
                isValid = false;
                WriteLine("- Invalid Email! example@mail.com");
            }
            if (!authenticServ.IsValidPass(password))
            {
                isValid = false;
                WriteLine("- Invalid Password! Password length is less than 7 symbols.");
            }                         
            return isValid; 
        }

        public override void Exit()
        {
            controller.PreviousPage = Page.Registration;
            base.Exit();
            
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
