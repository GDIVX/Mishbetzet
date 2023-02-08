namespace Mishbetzet
{
    public abstract class Tile
    {
        public GameObject gameObject { get; set; }
        public Actor? Actor { get; set; }

        public Point Position { get; set; }

        #region constructors
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


    }
}