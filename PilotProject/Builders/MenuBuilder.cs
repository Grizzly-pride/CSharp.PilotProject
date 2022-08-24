using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace PilotProject.Builders
{
    internal class MenuBuilder
    {
        private int _selectedIndex;
        private int _limitUp;
        private int _limitDown;
        private bool _quitOn;

        private readonly int _posY;
        private readonly int _posX;
        public List<object> ItemsMenu { get; set; }

        public MenuBuilder(int row, int col, int limitUp, int limitDown, bool quitOn)
        {
            _limitUp = limitUp;
            _limitDown = limitDown;
            _selectedIndex = limitUp;
            _quitOn = quitOn;
            _posX = row;
            _posY = col;
            
        }

        public MenuBuilder(int posX, int posY, bool quitOn)
        {
            _limitUp = 0;
            _limitDown = 0;
            _selectedIndex = 0;
            _quitOn = quitOn;
            _posX = posX;
            _posY = posY;
        }

        public void SetCursorVisible(bool visible) => CursorVisible = visible;
       
        public void SetCursorPosition(int posX, int posY)
        {
            CursorTop = Math.Abs(posX);
            CursorLeft = Math.Abs(posY);
        }
        
        private void DrawMenu()
        {
            char pointer = ' ';

            for (int i = 0; i < ItemsMenu.Count; i++)
            {
                SetCursorPosition(_posX + i, _posY);
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

            int limUp = Math.Abs(_limitUp);
            int limDown = Math.Abs(_limitDown);

            while (!IsChose)
            {
                ConsoleKeyInfo keyInfo = ReadKey(true);
                ConsoleKey keyPressed = keyInfo.Key;

                if (keyPressed.Equals(ConsoleKey.UpArrow)) // move up
                {
                    _selectedIndex--;

                    if (_selectedIndex < limUp)
                    {
                        _selectedIndex = ItemsMenu.Count - (1 + limDown);
                    }
                }
                else if (keyPressed.Equals(ConsoleKey.DownArrow)) //move down
                {
                    _selectedIndex++;

                    if (_selectedIndex.Equals(ItemsMenu.Count - limDown))
                    {
                        _selectedIndex = limUp;
                    }
                }
                else if (keyPressed.Equals(ConsoleKey.Escape) && _quitOn) // quit
                {
                    _selectedIndex = -1 + limUp;
                    IsChose = true;
                }
                else if (keyPressed.Equals(ConsoleKey.Enter)) // choise
                {
                    IsChose = true;
                }
                DrawMenu();
            }

            return _selectedIndex - limUp;
        }

        public void ResetSelectIndex() => _selectedIndex = _limitUp;
    }
}
