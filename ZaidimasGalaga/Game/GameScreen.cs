﻿using System.Collections.Generic;
using ZaidimasGalaga.Units;

namespace ZaidimasGalaga.Game
{
    class GameScreen
    {
        private int _width;
        private int _height;

        private Ship _ship;
        private List<Enemy> _enemies = new List<Enemy>();

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

        public void AddEnemy(Enemy enemy)
        {
            _enemies.Add(enemy);
        }

        public void MoveAllEnemiesDown()
        {
            foreach (Enemy enemy in _enemies)
            {
                enemy.MoveDown();
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

        public void Render()
        {
            foreach (Enemy enemy in _enemies)
            {
                enemy.Render();
            }
            _ship.Render();
        }
    }
}
