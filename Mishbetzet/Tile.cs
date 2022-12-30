namespace Mishbetzet
{
    public class Tile
    {
        // what if every tile will hold a gameObject ?
        // meaning if the gameobject on said tile is null then the tile is free and has no gameobject in it,
        // if not it must means it is occupied with some type of gameobject.
        GameObject? gameObject;
        public Point Position { get; set; }

        internal static Tile Create(int x, int y)
        {
            Tile tile = new();
            tile.Position = new Point(x, y);
            return tile;
        }
    }
}