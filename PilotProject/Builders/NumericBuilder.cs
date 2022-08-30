using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace PilotProject.Builders
{
    public sealed class NumericBuilder : ControlHandlerBuilder
    {
        public Range ItemsRange { get; set; }

        public NumericBuilder(int posX, int posY, bool quitOn) : base(posX, posY, quitOn)
        {           
        }

        public override void ResetSelectIndex() => _selectedIndex = ItemsRange.Start.Value;


        public int RunNumeric(bool horizontalArrow)
        {
            ResetSelectIndex();
            bool IsChose = false;

            switch (horizontalArrow)
            {
                case true: DrawNumericHotizontal(_selectedIndex); break;
                case false: DrawNumericVertical(_selectedIndex); break;
            }

            while (!IsChose)
            {
                ConsoleKeyInfo keyInfo = ReadKey(true);
                ConsoleKey keyPressed = keyInfo.Key;

                if (keyPressed.Equals(horizontalArrow ? ConsoleKey.RightArrow : ConsoleKey.UpArrow))
                {
                    _selectedIndex++;

                    if (_selectedIndex == ItemsRange.End.Value + 1)
                    {
                        _selectedIndex = ItemsRange.Start.Value;
                    }

                }
                else if (keyPressed.Equals(horizontalArrow ? ConsoleKey.LeftArrow : ConsoleKey.DownArrow))
                {
                    _selectedIndex--;

                    if (_selectedIndex < ItemsRange.Start.Value)
                    {
                        _selectedIndex = ItemsRange.End.Value;
                    }
                }
                else if (keyPressed.Equals(ConsoleKey.Escape) && _quitOn) // quit
                {
                    _selectedIndex = ItemsRange.Start.Value - 1;
                    IsChose = true;
                }
                else if (keyPressed.Equals(ConsoleKey.Enter)) // choise
                {
                    IsChose = true;
                }

                switch (horizontalArrow)
                {
                    case true: DrawNumericHotizontal(_selectedIndex); break;
                    case false: DrawNumericVertical(_selectedIndex); break;
                }
            }

            return _selectedIndex;
        }

        private void DrawNumericVertical(int index)
        {
            for (int i = 0; i < 3; i++)
            {
                SetCursorPosition(_posX, _posY + i);
                switch (i)
                {
                    case 0: ForegroundColor = ConsoleColor.Green; WriteLine('▲'); break;
                    case 1: ForegroundColor = ConsoleColor.Yellow; WriteLine($"{index}{new string(' ', BufferWidth)}"); break;
                    case 2: ForegroundColor = ConsoleColor.Green; WriteLine('▼'); break;
                }

            }
        }

        private void DrawNumericHotizontal(int index)
        {
            SetCursorPosition(_posX, _posY);
            ForegroundColor = ConsoleColor.Green;
            WriteLine($"{'◄'} {index} {'►'}{new string(' ', BufferWidth)}");
        }      
    }
}
