using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mishbetzet
{
    internal class BasicGameObject : GameObject
    {
        public BasicGameObject(Actor actor) : base(actor)
        {
        }

        public override void Step(Point direction)
        {
            //Tile newTile = Core.Main.Tilemap.GetTile(Tile.Position + direction);
            //newTile.SetGameObject(this);

            Point newPoint = Tile.Position + direction;
            Tile newTile = Core.Main.Tilemap[newPoint.X, newPoint.Y];
            newTile.SetGameObject(this);

            //if(stepDirection.X < 0 && stepDirection.Y < 0)
            //{
            //}

        }

        public override void Move(Point position)
        {
            
            Step(position);

            // current pos - new pos
            //while pos != 0,0
            //check direction to move (N,S,E,W,NE,NW,SE,SW)
            //step once in the direction

        }

    }
}
