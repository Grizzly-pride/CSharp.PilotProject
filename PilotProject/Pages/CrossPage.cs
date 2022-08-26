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
    internal static class CrossPage
    {
        public static void Title(string title, int moveTitle, ConsoleColor color)
        {
            ForegroundColor = color;
            WriteLine($"{new string(' ', moveTitle)} {title}\n");
        }

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


        public static int EnterNumber(int posX, int posY, bool horizont)
        {
            NumericBuilder numeric = new(posX, posY, false)
            {
                ItemsRange = new(1, int.MaxValue)
            };

            return numeric.RunNumeric(false);
        }

        public static void AddingProductToCart(Product product)
        {
            Clear();
            Title($"Add {product.Name} to cart?", 7, ConsoleColor.White);

            if (YesOrNo(2, 12))
            {
                if (Account.IsAuthorization())
                {
                    Clear();
                    Title($"How many {product.Name} to add to cart?", 7, ConsoleColor.White);
                    int count = EnterNumber(2, 10, false);

                    Account.OrderBasket.AddProduct(product, count);
                    Title($"{count} {product.Name} have been added to your cart.", 7, ConsoleColor.Blue);
                    ReadKey();
                }
                else
                {
                    Clear();
                    Title("You must be logged in to add to cart.", 7, ConsoleColor.Red);
                    Title("Press enter to continue.", 12, ConsoleColor.White);
                    ReadKey();
                }
            }

        }
 
    }
}