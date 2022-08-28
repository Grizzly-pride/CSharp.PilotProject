using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using PilotProject.Builders;
using PilotProject.FoodMenu;

namespace PilotProject.Pages
{
    internal static class PageItems
    {
        public static void WriteText(string text, int moveText, ConsoleColor color)
        {
            ForegroundColor = color;
            WriteLine($"{new string(' ', moveText)} {text}\n");
        }

        public static string ReturnText(string text, int moveText) => $"{new string(' ', moveText)} {text}";


        public static bool YesOrNo(int posX, int posY)
        {
            ResetColor();
            CursorVisible = false;

            MenuBuilder menu = new(posX, posY, false)
            {
                ItemsMenu = new(2) { "Yes", "No" }
            };

            return menu.RunMenu() == 0;
        }


        public static int EnterNumber(int posX, int posY, bool quit)
        {
            NumericBuilder numeric = new(posX, posY, quit)
            {
                ItemsRange = new(1, int.MaxValue)
            };
            return numeric.RunNumeric(true);
        }


        public static void AddingToCart(Product product)
        {
            WriteText($"How many {product.Name} {product.Category.ToLower()} to add to cart?", 7, ConsoleColor.White);
            WriteText($"Add:", 7, ConsoleColor.Green);
            int count = EnterNumber(2, 14, true);

            Account.OrderBasket.AddProduct(product, count);

            if (product is Pizza pizza)
            {
                if (count > 1)
                {
                    WriteText($"{count} {pizza.Crust.ToLower()} crust pizzas {pizza.Name} size {pizza.Size}сm. have been added to your cart.", 7, ConsoleColor.Blue);
                }
                else
                {
                    WriteText($"{count} {pizza.Crust.ToLower()} crust pizza {pizza.Name} size {pizza.Size}сm. have been added to your cart.", 7, ConsoleColor.Blue);
                }
            }
            else if (product is Drink drink)
            {
                if (count > 1)
                {
                    WriteText($"{count} drinks {drink.Name} valume {drink.Volume}l. have been added to your cart.", 7, ConsoleColor.Blue);
                }
                else
                {
                    WriteText($"{count} drink {drink.Name} valume {drink.Volume}l. have been added to your cart.", 7, ConsoleColor.Blue);
                }
            }

            ReadKey();
        }

        public static void ModifyCountInCart(Product product)
        {
            WriteText($"Modifying the count of {product.Name} {product.Category.ToLower()}s in the cart.", 7, ConsoleColor.White);            
            WriteText($"New count:", 7, ConsoleColor.Green);
            int count = EnterNumber(2, 14, true);

            Account.OrderBasket.ModifyCountProduct(product, count);
            WriteText($"Count changed successfully.", 7, ConsoleColor.Blue);
        }

        public static void RemoveFromCart(Product product)
        {
            WriteText($"Are you sure you want to remove the {product.Name} {product.Category.ToLower()} from the cart?", 7, ConsoleColor.White);

            if (YesOrNo(2,12))
            {
                Account.OrderBasket.DeleteProduct(product);
                WriteText($"The {product.Category.ToLower()} {product.Name} has been successfully removed from the cart", 7, ConsoleColor.Blue);
            }
        }
    }
}