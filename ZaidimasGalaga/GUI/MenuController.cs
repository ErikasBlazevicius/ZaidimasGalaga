using System;
using System.Collections.Generic;
using System.Text;
using ZaidimasGalaga.Game;

namespace ZaidimasGalaga.GUI
{
    class MenuController
    {
        private readonly MenuWindow _menuWindow = new MenuWindow();
        private readonly CreditWindow _creditWindow = new CreditWindow();
        private readonly GameController myGame = new GameController();
        

        //sukuria Game Window (langeliai su "Credits", "New Game" ir t.t.
        public void ShowMenu()
        {
            ConsoleKeyInfo keyInfo;
            bool needToShowApp = true;
            do
            {
                _menuWindow.Render();
                do
                {
                    keyInfo = Console.ReadKey(true); //be true spaudziant random raides jos atviazduojamos vietoj "%" remelio formu (intercept paima paspaudima ir nespausdina i ekrana)
                } while (keyInfo.Key != ConsoleKey.Escape 
                        & keyInfo.Key != ConsoleKey.Enter
                        & keyInfo.Key != ConsoleKey.RightArrow
                        & keyInfo.Key != ConsoleKey.LeftArrow);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.Escape:
                        needToShowApp = false;
                        break;
                    case ConsoleKey.LeftArrow:
                        _menuWindow.GoLeft();
                        break;
                    case ConsoleKey.RightArrow:
                        _menuWindow.GoRight();
                        break;
                    case ConsoleKey.Enter:
                        int currentSelection = _menuWindow.ActiveButtonNr;
                        if(currentSelection == 0)
                        {
                            myGame.StartGame();
                        } 
                        else if(currentSelection == 1)
                        {
                            _creditWindow.Render();
                            Console.ReadKey();
                        }
                        else
                        {
                            needToShowApp = false;
                        }

                        break;
                    default:
                        break;

                }

            } while (needToShowApp);

            
            //_creditWindow.Render();
        }
    }
}
