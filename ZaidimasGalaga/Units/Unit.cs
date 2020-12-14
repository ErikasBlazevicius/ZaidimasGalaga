using System;
using System.Collections.Generic;
using System.Text;

namespace ZaidimasGalaga.Units
{
    class Unit
    {
        protected int X;
        protected int Y;
        private string _representation;

        public Unit(int x, int y, string representation)
        {
            X = x;
            Y = y;
            _representation = representation;
        }

        public void PrintInfo()
        {
            Console.WriteLine($" Unit {_representation} is at {X}x{Y}");
        }
        public void Render()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(_representation);
        }
    }
}
