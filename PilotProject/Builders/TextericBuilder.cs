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


        public int RunTexteric()
        {
            bool IsChose = false;
            ResetSelectIndex();
            DrawTexteric(_selectedIndex);

            while (!IsChose)
            {
                ConsoleKeyInfo keyInfo = ReadKey(true);
                ConsoleKey keyPressed = keyInfo.Key;

                if (keyPressed.Equals(ConsoleKey.UpArrow))
                {
                    _selectedIndex++;

                    if (_selectedIndex == ItemsText.Count)
                    {
                        _selectedIndex = 0;
                    }

                }
                else if (keyPressed.Equals(ConsoleKey.DownArrow))
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

                if (_selectedIndex >= 0) { DrawTexteric(_selectedIndex); }
            }

            return _selectedIndex;
        }

        private void DrawTexteric(int index)
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
    }
}
