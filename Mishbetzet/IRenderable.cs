using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mishbetzet
{
    internal interface IRenderable<T> where T : class
    {
        public Point RenderablePoint { get; protected set; }
        public RenderableObject RenderableObjectType { get; protected set; }

        public void InitRenderable(Point point, T mySelf)
        {
            RenderablePoint = point;
            switch (mySelf)
            {
                case Tile:
                    RenderableObjectType = RenderableObject.Tile;
                    break;
                case GameObject:
                    RenderableObjectType = RenderableObject.GameObject;
                    break;
            }
        }
        

    }

    enum RenderableObject { Tile, GameObject }
}
