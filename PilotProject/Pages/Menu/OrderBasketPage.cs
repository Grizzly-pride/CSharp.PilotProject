using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilotProject.Pages.Menu
{
    internal class OrderBasketPage : BasePage
    {
        public override string TitlePage => "ORDER BASKET";

        public OrderBasketPage(PageController controller) : base(controller)
        {
        }

        public override void Enter()
        {
            UpdateMenu();
        }

        public override void UpdateMenu()
        {
            base.UpdateMenu();
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}
