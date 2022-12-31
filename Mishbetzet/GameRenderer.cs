namespace Mishbetzet
{
    /// <summary>
    /// Renders the game.
    /// </summary>
    internal class GameRenderer
    {
        string[,] _engineTileMap;

        int _width;
        int _height;


        public GameRenderer(Tilemap tilemap)
        {
            _height = tilemap.Height;
            _width = tilemap.Width;
            _engineTileMap = new string[_width, _height];
            InitialCreation(tilemap);
        }

        public enum TileStyle
        {
            Square,
            Curly,
            Parenthesis,
            LessGreater
        }

        public enum DefualtGameObject
        {
            OLetter,
            Zero,
            KLetter
        }

        void InitialCreation(Tilemap tilemap)
        {
            for (int i = 0; i < _height; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    _engineTileMap[i, j] = GetTileLook(tilemap.GetTile(i,j));
                }
            }
        }

        string GetTileLook(Tile tile, DefualtGameObject gameObjectLooks = DefualtGameObject.OLetter, TileStyle tilestyle = TileStyle.Square)
        {
            string f = "[", m = " ", l = "]";

            switch (gameObjectLooks)
            {
                case DefualtGameObject.OLetter:
                    m = "O";
                    break;
                case DefualtGameObject.Zero:
                    m = "0";
                    break;
                case DefualtGameObject.KLetter:
                    m = "K";
                    break;
                default:
                    m = " ";
                    break;
            }

            switch (tilestyle)
            {
                case TileStyle.Square:
                    f = "[";
                    l = "]";
                    break;
                case TileStyle.Curly:
                    f = "{";
                    l = "}";
                    break;
                case TileStyle.Parenthesis:
                    f = "(";
                    l = ")";
                    break;
                case TileStyle.LessGreater:
                    f = "<";
                    l = ">";
                    break;
                default:
                    f = "[";
                    l = "]";
                    break;
            }

            return f + m + l;
        }
    }
}

////First Try, can use as a refrence
//TileStyle _style;
//TilemapPattern _pattern;

//int _height;
//int _width;

//string _tileLeftEdge = "[";
//string _tileRightEdge = "]";

//public GameRenderer(Tilemap tilemap, TilemapPattern pattern = TilemapPattern.Non)
//{
//    _height = tilemap.Height;
//    _width = tilemap.Width;
//    _pattern = pattern;
//}

///// <summary>
///// A collection of tiles styles that can be used as a defualt for rendering
///// </summary>
//public enum TileStyle
//{
//    Square,
//    Curly,
//    Parenthesis,
//    LessGreater
//}

//public enum TilemapPattern
//{
//    Non,
//    Chequered
//}

//void DrawTilemap(Tilemap tilemap)
//{
//    for (int i = 0; i < _height; i++)
//    {
//        for (int j = 0; j < _width; j++)
//        {
//            Console.Write($"{_tileLeftEdge} {_tileRightEdge}");
//        }
//        ChangeDefualtTileStyle((TileStyle)Random.Shared.Next(0, 4));
//        Console.ForegroundColor = (ConsoleColor)Random.Shared.Next(0, 16);
//        Console.WriteLine();
//    }
//    Console.ForegroundColor = ConsoleColor.White;
//}

///// <summary>
///// A method in charge of chaning the defulat way tiles render
///// </summary>
///// <param name="choosenTile"></param>
//void ChangeDefualtTileStyle(TileStyle choosenTile)
//{
//    switch (choosenTile)
//    {
//        case TileStyle.Square:
//            _tileLeftEdge = "[";
//            _tileRightEdge = "]";
//            break;
//        case TileStyle.Curly:
//            _tileLeftEdge = "{";
//            _tileRightEdge = "}";
//            break;
//        case TileStyle.Parenthesis:
//            _tileLeftEdge = "(";
//            _tileRightEdge = ")";
//            break;
//        case TileStyle.LessGreater:
//            _tileLeftEdge = "<";
//            _tileRightEdge = ">";
//            break;
//    }
//}