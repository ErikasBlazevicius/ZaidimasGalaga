using System;
using System.Collections.Generic;
using System.Text;
using ZaidimasGalaga.Units;

namespace ZaidimasGalaga.Game
{
    class GameController
    {
        private GameScreen myGame;
        private int increaseCounter = 0;
        private int increaeTimeGaps = 30;

        public void StartGame()
        {

            // pasileidzia zaidimas
            InitGame();

            // render loop
            StartGameLoop();
        }

        private void InitGame()
        {
            int gameWidth = 70;
            int gameHeigth = 20;

            myGame = new GameScreen(gameWidth, gameHeigth);

            // uzpildo zaidima duomenemis
            myGame.SetShip(new Ship(gameWidth/2, gameHeigth -2, "@"));
           
            for (int i = 0; i < 10; i++)
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

                if (increaseCounter > increaeTimeGaps)
                {
                    myGame.IncreaseEnemyMax();
                    increaseCounter = 0;

                }
               

                myGame.Render();

                // padaro pause ir parodo ekrana.
                System.Threading.Thread.Sleep(250);
            } while (needToRender);
        }
    }
}

