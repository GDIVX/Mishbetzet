using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mishbetzet
{
    internal class ConsoleRenderEngine : Renderer<string,ConsoleColor>
    {
        Tilemap? _renderEngineTileMap;

        public ConsoleRenderEngine(Tilemap tilemap)
        {
            _renderEngineTileMap = tilemap;
        }

        void RenderTile(Tile tile)
        {
            Console.Write("[");
            if (tile.gameObject != null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("O");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.Write(" ");
            }
            Console.Write("]");
        }

        public override void Render(Tilemap tilemap)
        {
            if (_renderEngineTileMap != null)
            {
                for (int i = 0; i < _renderEngineTileMap.Height; i++)
                {
                    for (int j = 0; j < _renderEngineTileMap.Width; j++)
                    {
                        if (_renderEngineTileMap.GetTile(i, j) != null)
                        {
                            RenderTile(_renderEngineTileMap.GetTile(i, j));
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
    }
}
