using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PilotProject.Pages;

namespace PilotProject
{
    internal static class Main
    {
        public static void Run()
        {
            MenuController MenuController = new();
            MenuController.InitializationPages();
            MenuController.SetPageByDefault(Page.Main);
        }
    }
}
