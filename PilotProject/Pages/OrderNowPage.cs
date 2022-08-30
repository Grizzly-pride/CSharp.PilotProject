using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static PilotProject.Pages.PageItems;

namespace PilotProject.Pages
{
    internal class OrderNowPage : BasePage
    {
        private string _streat;
        private string _house;
        private string _roome;
        public override string TitlePage => "ORDER NOW";
        public OrderNowPage(PageController controller) : base(controller)
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
                    case 0: _streat = ReadLine(); break;
                    case 1: _house = ReadLine(); break;
                    case 2: _roome = ReadLine(); break;
                }
            }
            WriteLine();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void CreateWindow()
        {
            moveTitle = 11;
            itemsForm = new string[]
            {
                ReturnText("Sreat", 5),
                ReturnText("Home nuber", 5),
                ReturnText("Room nuber", 5),
            };
        }

    }
}
