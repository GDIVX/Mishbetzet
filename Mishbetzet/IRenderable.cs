﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mishbetzet
{
    internal interface IRenderable
    {
        public Point RednerablePoint { get; }

        public void RenderObject();

    }
}
