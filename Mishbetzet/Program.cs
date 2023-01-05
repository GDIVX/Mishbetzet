using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mishbetzet;

class Program
{
    static void Main(string[] args)
    {
        
        Tilemap tileMap = new Tilemap(10,4);
        EmptyTile emptyTile = new(0, 0);
        GameRenderer gameRenderer = new GameRenderer(tileMap);
        foreach(Tile tile in tileMap)
        {
            if (tile == null)
            {
                Console.WriteLine("tile?");
            }
            
        }
    }
}
