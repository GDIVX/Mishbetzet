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

        public void InitialCreation(Tilemap tilemap)
        {
            if (tilemap != null)
            {
                _renderEngineTileMap = tilemap;
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
