using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace PilotProject
{
    internal sealed class InputHandler
    {
        private int selectedIndex = 0;
        private ConsoleKey keyPressed;
        public bool IsChose { get; private set; }
        public List<object> ItemsMenu { get; set; } 

        private void UpdateItems()
        {
            for (int i = 0; i < ItemsMenu.Count; i++)
            {
                string? currentItem = ItemsMenu[i].ToString();
                char pointer;

                if (i.Equals(selectedIndex))
                {
                    pointer = '►';
                    ForegroundColor = ConsoleColor.Yellow;
                }
                else
                {
                    pointer = ' ';
                    ForegroundColor = ConsoleColor.Green;
                }
                WriteLine(" " + pointer + " " + currentItem);
            }
        }

       
        public void SelectionControl()
        {          
            UpdateItems();

            ConsoleKeyInfo keyInfo = ReadKey(true);
            keyPressed = keyInfo.Key;
            IsChose = false;

            if (keyPressed.Equals(ConsoleKey.UpArrow))
            {
                selectedIndex--;

                if (selectedIndex.Equals(-1))
                {
                    selectedIndex = ItemsMenu.Count - 1;
                }
            }
            else if (keyPressed.Equals(ConsoleKey.DownArrow))
            {
                selectedIndex++;

                if (selectedIndex.Equals(ItemsMenu.Count))
                {
                    selectedIndex = 0;
                }
            }
            else if (keyPressed.Equals(ConsoleKey.Enter))
            {
                IsChose = true;
            }
            
        }

        public int GetSelectIndex()
        {
            return selectedIndex;
        }

        public void ResetSelectIndex() => selectedIndex = 0;
    }
}