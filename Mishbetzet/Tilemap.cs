using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mishbetzet
{
    internal class Tilemap : IEnumerable<int>
    {
        Tile[,] _tiles;
        Dictionary<Tile, int> index; //implementation for int index?
                                     //every tile has an int key in the tilemap instead of on the tile itself

        public int Width { get => _tiles.GetLength(0); }
        public int Height { get => _tiles.GetLength(1); }

        public Tilemap(int width, int height)
        {
            _tiles = new Tile[width, height];

            int count = 0;
            for (int i = 0; i < width; i++;)
            {
                for (int j = 0; j < height; j++;)
                {
                    index.Add(new Point(j, i), count);
                    count++;
                }
            }
        }

        public Tile GetTile(int x, int y)
        {
            //TODO check if x and y are in bounds
            return _tiles[x, y];
        }

        public IEnumerator<int> GetEnumerator()
        {
            for(int = _tiles.Length)
            {

            }
            //foreach(Tile tile in _tiles)
            //{
            //    yield return tile;
            //}
        }

        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    for (int i = _tiles.Length; i >= 0; i--;)
        //    {
                
        //    }
        //}
    }
}
