using System;
using System.Collections.Generic;
using System.Text;

namespace ZaidimasGalaga.Units
{
     class Ship : Unit
    {
        public Ship (int x, int y, string representation) : base(x, y, representation)
        {
        }

        public void MoveRight()
        {
            X++;
        }

        public void MoveLeft()
        {
            X--;
        }

        public int GetX()
        {
            return X;
        }

      
    }
}
