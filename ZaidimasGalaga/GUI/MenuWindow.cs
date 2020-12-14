using System;
using System.Collections.Generic;
using System.Text;

namespace ZaidimasGalaga.GUI
{
    class MenuWindow : Window
    {
   
        private TextBlock _titleTextBlock;

        private int _activeButtonNr;

        public int ActiveButtonNr
        {
            get
            {
                return _activeButtonNr;
            }
            private set
            {
                _menuButtons[_activeButtonNr].IsActive = false; //sena reiksme padarome false
                _activeButtonNr = value;                        //issisaugom nauja reiksme ir padarom ja true
                _menuButtons[_activeButtonNr].IsActive = true;  
            }
        }

        private List<Button> _menuButtons = new List<Button>(); //naudojamu mygtuku sarasas


        public MenuWindow() : base(0, 0, 120, 30, '%')
        {
            _titleTextBlock = new TextBlock(10, 5, 100, new List<String> { "Zaidimas Galaga" });
            //pridedam mygtukus i sarasa 
            _menuButtons.Add(new Button(20, 13, 18, 5, "Start"));
            _menuButtons.Add(new Button(50, 13, 18, 5, "Credits"));
            _menuButtons.Add(new Button(80, 13, 18, 5, "Quit"));
            ActiveButtonNr = 0;


            
            //_startButton.SetActive();

            
        }

        public void Render()
        {
            base.Render();

            _titleTextBlock.Render();
            foreach (Button button in _menuButtons)
            {
                button.Render();
            }

            Console.SetCursorPosition(0, 0);
        }

        internal void GoRight()
        {
            if (_activeButtonNr < _menuButtons.Count -1)
            {
                ActiveButtonNr++;
            }
            else
            {
                ActiveButtonNr = 0;
            }
        }

        internal void GoLeft()
        {
            if (_activeButtonNr > 0)
            {
                ActiveButtonNr--;
            }
            else
            {
                ActiveButtonNr = _menuButtons.Count - 1;
            }
        }
    }
}
