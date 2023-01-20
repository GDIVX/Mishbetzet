namespace Mishbetzet
{
    public abstract class Tile
    {
        public GameObject gameObject { get; set; }
        Actor controller;

        public Point Position { get; set; }

        #region constructors
        public Tile(Point position)
        {
            Position = position;
        }



        #endregion


        public override string ToString()
        {
            return $"{Position.X}, {Position.Y}";
        }


    }
}