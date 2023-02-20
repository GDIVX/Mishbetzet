using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mishbetzet
{
    public abstract class Tile
    {
        public GameObject gameObject { get; set; }
        public Actor? Actor { get; set; }
        public Point Position { get; set; }


        #region Constructors
        public Tile(Point position)
        {
            Position = position;
        }

        #endregion

        public void SetGameObject(GameObject newGameObject)
        {
            this.gameObject = newGameObject;
            newGameObject.SetTile(this);
        }


        public override string ToString()
        {
            return $"{Position.X}, {Position.Y}, object: {gameObject}";
        }

        public void GetLook()
        {
            throw new NotImplementedException();
        }
    }
}