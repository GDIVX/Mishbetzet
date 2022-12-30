namespace Mishbetzet
{
    /// <summary>
    /// Renders the game.
    /// </summary>
    internal class GameRenderer
    {
        TileStyle _style;
        TilemapPattern _pattern;

        int _height;
        int _width;

        string _tileLeftEdge = "[";
        string _tileRightEdge = "]";
       
        public GameRenderer(Tilemap tilemap, TilemapPattern pattern = TilemapPattern.Non)
        {
            _height = tilemap.Height;
            _width = tilemap.Width;
            _pattern = pattern;
        }

        /// <summary>
        /// A collection of tiles styles that can be used as a defualt for rendering
        /// </summary>
        public enum TileStyle
        {
            Square,
            Curly,
            Parenthesis,
            LessGreater
        }

        public enum TilemapPattern
        {
            Non,
            Chequered
        }

        void DrawTilemap(Tilemap tilemap)
        {
            for (int i = 0; i < _height; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    Console.Write($"{_tileLeftEdge} {_tileRightEdge}");
                }
                ChangeDefualtTileStyle((TileStyle)Random.Shared.Next(0, 4));
                Console.ForegroundColor = (ConsoleColor)Random.Shared.Next(0, 16);
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// A method in charge of chaning the defulat way tiles render
        /// </summary>
        /// <param name="choosenTile"></param>
        void ChangeDefualtTileStyle(TileStyle choosenTile)
        {
            switch (choosenTile)
            {
                case TileStyle.Square:
                    _tileLeftEdge = "[";
                    _tileRightEdge = "]";
                    break;
                case TileStyle.Curly:
                    _tileLeftEdge = "{";
                    _tileRightEdge = "}";
                    break;
                case TileStyle.Parenthesis:
                    _tileLeftEdge = "(";
                    _tileRightEdge = ")";
                    break;
                case TileStyle.LessGreater:
                    _tileLeftEdge = "<";
                    _tileRightEdge = ">";
                    break;
            }
        }
    }
}