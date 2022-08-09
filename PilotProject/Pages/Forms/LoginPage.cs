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
            base.Enter();
        }
        public override void UpdateForm()
        {           
            base.UpdateForm();


        }

        public override void Exit()
        {
            base.Exit();
        }

    }
}
