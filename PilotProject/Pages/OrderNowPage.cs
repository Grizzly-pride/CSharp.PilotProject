using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PilotProject.Entities;
using PilotProject.Services;
using PilotProject.FoodMenu;



namespace PilotProject.Pages
{
    internal class OrderNowPage : BasePage
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

            if (orderBasket.GetOrderItems().Count.Equals(0))
            {
                PageItems.WriteText("Your shopping cart is empty", 11, 0, ConsoleColor.Red);
                PageItems.WriteText("Press enter to continue.", 12, 2, ConsoleColor.White);
                Console.ReadKey();
                controller.TransitionToPage(Page.MyAccount);
            }
            else
            {
                Console.CursorVisible = true;
                UpdateForm();
            }
        }

        public override void UpdateForm()
        {
            base.UpdateForm();

            for (int i = 0; i < itemsForm.Length; i++)
            {
                Console.Write($" {itemsForm[i]}: ");

                switch (i)
                {
                    case 0: _streat = Console.ReadLine(); break;
                    case 1: _house = Console.ReadLine(); break;
                    case 2: _roome = Console.ReadLine(); break;
                }
            }

            string fullAddress = $"{_streat} st., {_house} - {_roome}";

            CheckDataService check = new();

            if (check.IsValidAddress(fullAddress))
            {
                Order newOrder = new(orderBasket.GetOrderItems(), buyer: Session.GetStatic().UserName, fullAddress);

                Task task = new(async () =>
                {
                    await Messenger.SendMessage(Session.GetStatic().Email, new Letter("Your order", GetCheckoutletter(newOrder)));
                    await FileService.ObjectToJsonAsync(FilePathService.GetPathFile(Folder.Orders, $"Order_{newOrder.Id}.json"), newOrder);
                });
                task.Start();

                PageItems.WriteText("Your order is accepted. We sent messages to your email.", posX: 5, posY: 6, ConsoleColor.Blue);
                Console.ReadKey();

                task.Wait();

                ShippingProcess shipping = new();
                shipping.DelivMessage += Messenger.SendMessage;
                Thread Shipping = new(shipping.Run);
                Shipping.Start();

                controller.TransitionToPage(Page.MyAccount);
            }
            else
            {
                PageItems.WriteText("- Incorrect address!", posX: 5, posY: 6, ConsoleColor.Red);
                Console.ReadKey();
                Console.Clear();
                PageItems.WriteText("Do you want to try again?", 5, ConsoleColor.White);

                switch (PageItems.YesOrNo(10, 2))
                {
                    case true: Enter(); break;
                    case false: controller.TransitionToPage(Page.MyAccount); break;
                }
            }
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
                PageItems.ReturnText("Streat", 5),
                PageItems.ReturnText("Home", 5),
                PageItems.ReturnText("Room", 5),
            };
        }

        
        private string GetCheckoutletter(Order order)
        {
            StringBuilder sb = new();
            OrderBasketRepository _orderBasket = new();

            sb.Append("<p> <b>" + $"Hello, {order.BuyerName}. Your order has been accepted." + "</b> </p>");

            sb.Append("<ul> <li>" + $"Order number: {order.Id}" + "</li>");
            sb.Append("<li>" + $"Order time: {order.Time:MM/dd/yyyy HH:mm:ss UTC}" + "</li>");
            sb.Append("<li>" + $"Payment: cash" + "</li>");
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
