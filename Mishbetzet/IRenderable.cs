using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mishbetzet
{
    public interface IRenderable
    {
        /// <summary>
        /// The point which this IRenderable is located on the Tilemap
        /// </summary>
        public Point RednerablePoint { get; }

        /// <summary>
        /// This method will be incharge of rendering the IRenderable object
        /// </summary>
        public void RenderObject();

    }
}
