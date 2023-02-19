using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mishbetzet
{
    internal class BasicGameObject : GameObject, IMovable
    {
        public BasicGameObject(Actor actor, int movementRange = 0, bool blocksMovement = false) : base(actor, movementRange, blocksMovement)
        {
        }
    }
}
