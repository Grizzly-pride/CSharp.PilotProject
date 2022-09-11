using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace PilotProject.Builders
{
    internal class TextericBuilder : ControlHandlerBuilder
    {
        public List<string> ItemsText { get; set; }
        private int CleanSpace => ItemsText.Select(x => x.Length).Max();

        public TextericBuilder(int posX, int posY, bool quitOn) : base(posX, posY, quitOn)
        {
        }

        public override void ResetSelectIndex() => _selectedIndex = 0;


        public int RunTexteric(Mod mod)
        {
            bool IsChose = false;
            ResetSelectIndex();

            switch (mod)
            {
                case Mod.Vertical: DrawTextericVertical(_selectedIndex); break;
                case Mod.Horizontal: DrawTextericHotizontal(_selectedIndex); break;
            }

            while (!IsChose)
            {
                ConsoleKeyInfo keyInfo = ReadKey(true);
                ConsoleKey keyPressed = keyInfo.Key;

                if (keyPressed.Equals(mod.Equals(Mod.Horizontal) ? ConsoleKey.RightArrow : ConsoleKey.UpArrow))
                {
                    _selectedIndex++;

                    if (_selectedIndex == ItemsText.Count)
                    {
                        _selectedIndex = 0;
                    }

                }
                else if (keyPressed.Equals(mod.Equals(Mod.Horizontal) ? ConsoleKey.LeftArrow : ConsoleKey.DownArrow))
                {
                    _selectedIndex--;

                    if (_selectedIndex < 0)
                    {
                        _selectedIndex = ItemsText.Count - 1;
                    }
                }
                else if (keyPressed.Equals(ConsoleKey.Escape) && _quitOn) // quit
                {
                    _selectedIndex =  - 1;
                    IsChose = true;
                }
                else if (keyPressed.Equals(ConsoleKey.Enter)) // choise
                {
                    IsChose = true;
                }

                if(_selectedIndex >= 0)
                {
                    switch (mod)
                    {
                        case Mod.Vertical: DrawTextericVertical(_selectedIndex); break;
                        case Mod.Horizontal: DrawTextericHotizontal(_selectedIndex); break;
                    }
                }

            }

            return _selectedIndex;
        }

        private void DrawTextericVertical(int index)
        {            

            for (int i = 0; i < 3; i++)
            {
                SetCursorPosition(_posX, _posY + i);
                switch (i)
                {
                    case 0: ForegroundColor = ConsoleColor.Green; WriteLine('▲'); break;
                    case 1: ForegroundColor = ConsoleColor.Yellow; WriteLine($"{ItemsText[index]}{new string(' ', CleanSpace)}"); break;
                    case 2: ForegroundColor = ConsoleColor.Green; Write('▼'); break;
                }
            }
        }

        private void DrawTextericHotizontal(int index)
        {
            SetCursorPosition(_posX, _posY);
            ForegroundColor = ConsoleColor.Green;
            Write($"{'◄'} {ItemsText[index]} {'►'}{new string(' ', CleanSpace)}");

        }
    }
}