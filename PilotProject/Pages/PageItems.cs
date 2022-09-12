using PilotProject.Entities;
using PilotProject.Builders;
using PilotProject.FoodMenu;
using static System.Console;


namespace PilotProject.Pages
{
    enum Graphic
    {
        Logo,
        ThanksForWatching,
        AuthorSlogan
    }

    internal static class PageItems
    {
        #region Data

        private static string _logo = @"
                _   _ ______ _______    _____ _
               | \ | |  ____|__   __|  |  __ (_)             
               |  \| | |__     | |     | |__) | __________ _ 
               | . ` |  __|    | |     |  ___/ |_  /_  / _` |
              _| |\  | |____   | |     | |   | |/ / / / (_| |
             (_)_| \_|______|  |_|     |_|   |_/___/___\__,_|";

        private static string _finalization = @"                                                                            
 _____ _           _          ___                      _       _   _         
|_   _| |_ ___ ___| |_ ___   |  _|___ ___    _ _ _ ___| |_ ___| |_|_|___ ___ 
  | | |   | .'|   | '_|_ -|  |  _| . |  _|  | | | | .'|  _|  _|   | |   | . |
  |_| |_|_|__,|_|_|_,_|___|  |_| |___|_|    |_____|__,|_| |___|_|_|_|_|_|_  |
                                                                        |___|";                                                                            

        private static string _authorSlogan = "Project for IT Academy by Alexander Medved";


        private static Dictionary<Graphic, string> GraficBox = new()
        {
            [Graphic.Logo] = _logo,
            [Graphic.ThanksForWatching] = _finalization,
            [Graphic.AuthorSlogan] = _authorSlogan
        };
        #endregion

        #region Tools
        public static void CreateGraphic(Graphic graphItem, ConsoleColor color, int posX, int posY)
        {
            ForegroundColor = color;
            SetCursorPosition(posX, posY);
            WriteLine(GraficBox[graphItem]);
        }

        public static void WriteText(string text, int posX, int posY, ConsoleColor color)
        {
            ForegroundColor = color;
            SetCursorPosition(posX, posY);
            Write(text);
        }

        public static void SpotСleaning(int posX, int posY, int cleaningRange)
        {
            SetCursorPosition(posX, posY);
            Write(new string(' ', cleaningRange));
        }

        public static bool YesOrNo(int posX, int posY)
        {
            ResetColor();
            CursorVisible = false;

            TextericBuilder texteric = new(posX, posY, false)
            {
                ItemsText = new(2) { "Yes", "No" }
            };

            return texteric.RunTexteric(Mod.Horizontal) == 0;
        }

        public static int ChangeOrDelete(int posX, int posY)
        {
            ResetColor();
            CursorVisible = false;

            TextericBuilder texteric = new(posX, posY, true)
            {
                ItemsText = new(2) { "change count", "delete" }
            };

            return texteric.RunTexteric(Mod.Vertical);
        }

        public static int EnterNumber(int posX, int posY, bool quit)
        {
            NumericBuilder numeric = new(posX, posY, quit)
            {
                ItemsRange = new(1, int.MaxValue)
            };
            return numeric.RunNumeric(Mod.Vertical);
        }
        #endregion 

        #region Table methods
        public static void ModifyCart(OrderItem orderItem, int posX, int posY)
        {
            OrderBasketRepository orderBasket = new();

            int result = ChangeOrDelete(posX, posY);

            for (int i = 0; i < 3; i++) //cleaning 3 lines
            {
                SpotСleaning(posX, posY + i, 15);
            }

            WriteText("new count:", posX, posY + 1, ConsoleColor.Yellow);

            if (result.Equals(0)) //change
            {
                int count = EnterNumber(posX + 11, posY, true);

                if (count > 0) { orderBasket.ModifyCountOrderItem(orderItem, count); }
            }
            else if (result.Equals(1)) //delete
            {
                orderBasket.DeleteOrderItem(orderItem);
            }
        }

        public static void AddingToCart(Product product, int posX, int posY)
        {
            CursorVisible = false;

            WriteText($"add:", posX, posY, ConsoleColor.Yellow);
            int count = EnterNumber(posX + 5, posY - 1, true);

            OrderBasketRepository orderBasket = new();
            if (count > 0) { orderBasket.AddOrderItem(new OrderItem(product, count)); }

            if (product is Pizza pizza)
            {
                if (count > 1)
                {
                    WriteText($"Added {count} {pizza.Crust.ToLower()} crust pizzas {pizza.Name}" +
                        $" size {pizza.Size}сm.",
                        5, 12, ConsoleColor.Blue);
                }
                else if (count == 1)
                {
                    WriteText($"Added {count} {pizza.Crust.ToLower()} crust pizza {pizza.Name}" +
                        $" size {pizza.Size}сm.",
                        5, 12, ConsoleColor.Blue);
                }
            }
            else if (product is Drink drink)
            {
                if (count > 1)
                {
                    WriteText($"Added {count} drinks {drink.Name} valume {drink.Volume}l.",
                        5, 12, ConsoleColor.Blue);
                }
                else if (count == 1)
                {
                    WriteText($"Added {count} drink {drink.Name} valume {drink.Volume}l.",
                        5, 12, ConsoleColor.Blue);
                }
            }

            if (count != 0) { ReadKey(); }
        }
        #endregion

        public static void Gratitude()
        {
            Clear();
            CreateGraphic(Graphic.Logo, ConsoleColor.DarkMagenta, 0, 0);
            CreateGraphic(Graphic.ThanksForWatching, ConsoleColor.Magenta, 0, 9);
            CreateGraphic(Graphic.AuthorSlogan, ConsoleColor.White, 16, 8);
            ReadKey();
        }
    }
}