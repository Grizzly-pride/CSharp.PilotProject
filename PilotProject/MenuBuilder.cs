using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace PilotProject
{
    internal class MenuBuilder
    {
        private int _selectedIndex;
        private int _limitUp;
        private int _limitDown;

        private readonly int drawMenuColumnPos;
        private readonly int drawMenuRowPos;
        public List<object> ItemsMenu { get; set; }

        public MenuBuilder(int row, int col, int selectedIndex, int limitUp, int limitDown)
        {

            _selectedIndex = selectedIndex;
            _limitUp = limitUp;
            _limitDown = limitDown;
            drawMenuRowPos = row;
            drawMenuColumnPos = col;
        }

        public MenuBuilder(int row, int col)
        {
            _selectedIndex = 0;
            _limitUp = -1;
            _limitDown = 0;
            drawMenuRowPos = row;
            drawMenuColumnPos = col;
        }

        public void ResetCursorVisible()
        {
            CursorVisible = CursorVisible != true;
        }
        
        public void SetCursorPosition(int row, int column)
        {
            if (row > 0)
            {
                CursorTop = row;
            }

            if (column > 0)
            {
                CursorLeft = column;
            }
        }
        
        private void DrawMenu()
        {
            char pointer = ' ';

            for (int i = 0; i < ItemsMenu.Count; i++)
            {
                SetCursorPosition(drawMenuRowPos + i, drawMenuColumnPos);
                ForegroundColor = ConsoleColor.Green;
                if (i == _selectedIndex)
                {
                    ForegroundColor = ConsoleColor.Yellow;
                    pointer = '►';
                }

                WriteLine($"{pointer}  {ItemsMenu[i]}");
                pointer = ' ';

                ResetColor();
            }
        }

        public int RunMenu()
        {
            bool IsChose = false;
            DrawMenu();
            /*
            while (!IsChose)
            {
                ConsoleKeyInfo keyInfo = ReadKey(true);
                ConsoleKey keyPressed = keyInfo.Key;

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
                DrawMenu();
            }

            return selectedIndex;
            */
            int limUp = Math.Abs(_limitUp);
            int limDown = Math.Abs(_limitDown);

            while (!IsChose)
            {
                ConsoleKeyInfo keyInfo = ReadKey(true);
                ConsoleKey keyPressed = keyInfo.Key;

                if (keyPressed.Equals(ConsoleKey.UpArrow))
                {
                    _selectedIndex--;

                    if (_selectedIndex.Equals(limUp))
                    {
                        _selectedIndex = ItemsMenu.Count - (1 + limDown);
                    }

                }
                else if (keyPressed.Equals(ConsoleKey.DownArrow))
                {
                    _selectedIndex++;

                    if (_selectedIndex.Equals(ItemsMenu.Count - limDown))
                    {
                        _selectedIndex = limUp + 1;
                    }
                }
                else if (keyPressed.Equals(ConsoleKey.Enter))
                {
                    IsChose = true;
                }
                DrawMenu();
            }

            return _selectedIndex;
        }

        public void ResetSelectIndex() => _selectedIndex = 0;
    }
}
