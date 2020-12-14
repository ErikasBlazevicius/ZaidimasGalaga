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
            myGame = new GameScreen(30, 20);

            // uzpildo zaidima duomenemis
            myGame.SetShip(new Ship(5, 5, "@"));
            Random rnd = new Random();
            int enemyCount = 0;
            for (int i = 0; i < 10; i++)
            {
                myGame.AddEnemy(new Enemy(enemyCount, rnd.Next(0, 10), rnd.Next(0, 10), "$"));
                enemyCount++;
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

                myGame.MoveAllEnemiesDown();

                myGame.Render();

                // padaro pause ir parodo ekrana.
                System.Threading.Thread.Sleep(250);
            } while (needToRender);
        }
    }
}

