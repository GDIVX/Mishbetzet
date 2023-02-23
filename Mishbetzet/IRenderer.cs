using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mishbetzet
{
    internal interface IRenderer
    {
        /// <summary>
        /// This will be incharge on the tilemap rendering
        /// </summary>
        /// <param name="tilemap"></param>
        public abstract void Render(Tilemap tilemap);

        /// <summary>
        /// Will be in charge of tile rendering
        /// </summary>
        /// <param name="x">Tile's x location</param>
        /// <param name="y">Tile's y location</param>
        /// <param name="tilemap">Tile's originated tilemap</param>
        public abstract void RenderTile(int x, int y, Tilemap tilemap);

        /// <summary>
        ///  In charge of rendering tile object
        /// </summary>
        /// <param name="x">TileObject's x location</param>
        /// <param name="y">TileObject's y location</param>
        /// <param name="tilemap">TileObject's originated tilemap</param>
        public abstract void RenderTileObject(int x, int y, Tilemap tilemap);
    }
}
