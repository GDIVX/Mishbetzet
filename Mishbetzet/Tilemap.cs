﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mishbetzet
{
    internal class Tilemap : IEnumerable<Tile>
    {
        Tile[,] _tiles;

        public int Width { get => _tiles.GetLength(0); }
        public int Height { get => _tiles.GetLength(1); }

        public Tilemap(int width, int height)
        {
            _tiles = new Tile[width, height];
        }

        //returns tile at x,y coordinate
        public Tile GetTile(int x, int y)
        {
            //TODO check if x and y are in bounds
            if(x < 0 || y < 0 || x >= Width || y >= Height)
            {
                throw new ArgumentOutOfRangeException(nameof(x), nameof(y));
            }
            return _tiles[x, y];
        }

        //set tile at x,y to another tile
        public void SetTile(int x, int y, Tile tile)
        {
            if (x < 0 || y < 0 || x >= Width || y >= Height)
            {
                throw new ArgumentOutOfRangeException(nameof(x), nameof(y));
            }

            _tiles[x, y] = tile;
        }

        public IEnumerator<Tile> GetEnumerator()
        {
            //for (int i = Height; i > 0; i--)
            //{
            //    for (int j = Width; j > 0; j--)
            //    {
            //        yield return _tiles[j - 1, i - 1];
            //    }
            //}
            //foreach (Tile tile in _tiles)
            //{
            //    yield return tile;
            //}
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    yield return _tiles[j, i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<Tile> SpiralEnumerator(Point p)
        {
            int x = p.X;
            int y = p.Y;
            int steps = 1;
            int loop = Height > Width ? Height : Width;

            for (int l = 0; l < loop; l++)
            {
                //yield return _tiles[x, y]; //checks initial tile
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
