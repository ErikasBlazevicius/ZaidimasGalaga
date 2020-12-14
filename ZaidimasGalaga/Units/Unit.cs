﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ZaidimasGalaga.Units
{
    class Unit
    {
        protected int X;
        protected int Y;
        private string _viewUnit;

        public Unit(int x, int y, string viewUnit)
        {
            X = x;
            Y = y;
            _viewUnit = viewUnit;
        }

        public void PrintInfo()
        {
            Console.WriteLine($" Unit {_viewUnit} is at {X}x{Y}");
        }
        public void Render()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(_viewUnit);
        }
    }
}
