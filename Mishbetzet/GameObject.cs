using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mishbetzet
{
    internal class GameObject
    {
        Tile _tile;

        public Tile Tile { get => _tile; set => _tile = value; }
    }
}
