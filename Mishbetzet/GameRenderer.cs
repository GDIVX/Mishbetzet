namespace Mishbetzet
{
    /// <summary>
    /// Renders the game.
    /// </summary>
    internal class GameRenderer
    {
        /// <summary>
        /// Tile map the render engine creates to facilitate any possable changes
        /// </summary>
        string[,] _engineTileMap;

        int _individualeTileWidth;
        int _individualeTileHeight;

        int _width;
        int _height;

        bool _initChanges = false;

        ConsoleColor _fgColor = ConsoleColor.White;
        ConsoleColor _bgColor = ConsoleColor.Black;


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

        #region ChangeSpecificTile overload
        /// <summary>
        /// Changes specific tile color *W I P*
        /// </summary>
        /// <param name="tile">The desired tile to set changes</param>
        /// <param name="color">The selected color for the tile</param>
        /// <param name="foreground">true = foreground, false = background</param>
        public void ChangeSpecificTile(Tile tile, ConsoleColor color, bool foreground)
        {
            _initChanges = true;
            if (foreground)
            {
                return;
            }

        }

        /// <summary>
        /// Changes specific tile stlye
        /// </summary>
        /// <param name="tile"></param>
        /// <param name="tilestyle"></param>
        public void ChangeSpecificTile(Tile tile, TileStyle tilestyle)
        {
            _initChanges = true;
            /* 
             * Make sure to understand where this tile is located
             * use point to do so
             * change the _enginetilemap to coreponed with changes
             * you/client choose to do 
             */
        }

        /// <summary>
        /// Changes the tile size into the desired size
        /// </summary>
        /// <param name="height">Will resize the tile height, minimun of 3</param>
        /// <param name="width">Will resize the tile width, minimun of 3</param>
        void ChangeTileSize(int height, int width)
        {
            if (_height < 3 || _width < 3)
            {
                Console.WriteLine("Both tile height and width have to be bigger or equals to 3");
                Console.WriteLine("The rendered tilemap will stay the same (initial size)");
                return;
            }

            _height *= height;
            _width *= width;
            _engineTileMap = new string[_width, _height];

            bool yBoundary;
            bool xBoundary;
            bool yEndZone;
            bool xEndZone;

            for (int i = 0; i < _height; i++)
            {
                yBoundary = i % height == 0;
                yEndZone = (i + 1) % height == 0;
                for (int j = 0; j < _width; j++)
                {
                    xBoundary = j % width == 0;
                    xEndZone = (j + 1) % width == 0;
                    _engineTileMap[j,i] = DetermineStringBySize(yBoundary, xBoundary, yEndZone, xEndZone);
                }
            }
        }

        string DetermineStringBySize(bool ybound,bool xbound,bool yend, bool xend)
        {
            if (ybound && xbound)
            {
                return "╔";
            }
            if (ybound && xend)
            {
                return "╗";
            }
            if (yend && xbound)
            {
                return "╚";
            }
            if (yend && xend)
            {
                return "╝";
            }
            if (ybound || yend)
            {
                return "═";
            }
            if (xbound || xend) 
            {
                return "║";
            }
            else
            {
                return "s"; // will represent the character for now
            }
        }

        #endregion


        /// <summary>
        /// Changes foreground color acroos the entire tilemap
        /// </summary>
        /// <param name="color"></param>
        public void ChangeForeground(ConsoleColor color) => _fgColor = color;

        /// <summary>
        /// Changes background color across the enire tilemap
        /// </summary>
        /// <param name="color"></param>
        public void ChangeBackground(ConsoleColor color) => _bgColor = color;

        public void Print()
        {
            Console.ForegroundColor = _fgColor;
            Console.BackgroundColor = _bgColor;
            for (int i = 0; i < _height; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    Console.Write(_engineTileMap[j, i]);
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// A meathod the creats an initial tileMap of renders
        /// </summary>
        /// <param name="tilemap"></param>
        void InitialCreation(Tilemap tilemap)
        {
            for (int i = 0; i < tilemap.Height; i++)
            {
                for (int j = 0; j < tilemap.Width; j++)
                {
                    _engineTileMap[j, i] = GetTileLook(tilemap.GetTile(j, i));
                }
            }
        }

        /// <summary>
        /// A method incharge of getting spcific tile look
        /// </summary>
        /// <param name="tile"></param>
        /// <param name="gameObjectLooks"></param>
        /// <param name="tilestyle"></param>
        /// <returns></returns>
        string GetTileLook(Tile tile, DefualtGameObject gameObjectLooks = DefualtGameObject.KLetter, TileStyle tilestyle = TileStyle.Square)
        {
            string f = "[", m = " ", l = "]";

            // this if place holder, this should be if tile hold a null gameobject
            if (tile == null)
            {
                m = " ";
            }
            else
            {
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
                }
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

#region Mashocist Attempt
/* 1. Accept new tile size in a Vector2 / width and hieght of each tile () 
 * 2. New tile raws will be used only when you the program will reach the end of the tile height
 * f.e if new tile size have the height of 4 tile (1,0) will be written in the 4th int i of for loop
 * 
 * figure out away to complment the current system that wont break it
 * Think about using Vector 2 Multiply to determin the tile size
 * if the client wil change the tile size the minimun size will be 2*2
 * Find a way to allways center the gameobject : )
 */
#endregion


// After Generic lesson i have to ideas to further expaned on this 
// maybe this Can accept generic where is : IRenderable or something
// then anything that will be consider renderable or IScaleable can be  
// implemented one way or another in this Render Context

#region Try
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
#endregion
