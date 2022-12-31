using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mishbetzet
{
    public class GameObject
    {
        Tile _currentTile;

        public Tile Tile { get => _currentTile; set => _currentTile = value; }

    }
}
