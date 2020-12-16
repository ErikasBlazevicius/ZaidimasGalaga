using System;
using System.Collections.Generic;
using System.Text;

namespace ZaidimasGalaga.Units
{
     class Ship : Unit
    {
        public Ship (int x, int y, string viewUnit) : base(x, y, viewUnit)
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
