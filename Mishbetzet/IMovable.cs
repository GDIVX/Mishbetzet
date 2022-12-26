using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mishbetzet
{
    internal interface IMovable
    {
        bool isMoving { get; set; } //a way to check if the game object is stationary?

        public abstract void Move();
    }
}
