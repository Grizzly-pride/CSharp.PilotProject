using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilotProject.Pages
{
    enum Page
    {
        Main,
        Authorization,
        Registration,
        LoginPage,
        OrderBasket,
        Drinks,
        Pizzas,
        MyAccount,
        OrderNow
    }

    internal sealed class PageController
    {
        public BasePage? CurrentPage { get; private set; }
        public Dictionary<Page, BasePage> PageCollection { get; private set; } 

        public void InitializationPages()
        {
            PageCollection = new()
            {
                [Page.Main] = new MainPage(this),
                [Page.Authorization] = new AuthorizationPage(this),
                [Page.Registration] = new RegistrationPage(this),
                [Page.LoginPage] = new LoginPage(this),
                [Page.OrderBasket] = new OrderBasketPage(this),
                [Page.Drinks] = new DrinksPage(this),
                [Page.Pizzas] = new PizzasPage(this),
                [Page.MyAccount] = new MyAccountPage(this),
                [Page.OrderNow] = new OrderNowPage(this),

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
