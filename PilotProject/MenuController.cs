using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PilotProject.Pages.Menu;
using PilotProject.Pages.Forms;
using PilotProject.Pages;

namespace PilotProject
{
    enum Page
    {
        Main,
        Authentication,
        Registration
    }

    internal sealed class MenuController
    {
        public BasePage? CurrentPage { get; private set; }
        public Dictionary<Page, BasePage> PageCollection { get; private set; }       

        public void InitializationPages()
        {
            PageCollection = new()
            {
                [Page.Main] = new MainPage(this),
                [Page.Authentication] = new AuthenticationPage(this),
                [Page.Registration] = new RegistrationPage(this)
            };           
        }

        public void SetPageByDefault(Page pageDefault)
        {
            CurrentPage = PageCollection[pageDefault];
            CurrentPage.Enter();
        }

        public void TransitionToPage(Page newPage)
        {
            CurrentPage?.Exit();
            CurrentPage = PageCollection[newPage];
            CurrentPage.Enter();
        }
    }
}
