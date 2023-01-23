using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mishbetzet
{
    internal class SpiralEnumerator<Tile> : IEnumerator<Tile>
    {
        int loopAmount; // amount of times to spiral around the tilemap
        int currentLoop = 0; //what current loop its on
        int stepsPerDirection = 1;
        int currentStep = 0;
        int direction = 0; //0 left, 1 up, 2 right, 3 down
        
        int x, y; //tile position in map
        Tile[,] map;

        public SpiralEnumerator(Tile[,] map)
        {
            this.map = map;
            
            //size of tilemap
            int width = map.GetLength(0);
            int height = map.GetLength(1);
            
            //start at center-ish of map
            x = width/2;
            y = height/2;
            
            //if height is longer than or equal to the width it should do 1 more loop.
            loopAmount = height / 2 >= width / 2 ? height / 2 + 1: width / 2;

        }

        public Tile Current => map[x, y];

        public bool MoveNext()
        {
            if(loopAmount < currentLoop)
            {
                return false;
            }

            if(currentStep == stepsPerDirection)
            {
                direction++;
                if(direction % 2 == 0)
                {
                    stepsPerDirection++;
                    if (direction % 4 == 0)
                    {
                        direction = 0;
                        currentLoop++;
                    }
                }
                currentStep = 0;
            }
            else
            {
                currentStep++;
                switch(direction)
                {
                    case 0:
                        x--;
                        break;
                    case 1:
                        y++;
                        break;
                    case 2:
                        x++;
                        break;
                    case 3:
                        y--;
                        break;
                }
                
            }

            return true;

        }


        object IEnumerator.Current => Current;

        public void Dispose() { }

        public void Reset() { }
    }
}
