using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace PilotProject.Pages.Forms
{
    internal class LoginPage : BasePage
    {
        private string name;
        private string password;
        public override string TitlePage => "LOGIN";
        public LoginPage(PageController controller) : base(controller)
        {
            itemsForm = new string[]
            {
                "Name",
                "Password"
            };
        }
        public override void Enter()
        {
            
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
                }
            }
        }

        public override void Exit()
        {
            base.Exit();
        }

    }
}
