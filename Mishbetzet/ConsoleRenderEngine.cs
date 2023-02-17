using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mishbetzet
{
    internal class ConsoleRenderEngine : IRenderer
    {
        Tilemap? _renderEngineTileMap;
        IRenderable? _renderable;

        public ConsoleRenderEngine(Tilemap tilemap)
        {
            _renderEngineTileMap = tilemap;
        }

        public void Render()
        {
            if (_renderEngineTileMap != null)
            {
                for (int i = 0; i < _renderEngineTileMap.Height; i++)
                {
                    for (int j = 0; j < _renderEngineTileMap.Width; j++)
                    {
                        _renderable = _renderEngineTileMap.GetTile(i, j);

                        if (_renderable != null)
                        {
                            _renderable.RenderObject();
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

        public void Update()
        {

        }
    }
}
