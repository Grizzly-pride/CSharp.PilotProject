using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace PilotProject.Pages.Forms
{
    internal class RegistrationPage : BasePage
    {
        
        private string name;
        private string password;
        private string email;
        private string phone;
        
        private string[] itemsForm;

        public RegistrationPage(MenuController controller) : base(controller)
        {
            TitlePage = "Registration";
            itemsForm = new string[]    
            {
                "Name",
                "Password",
                "Email",
                "Phone"  
            };
        }

        public override void Enter()
        {
            base.Enter();
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

            Client newClient = new(name, email, password, phone);
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}
