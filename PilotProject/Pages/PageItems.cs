using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PilotProject.Entities;
using static System.Console;
using PilotProject.Builders;
using PilotProject.FoodMenu;

namespace PilotProject.Pages
{
    internal static class PageItems
    {
        public static void WriteText(string text, int posX, int posY, ConsoleColor color)
        {
            ForegroundColor = color;
            SetCursorPosition(posX, posY);
            Write(text);
        }

        public static void WriteText(string text, int posX, ConsoleColor color)
        {
            ForegroundColor = color;
            Write($"{new string(' ', posX)} {text}");
        }

        public static string ReturnText(string text, int moveText) => $"{new string(' ', moveText)} {text}";


        public static bool YesOrNo(int posX, int posY)
        {
            ResetColor();
            CursorVisible = false;

            TextericBuilder texteric = new(posX, posY, false)
            {
                ItemsText = new(2) { "Yes", "No" }
            };

            return texteric.RunTexteric() == 0;
        }

        public static int ChangeOrDelete(int posX, int posY)
        {
            ResetColor();
            CursorVisible = false;

            TextericBuilder texteric = new(posX, posY, true)
            {
                ItemsText = new(2) { "change count", "delete" }
            };

            return texteric.RunTexteric();
        }


        public static int EnterNumber(int posX, int posY, bool quit)
        {
            NumericBuilder numeric = new(posX, posY, quit)
            {
                ItemsRange = new(1, int.MaxValue)
            };
            return numeric.RunNumeric(Mod.Vertical);
        }


        public static void AddingToCart(Product product)
        {
            WriteText($"How many {product.Name} {product.Category.ToLower()} to add to cart?", 7, 0, ConsoleColor.White);
            WriteText($"Add:", 7, 2, ConsoleColor.Green);

            int count = EnterNumber(14, 2, true);
            OrderBasketRepository orderBasket = new();

            if (count > 0) { orderBasket.AddOrderItem(new(product, count)); }

            if (product is Pizza pizza)
            {
                if (count > 1)
                {
                    WriteText($"{count} {pizza.Crust.ToLower()} crust pizzas {pizza.Name} size {pizza.Size}сm. have been added to your cart.", 7, 4, ConsoleColor.Blue);
                }
                else if (count == 1)
                {
                    WriteText($"{count} {pizza.Crust.ToLower()} crust pizza {pizza.Name} size {pizza.Size}сm. have been added to your cart.", 7, 4, ConsoleColor.Blue);
                }
            }
            else if (product is Drink drink)
            {
                if (count > 1)
                {
                    WriteText($"{count} drinks {drink.Name} valume {drink.Volume}l. have been added to your cart.", 7, 4, ConsoleColor.Blue);
                }
                else if (count == 1)
                {
                    WriteText($"{count} drink {drink.Name} valume {drink.Volume}l. have been added to your cart.", 7, 4, ConsoleColor.Blue);
                }
            }

            if (count != 0) { ReadKey(); }
        }


        public static void AddingToCart(Product product, int posX, int posY)
        {
            CursorVisible = false;

            WriteText($"Add:", posX, posY, ConsoleColor.Green);
            int count = EnterNumber(posX + 5, posY - 1, true);

            OrderBasketRepository orderBasket = new();
            if (count > 0) { orderBasket.AddOrderItem(new(product, count)); }

            if (product is Pizza pizza)
            {
                if (count > 1)
                {
                    WriteText($"{count} {pizza.Crust.ToLower()} crust pizzas {pizza.Name} size {pizza.Size}сm. have been added to your cart.", 1, 3, ConsoleColor.Blue);
                }
                else if (count == 1)
                {
                    WriteText($"{count} {pizza.Crust.ToLower()} crust pizza {pizza.Name} size {pizza.Size}сm. have been added to your cart.", 1, 3, ConsoleColor.Blue);
                }
            }
            else if (product is Drink drink)
            {
                if (count > 1)
                {
                    WriteText($"{count} drinks {drink.Name} valume {drink.Volume}l. have been added to your cart.", 1, 3, ConsoleColor.Blue);
                }
                else if (count == 1)
                {
                    WriteText($"{count} drink {drink.Name} valume {drink.Volume}l. have been added to your cart.", 1, 3, ConsoleColor.Blue);
                }
            }

            if (count != 0) { ReadKey(); }
        }


        public static void ModifyCountInCart(OrderItem orderItem, int currentCount)
        {
            WriteText($"Modifying the count of {orderItem.Product.Name} {orderItem.Product.Category.ToLower()}s in the cart.", 7, 0, ConsoleColor.White);
            WriteText($"Current count: {currentCount}", 7, 2, ConsoleColor.Green);
            WriteText($"New count:", 7, 3, ConsoleColor.Green);

            int count = EnterNumber(18, 3, true);
            OrderBasketRepository orderBasket = new();

            if(count > 0) { orderBasket.ModifyCountOrderItem(orderItem, count); }

            WriteText($"Count changed successfully.", 7, 5, ConsoleColor.Blue);
            ReadKey();
        }

        public static void RemoveFromCart(OrderItem orderItem)
        {
            WriteText($"Are you sure you want to remove the {orderItem.Product.Name} {orderItem.Product.Category.ToLower()} from the cart?", 7, 0, ConsoleColor.White);

            if (YesOrNo(7,2))
            {
                OrderBasketRepository orderBasket = new();
                orderBasket.DeleteOrderItem(orderItem);
                WriteText($"The {orderItem.Product.Category.ToLower()} {orderItem.Product.Name} has been successfully removed from the cart.", 7, 5, ConsoleColor.Blue);
                ReadKey();
            }           
        }
    }
}