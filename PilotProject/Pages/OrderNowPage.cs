using System.Text;
using PilotProject.Entities;
using PilotProject.Services;
using PilotProject.FoodMenu;
using static System.Console;


namespace PilotProject.Pages
{
    internal sealed class OrderNowPage : BasePage
    {
        private string _streat;
        private string _house;
        private string _roome;
        OrderBasketRepository orderBasket = new();
        public override string TitlePage => "ORDER NOW";
        public OrderNowPage(PageController controller) : base(controller)
        {
            CreateWindow();
        }

        public override void Enter()
        {
            base.Enter();
            UpdateForm();
        }

        public override void UpdateForm()
        {
            base.UpdateForm();

            if (orderBasket.GetOrderItems().Count.Equals(0))
            {
                PageItems.WriteText("Your shopping cart is empty!",
                    menuPosX - 5,
                    menuPosY + 2,
                    ConsoleColor.Red);

                PageItems.WriteText("Press enter to continue.",
                    menuPosX - 3,
                    menuPosY + 4,
                    ConsoleColor.White);

                ReadKey();
                controller.TransitionToPage(Page.MyAccount);
            }
            else
            {
                CursorVisible = true;

                for (int i = 0; i < itemsForm.Length; i++)
                {
                    PageItems.WriteText($" {itemsForm[i]}: ", menuPosX - 5, menuPosY + i, ConsoleColor.Green);

                    switch (i)
                    {
                        case 0: _streat = ReadLine(); break;
                        case 1: _house = ReadLine(); break;
                        case 2: _roome = ReadLine(); break;
                    }
                }

                string fullAddress = $"{_streat} st., {_house} - {_roome}";

                CheckDataService check = new();
                if (check.IsValidAddress(fullAddress))
                {
                    User? buyer = Session.Instance.CurrentUser;
                    Order newOrder = new(orderBasket.GetOrderItems(), buyer.Name, fullAddress);

                    Session.Instance.CurrentUser.Notyfication += Messenger.SendMessage;
                    Task.Run(async () => await Session.Instance.CurrentUser.Pay(newOrder.TotalPrice));

                    if (buyer.Balance >= newOrder.TotalPrice)
                    {
                        Task task = new(async () =>
                        {                        
                            await Messenger.SendMessage(buyer.Email, new Letter("Your order", GetCheckoutletter(newOrder)));
                            await FileService.ObjectToJsonAsync(FilePathService.GetPathFile(Folder.Orders, $"Order_{newOrder.Id}.json"), newOrder);                            
                        });
                        task.Start();

                        PageItems.WriteText("Your order is accepted. We sent messages to your email.",
                            menuPosX - 5,
                            menuPosY + 5,
                            ConsoleColor.Blue);

                        ReadKey();

                        task.Wait();
                        
                        ShippingProcess shipping = new();
                        shipping.DelivMessage += Messenger.SendMessage;
                        shipping.UserEmail = buyer.Email;
                        Thread ShippThread = new(shipping.Run);
                        ShippThread.Start();
                    }
                    else
                    {
                        PageItems.WriteText("Insufficient funds on the account!",
                            menuPosX - 5,
                            menuPosY + 5,
                            ConsoleColor.Red);

                        ReadKey();
                    }

                    controller.TransitionToPage(Page.MyAccount);
                }
                else
                {
                    PageItems.WriteText("Incorrect address!",
                        menuPosX - 5,
                        menuPosY + 5,
                        ConsoleColor.Red);

                    PageItems.WriteText("Do you want to try again?",
                        menuPosX - 5,
                        menuPosY + 7,
                        ConsoleColor.White);

                    switch (PageItems.YesOrNo(menuPosX + 22, menuPosY + 7))
                    {
                        case true: Enter(); break;
                        case false: controller.TransitionToPage(Page.MyAccount); break;
                    }
                }
            }
        }

        public override void Exit() { }

        public override void CreateWindow()
        {
            itemsForm = new string[]
            {
                "Streat",
                "Home",
                "Room"
            };
        }
       
        private string GetCheckoutletter(Order order)
        {
            StringBuilder sb = new();
            OrderBasketRepository _orderBasket = new();

            sb.Append("<p> <b>" + $"Hello, {order.BuyerName}. Your order has been accepted." + "</b> </p>");

            sb.Append("<ul> <li>" + $"Order number: {order.Id}" + "</li>");
            sb.Append("<li>" + $"Order time: {order.Time:MM/dd/yyyy HH:mm:ss UTC}" + "</li>");
            sb.Append("<li>" + $"Payment: online" + "</li>");
            sb.Append("<li>" + $"Delivery address: {order.DeliveryAddress}" + "</li> </ul> <br>");

            sb.Append("<table border = \"1\">");
            sb.Append("<tr> <th>Product</th> <th>Count</th> <th>Price</th> </tr>");

            foreach (var orderItem in _orderBasket.GetOrderItems())
            {
                if (orderItem.Product is Pizza pizza)
                {
                    sb.Append("<tr > <td>" + $"{pizza.Crust} crust pizza {pizza.Name} size {pizza.Size}cm." + "</td>");
                    sb.Append("<td align=\"center\">" + $"{orderItem.CountItem}" + "</td>");
                    sb.Append("<td align=\"center\">" + $"{string.Format("{0:0.0}", orderItem.PriceItem)}" + "</td> </tr>");
                }
                else if (orderItem.Product is Drink drink)
                {
                    sb.Append("<tr> <td>" + $"Drink {drink.Name} valume {drink.Volume}l." + "</td>");
                    sb.Append("<td align=\"center\">" + $"{orderItem.CountItem}" + "</td>");
                    sb.Append("<td align=\"center\">" + $"{string.Format("{0:0.0}", orderItem.PriceItem)}" + "</td> </tr>");
                }
            }

            sb.Append($"<td colspan = \"3\">Order price: {string.Format("{0:0.0}", _orderBasket.GetOrderItems().Sum(x => x.PriceItem))}$ </td> </tr> </table>");

            return sb.ToString();
        }
    }
}