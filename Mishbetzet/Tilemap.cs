using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mishbetzet
{
    internal class Tilemap : IEnumerable<Tile>
    {
        Tile[,] _tiles;
        Point startingTile;

        public int Width { get => _tiles.GetLength(0); }
        public int Height { get => _tiles.GetLength(1); }

        internal Tilemap(int width, int height)
        {
            startingTile = new Point(width/2, height/2);
            _tiles = new Tile[width, height];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    _tiles[x, y] = Tile.Create(x, y);
                }
            }
        }

        public Tile? this[int x, int y]
        {
            get => GetTile(x, y);
        }

        /// <summary>
        /// Return a tile in index x,y
        /// </summary>
        /// <param name="x">width index</param>
        /// <param name="y">hight index</param>
        /// <returns>A tile in index x,y, or null if index is not valid</returns>
        Tile? GetTile(int x, int y)
        {
            if (!IsValidTile(x, y)) return null;
            return _tiles[x, y];
        }

        /// <summary>
        /// Create and add a tile in index x,y
        /// </summary>
        /// <param name="x">width index</param>
        /// <param name="y">hight index</param>
        public void AddTile(int x, int y)
        {
            if (!IsValidTile(x, y)) return;
            var tile = Tile.Create(x, y);
            _tiles[x, y] = tile;
        }

        /// <summary>
        /// Check if the tilemap have a tile in index x,y
        /// </summary>
        /// <param name="x">width index</param>
        /// <param name="y">hight index</param>
        /// <returns>true if it is possible to access a tile in the given index</returns>
        public bool IsValidTile(int x, int y)
        {
            if (x >= 0 && x < _tiles.GetLength(0) && y >= 0 && y < _tiles.GetLength(1))
            {
                return true;
            }
            return false;
        }

        public IEnumerator<Tile> GetEnumerator()
        {
            
            //for (int i = 0; i < Height; i++)
            //{
            //    for (int j = 0; j < Width; j++)
            //    {
            //        yield return _tiles[j, i];
            //    }
            //}
            return SpiralEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<Tile> SpiralEnumerator()
        {
            int x = startingTile.X;
            int y = startingTile.Y;
            int steps = 1;
            int loop = Height > Width ? Height : Width;

            for (int l = 0; l < loop; l++)
            {
                yield return _tiles[x, y]; //checks initial tile
                for (int i = 0; i < steps; i++)
                {
                    x -= steps;
                    if (x < 0 || y < 0 || x >= Width || y >= Height)
                        yield return _tiles[x, y];
                }
                for (int i = 0; i < steps; i++)
                {
                    y -= steps;
                    if (x < 0 || y < 0 || x >= Width || y >= Height)
                        yield return _tiles[x, y];
                }

                steps++;

                for (int i = 0; i < steps; i++)
                {
                    x += steps;
                    if (x < 0 || y < 0 || x >= Width || y >= Height)
                        yield return _tiles[x, y];
                }
                for (int i = 0; i < steps; i++)
                {
                    y += steps;
                    if (x < 0 || y < 0 || x >= Width || y >= Height)
                        yield return _tiles[x, y];
                }

                steps++;
            }
        }


    }
}
