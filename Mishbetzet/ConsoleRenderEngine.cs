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
        IRenderable _renderable;

        public void InitialCreation(Tilemap tilemap)
        {
            if (tilemap != null)
            {
                _renderEngineTileMap = tilemap;

                for (int i = 0; i < tilemap.Height; i++)
                {
                    for (int j = 0; j < tilemap.Width; j++)
                    {
                        if (tilemap.GetTile(i,j)!= null)
                        {
                            _renderable = tilemap.GetTile(i,j);
                            _renderable.GetLook();
                        }
                    }
                    Console.WriteLine();
                }

            }
            else
            {
                throw new ArgumentNullException(nameof(tilemap));
            }
        }

        public void Render()
        {

        }

        public void Update()
        {

        }
    }
}
