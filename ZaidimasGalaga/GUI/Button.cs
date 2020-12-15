using System;
using System.Collections.Generic;
using System.Text;

namespace ZaidimasGalaga.GUI
{
    class Button : GuiObject
    {
        public string Label
        {
            get { return _textLine.Label; }
            set { _textLine.Label = value; }
        }
        
        private Frame _notActiveFrame;
        private Frame _activeFrame;


        private bool _isActive = false;
        private TextLine _textLine;

        
        public bool IsActive 
        { 
            get { return _isActive; } 
            set { _isActive = value; 
                Render(); }
        }

        public Button(int x, int y, int width, int height, string buttonText) : base(x, y, width, height)
        {
            _notActiveFrame = new Frame(x, y, width, height, '+');
            _activeFrame = new Frame(x, y, width, height, '#');

            _textLine = new TextLine(x + 1, y + 1 + ((height - 2) / 2), width - 2, buttonText);
        }

        public  void Render()
        {
            if (_isActive)
            {
                _activeFrame.Render();
            }
            else
            {
                _notActiveFrame.Render();
            }

            _textLine.Render();
        }

        
    }
}
