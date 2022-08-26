using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace PilotProject.Builders
{
    public abstract class ControlHandlerBuilder
    {
        protected int _selectedIndex;
        protected bool _quitOn;

        protected int _posY;
        protected int _posX;

        public ControlHandlerBuilder(int posX, int posY, bool quitOn)
        {
            _posX = posX;
            _posY = posY;
            _quitOn = quitOn;
        }

       
        public void SetCursorVisible(bool visible) => CursorVisible = visible;

        public void SetCursorPosition(int posX, int posY)
        {
            CursorTop = Math.Abs(posX);
            CursorLeft = Math.Abs(posY);
        }

        public abstract void ResetSelectIndex();


    }
}
