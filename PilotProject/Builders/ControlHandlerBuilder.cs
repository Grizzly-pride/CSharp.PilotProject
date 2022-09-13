using static System.Console;

namespace PilotProject.Builders
{
    public abstract class ControlHandlerBuilder
    {
        protected int _selectedIndex;
        protected bool _quitOn;

        protected int _posX;
        protected int _posY;
        
        public ControlHandlerBuilder(int posX, int posY, bool quitOn)
        {
            _posX = posX;
            _posY = posY;
            _quitOn = quitOn;
        }

        public abstract void ResetSelectIndex();

        public void SetCursorVisible(bool visible) => CursorVisible = visible;

        protected void SetCursorPosition(int posX, int posY)
        {            
            CursorLeft = Math.Abs(posX);
            CursorTop = Math.Abs(posY);           
        }
    }
}