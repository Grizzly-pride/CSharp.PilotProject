using static System.Console;

namespace PilotProject.Builders
{
    public sealed class MenuBuilder : ControlHandlerBuilder
    {
        private readonly int _limitUp;
        private readonly int _limitDown;

        public List<object> ItemsMenu { get; set; }

        public MenuBuilder(int posX, int posY, bool quitOn) : base(posX, posY, quitOn)
        {
            _limitUp = 0;
            _limitDown = 0;
            _selectedIndex = 0;
        }
       
        public MenuBuilder(int posX, int posY, int limitUp, int limitDown, bool quitOn) : base(posX, posY, quitOn) 
        {
            _limitUp = limitUp;
            _limitDown = limitDown;
            _selectedIndex = limitUp;        
        }

        public override void ResetSelectIndex() => _selectedIndex = _limitUp;

  
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

        private void DrawMenu()
        {
            char pointer = ' ';


            for (int i = 0; i < ItemsMenu.Count; i++)
            {
                SetCursorPosition(_posX, _posY + i);
                ForegroundColor = ConsoleColor.Green;
                if (i == _selectedIndex)
                {
                    ForegroundColor = ConsoleColor.Yellow;
                    pointer = '►';
                }

                Write($"{pointer} {ItemsMenu[i]}");
                pointer = ' ';
                ResetColor();
            }        
        }        
    }
}