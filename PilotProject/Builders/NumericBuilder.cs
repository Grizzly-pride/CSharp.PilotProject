using static System.Console;

public enum Mod
{
    Vertical,
    Horizontal,
}

namespace PilotProject.Builders
{
    public sealed class NumericBuilder : ControlHandlerBuilder
    {
        public Range ItemsRange { get; set; }
        private int CleanSpace => ItemsRange.End.Value.ToString().Length;

        public NumericBuilder(int posX, int posY, bool quitOn) : base(posX, posY, quitOn)
        {           
        }

        public override void ResetSelectIndex() => _selectedIndex = ItemsRange.Start.Value;


        public int RunNumeric(Mod mod)
        {
            ResetSelectIndex();
            bool IsChose = false;

            switch (mod)
            {
                case Mod.Horizontal: DrawNumericHotizontal(_selectedIndex); break;
                case Mod.Vertical: DrawNumericVertical(_selectedIndex); break;
            }

            while (!IsChose)
            {
                ConsoleKeyInfo keyInfo = ReadKey(true);
                ConsoleKey keyPressed = keyInfo.Key;

                if (keyPressed.Equals(mod.Equals(Mod.Horizontal) ? ConsoleKey.RightArrow : ConsoleKey.UpArrow))
                {
                    _selectedIndex++;

                    if (_selectedIndex == ItemsRange.End.Value + 1)
                    {
                        _selectedIndex = ItemsRange.Start.Value;
                    }

                }
                else if (keyPressed.Equals(mod.Equals(Mod.Horizontal) ? ConsoleKey.LeftArrow : ConsoleKey.DownArrow))
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

                switch (mod)
                {
                    case Mod.Horizontal: DrawNumericHotizontal(_selectedIndex); break;
                    case Mod.Vertical: DrawNumericVertical(_selectedIndex); break;
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
                    case 1: ForegroundColor = ConsoleColor.Yellow; WriteLine($"{index}{new string(' ', CleanSpace)}"); break;
                    case 2: ForegroundColor = ConsoleColor.Green; Write('▼'); break;
                }
            }
        }

        private void DrawNumericHotizontal(int index)
        {
            SetCursorPosition(_posX, _posY);
            ForegroundColor = ConsoleColor.Green;
            Write($"{'◄'} {index} {'►'}{new string(' ', CleanSpace)}");

        }      
    }
}