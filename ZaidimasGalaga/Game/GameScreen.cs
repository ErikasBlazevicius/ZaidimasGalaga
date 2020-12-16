using System;
using System.Collections.Generic;
using ZaidimasGalaga.Units;

namespace ZaidimasGalaga.Game
{
    class GameScreen
    {
        private int enemyCount = 0;
        private Random rnd = new Random();
        private const int enemyMoveFrequency = 1;

        private int _width;
        private int _height;

        private Ship _ship;
        private List<Enemy> _enemies = new List<Enemy>();
        private int maxEnemiesAllowed = 20;

        private int enemyMoveStep = enemyMoveFrequency;

        public GameScreen(int width, int height)
        {
            _width = width;
            _height = height;
        }

        public void SetShip(Ship ship)
        {
            this._ship = ship;
        }


        public void MoveShipLeft()
        {
            if (_ship.GetX() > 0)
            {
                _ship.MoveLeft();
            }
        }

        public void MoveShipRight()
        {
            if (_ship.GetX() < _width)
            {
                _ship.MoveRight();
            }
        }


        internal void AddRandomEnemy()
        {
            _enemies.Add(new Enemy(enemyCount, rnd.Next(0, _width), rnd.Next(0, 5), "$"));
            enemyCount++;
        }

      

        //enemy move steep maziname kiekviena zingsni, kai pasiekia 0 - enemy pajuda ir vel statome i max (enemy move frequency
        private void MoveAllEnemiesDown()  
        {
            if (enemyMoveStep <= 0)
            {
                foreach (Enemy enemy in _enemies)
                {
                    enemy.MoveDown();
                }
                enemyMoveStep = enemyMoveFrequency;
            }
            else
            {
                enemyMoveStep--;
            }
            
        }

        public Enemy GetEnemyById(int id)
        {
            foreach (Enemy enemy in _enemies)
            {
                if (enemy.GetId() == id)
                {
                    return enemy;
                }
            }

            return null;
        }

        internal void IncreaseEnemyMax()
        {
            maxEnemiesAllowed++;
        }

        public void Render()
        {
            foreach (Enemy enemy in _enemies)
            {
                enemy.Render();
            }
            _ship.Render();
        }

        internal void SpawnEnemies()
        {
            if (_enemies.Count < maxEnemiesAllowed)
            {
                AddRandomEnemy();
            }
        }

        internal void ActivateEnemies()
        {
            MoveAllEnemiesDown();
            RemoveEnemiesOutOfScreen();
        }

        private void RemoveEnemiesOutOfScreen()
        {
            for (int i = 0; i < _enemies.Count; i++)
            {
                if (_enemies[i].Y > _height)
                {
                    RemoveEnemy(_enemies[i]);
                    i--;
                }
            }
        }

        private void RemoveEnemy(Enemy enemy)
        {
            _enemies.Remove(enemy);
        }

        //private void RemoveEnemyById(int id)
        //{
        //    for (int i = 0; i < _enemies.Count; i++)
        //    {
        //        if (_enemies[i].GetId()==id)
        //        {
        //            _enemies.RemoveAt(i);
        //        }

        //    }
        //}
    }
}
