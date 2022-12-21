using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mishbetzet
{
    internal class Tilemap
    {
        Tile[,] _tiles;

        public int Width { get => _tiles.GetLength(0); }
        public int Height { get => _tiles.GetLength(1); }

        public Tilemap(int width, int height)
        {
            _tiles = new Tile[width, height];
        }

        public Tile GetTile(int x, int y)
        {
            //TODO check if x and y are in bounds
            return _tiles[x, y];
        }
    }
}
