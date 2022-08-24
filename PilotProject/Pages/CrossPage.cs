using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using PilotProject.Builders;

namespace PilotProject.Pages
{
    internal static class CrossPage
    {
        public static void Title(string title, int moveTitle, ConsoleColor color)
        {
            ForegroundColor = color;
            WriteLine($"{new string(' ', moveTitle)} {title}\n");
        }

        public static bool YesOrNo(int y, int x)
        {
            ResetColor();
            CursorVisible = false;

            MenuBuilder menu = new(y, x, false)
            {
                ItemsMenu = new(2) { "Yes", "No" }
            };

            return menu.RunMenu() == 0;
        }


        public static int EnterNumber(int posX, int posY)
        {
            CursorTop = Math.Abs(posX);
            CursorLeft = Math.Abs(posY);

            ResetColor();
            CursorVisible = true;

            return Read();
        }


    }
}