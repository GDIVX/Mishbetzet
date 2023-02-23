using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mishbetzet
{
    public class BasicTile : Tile
    {
        public BasicTile(Point position, string name) : base(position, name)
        {

        }

        public override string Name => "Base";
    }
}
