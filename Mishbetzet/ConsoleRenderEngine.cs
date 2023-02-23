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
        Tilemap? _renderEngineTileMap;

        public ConsoleRenderEngine(Tilemap tilemap)
        {
            _renderEngineTileMap = tilemap;
        }

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

        public void RenderTile(int x, int y, Tilemap tilemap)
        {
            Console.Write("[");
            RenderTileObject(x,y,tilemap);
            Console.Write("]");
        }

        public void RenderTileObject(int x, int y, Tilemap tilemap)
        {
            if (tilemap.GetTile(x,y).gameObject != null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
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
