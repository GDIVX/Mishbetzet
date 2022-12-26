namespace Mishbetzet
{
    internal abstract class Tile
    {
        // what if every tile will hold a gameObject ?
        // meaning if the gameobject on said tile is null then the tile is free and has no gameobject in it,
        // if not it must means it is occupied with some type of gameobject.
        List<GameObject> gameObjects = new();

        public Tile()
        {
        }

        public Tile(GameObject gameObject)
        {
            gameObjects.Add(gameObject);
        }

        public Point Position { get; set; }
    }
}