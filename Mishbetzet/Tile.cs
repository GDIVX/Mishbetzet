namespace Mishbetzet
{
    public abstract class Tile : IRenderable
    {
        public GameObject gameObject { get; set; }
        public Actor? Actor { get; set; }

        public Point Position { get; set; }

        public Point RednerablePoint => Position;

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