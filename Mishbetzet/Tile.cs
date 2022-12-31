namespace Mishbetzet
{
    public class Tile
    {
        // what if every tile will hold a gameObject ?
        // meaning if the gameobject on said tile is null then the tile is free and has no gameobject in it,
        // if not it must means it is occupied with some type of gameobject.

        GameObject? gameObject;

        public Tile()
        {
            gameObject = null;
        }

        public Tile(GameObject gameObject)
        {
            this.gameObject = gameObject;
        }

        public Point Position { get; set; }

        public GameObject? GetGameObject()
        {
            return gameObject;
        }
    }
}