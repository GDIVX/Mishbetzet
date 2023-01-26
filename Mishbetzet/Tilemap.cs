using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mishbetzet
{
    public class Tilemap : IEnumerable<Tile>
    {
        Tile[,] _tiles;

        public int Width { get => _tiles.GetLength(0); }
        public int Height { get => _tiles.GetLength(1); }

        internal Tilemap(int width, int height)
        {
            _tiles = new Tile[width, height];
        }


        #region Tiles Accessors
        public Tile? this[int x, int y]
        {
            get => GetTile(x, y);
        }

        public Tile? GetTile(Point point)
        {
            return this[point.X, point.Y];
        }

        #endregion

        /// <summary>
        /// Return a tile in index x,y
        /// </summary>
        /// <param name="x">width index</param>
        /// <param name="y">hight index</param>
        /// <returns>A tile in index x,y, or null if index is not valid</returns>
        Tile? GetTile(int x, int y)
        {
            if (x < 0 || x >= Width || y < 0 || y >= Height)
                return null;
            return _tiles[x, y];
        }

        /// <summary>
        /// Create and add a tile in index x,y
        /// </summary>
        /// <param name="x">width index</param>
        /// <param name="y">hight index</param>
        public void AddTile(Tile tile)
        {
            if (tile.Position.X < 0 || tile.Position.X >= Width
                || tile.Position.Y < 0 || tile.Position.Y >= Height)
                return;

            _tiles[tile.Position.X, tile.Position.Y] = tile;
        }

        public IEnumerator<Tile> GetEnumerator()
        {
            return SpiralEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<Tile> SpiralEnumerator()
        {
            int x = 0;
            int y = 0;
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
