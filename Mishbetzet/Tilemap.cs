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

        // I think we should name x and y width and height, i can find myself confused from time to time so i guess clients will do so too
        public Tile GetTile(int x, int y)
        {
            //TODO check if x and y are in bounds
            return _tiles[x, y];
        }
    }
}
