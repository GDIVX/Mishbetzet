namespace Mishbetzet
{
    internal abstract class Tile
    {
        // what if every tile will hold a gameObject ?
        // meaning if the gameobject on said tile is null then the tile is free and has no gameobject in it,
        // if not it must means it is occupied with some type of gameobject.
        GameObject gameObject;
        TileState tileState;
        Actor controller;

        public Point Position { get; set; }

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
            this.gameObject = gameObject;
        }
        #endregion

        public void SetGameObject(GameObject go)
        {
            //TODO checks if tile can hold gameobject
            gameObject = go;
        }

        public GameObject GetGameObject()
        {
            return gameObject;
        }


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
    //internal static Tile Create(int x, int y)
    //{
    //    Tile tile = new();
    //    tile.Position = new Point(x, y);
    //    return tile;
    //}

    }
}