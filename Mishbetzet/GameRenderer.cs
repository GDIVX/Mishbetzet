﻿namespace Mishbetzet
{
    /// <summary>
    /// Renders the game.
    /// </summary>
    internal class GameRenderer
    {
        string[,] _engineTileMap;

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

        #region CST overload
        /// <summary>
        /// Changes specific tile color
        /// </summary>
        /// <param name="tile">The desired tile to set changes</param>
        /// <param name="color">The selected color for the tile</param>
        /// <param name="foreground">true = foreground, false = background</param>
        public void ChangeSpecificTile(Tile tile,ConsoleColor color,bool foreground)
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
