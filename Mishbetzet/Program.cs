using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mishbetzet;

class Program
{
    static void Main(string[] args)
    {
        Core.Main.CreateTileMap(10, 10);


        for (int x = 0; x < 10; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                Core.Main.CreateTile<BaseTile>(new(x, y));
            }
        }

        foreach (var tile in Core.Main.Tilemap)
        {
            Console.WriteLine(tile);
            Core.Main.CreateGameObject<BaseGameObject>(tile);
        }
        
    }
}

public class BaseGameObject : GameObject
{
    public override void Step(Point direction)
    {
        throw new NotImplementedException();
    }
}

public class BaseTile : Tile
{
    public BaseTile(Point position) : base(position)
    {
    }
}