﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mishbetzet
{
    internal class BasicGameObject : GameObject
    {
        public BasicGameObject(Actor actor) : base(actor)
        {
        }

        public override void Step(Point direction)
        {
            throw new NotImplementedException();
        }


    }
}
