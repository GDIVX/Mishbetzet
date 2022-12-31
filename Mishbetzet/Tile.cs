namespace Mishbetzet
{
    internal abstract class Tile
    {
        // what if every tile will hold a gameObject ?
        // meaning if the gameobject on said tile is null then the tile is free and has no gameobject in it,
        // if not it must means it is occupied with some type of gameobject.
        List<GameObject> gameObjects = new();
        TileState tileState;

        #region constructors
        public Tile(int posX, int posY)
        {

            Position = new Point(posX, posY);
            this.tileState = TileState.Empty;
        }

        public Tile(int posX, int posY, TileState tileState = TileState.Empty)
        {
            
            Position = new Point(posX, posY);
            this.tileState = tileState;
        }

        public Tile(int posX, int posY, GameObject gameObject, TileState tileState = TileState.Holding)
        {
            Position = new Point(posX, posY);
            this.tileState = tileState;
            gameObjects.Add(gameObject);
        }
        #endregion

        public void SetGameObject(GameObject go)
        {
            //TODO checks if tile can hold gameobject
            gameObjects.Add(go);
        }

        public List<GameObject> GetGameObject()
        {
            return gameObjects;
        }

        public Point Position { get; set; }

        public override string ToString()
        {
            return $"{Position.X}, {Position.Y}";
        }

        public enum TileState
        {
            Hole,
            Empty,
            Holding
        }
    }
}