using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilotProject.Pages.Menu
{
    internal class PizzasPage : BasePage
    {
        public override string TitlePage => "PIZZAS";
        public PizzasPage(PageController controller) : base(controller)
        {
        }
    }
}
