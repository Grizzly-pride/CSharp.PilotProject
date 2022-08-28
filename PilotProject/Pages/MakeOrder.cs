using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilotProject.Pages
{
    internal class MakeOrder : BasePage
    {
        public MakeOrder(PageController controller) : base(controller)
        {
        }

        public override string TitlePage => "MAKE AN ORDER";
    }
}
