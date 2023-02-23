using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mishbetzet.TileObject;

namespace Mishbetzet
{
    internal interface IMovable
    {

        /// <summary>
        /// Method that will attempt to step in a certin direction
        /// </summary>
        /// <param name="direction">The attempted step direction</param>
        /// <returns></returns>
        public abstract bool TryStep(Point direction);

        /// <summary>
        /// Move the player towards a destination
        /// </summary>
        /// <param name="position">The desired destination in the tilemap</param>
        public void Move(Point position)
        {
            int steps = 0;
            while (TryStep(position))
            {
                if (steps < 20)
                {
                    steps++;
                }
                else
                {
                    break;
                }
            }
        }
    }
}