using System;
using System.Collections.Generic;
using System.Text;
using ZaidimasGalaga.Units;

namespace ZaidimasGalaga.Game
{
    class GameController
    {
        private GameScreen myGame;

        public void StartGame()
        {

            // pasileidzia zaidimas
            InitGame();

            // render loop
            StartGameLoop();
        }

        private void InitGame()
        {
            int gameWidth = 90;
            int gameHeigth = 20;

            myGame = new GameScreen(gameWidth, gameHeigth);

            // uzpildo zaidima duomenemis
            myGame.SetShip(new Ship(gameWidth/2, gameHeigth -2, "@"));
           
            for (int i = 0; i < 20; i++)
            {   
                myGame.AddRandomEnemy();  
            }
        }

        private void StartGameLoop()
        {
            bool needToRender = true;

            do
            {
                // isvalom ekrana
                Console.Clear();

                while (Console.KeyAvailable)
                {
                    ConsoleKeyInfo pressedChar = Console.ReadKey(true);
                    int hashCode = pressedChar.Key.GetHashCode();

                    switch (pressedChar.Key)
                    {
                        case ConsoleKey.Escape:
                            needToRender = false;
                            break;
                        case ConsoleKey.RightArrow:
                            myGame.MoveShipRight();
                            break;
                        case ConsoleKey.LeftArrow:
                            myGame.MoveShipLeft();
                            break;
                    }
                }

                myGame.ActivateEnemies();

                myGame.SpawnEnemies();
               

                myGame.Render();

                // padaro pause ir parodo ekrana.
                System.Threading.Thread.Sleep(250);
            } while (needToRender);
        }
    }
}

