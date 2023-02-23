using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mishbetzet
{
    internal class ConsoleRenderEngine : IRenderer
    {
        /// <summary>
        /// The tile object defualt render color
        /// </summary>
        public ConsoleColor TileObjectColor { get; protected set; } = ConsoleColor.Blue;
        
        Tilemap? _renderEngineTileMap;
        
        public ConsoleRenderEngine(Tilemap tilemap)
        {
            _renderEngineTileMap = tilemap;
        }

        /// <summary>
        /// Rendered the game
        /// </summary>
        /// <param name="tilemap">The desired tilemap to render</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Render(Tilemap tilemap)
        {
            if (_renderEngineTileMap != null)
            {
                for (int i = 0; i < _renderEngineTileMap.Height; i++)
                {
                    for (int j = 0; j < _renderEngineTileMap.Width; j++)
                    {
                        if (_renderEngineTileMap.GetTile(i, j) != null)
                        {
                            RenderTile(i,j,tilemap);
                        }
                    }
                    Console.WriteLine();
                }

            }
            else
            {
                throw new ArgumentNullException(nameof(_renderEngineTileMap));
            }
        
        }

        /// <summary>
        /// Rendered the tile
        /// </summary>
        /// <param name="x">Tile's x location</param>
        /// <param name="y">Tile's y location</param>
        /// <param name="tilemap">Tile's originated tilemap</param>
        public void RenderTile(int x, int y, Tilemap tilemap)
        {
            Console.Write("[");
            RenderTileObject(x,y,tilemap);
            Console.Write("]");
        }

        /// <summary>
        /// Renderes the TileObject
        /// </summary>
        /// <param name="x">TileObject's x location</param>
        /// <param name="y">TileObject's y location</param>
        /// <param name="tilemap">TileObject's originated tilemap</param>
        public void RenderTileObject(int x, int y, Tilemap tilemap)
        {
            if (tilemap.GetTile(x,y).tileObject != null)
            {
                Console.ForegroundColor = TileObjectColor;
                Console.Write("O");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.Write(" ");
            }
        }
    }
}
