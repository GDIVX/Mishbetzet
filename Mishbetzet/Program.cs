﻿using System;
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
        //Sanity check to make sure the engine is working

        //Create a tile map
        var tilemap = Core.Main.CreateTileMap(10, 10);

        Core.Main.Run();

        //Populate the tile map with tiles
        for (int x = 0; x < 10; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                Core.Main.CreateTile<BaseTile>(new(x, y));
            }
        }

        //Create an actor
        var actor = Core.Main.CreateActor<ChessActor>();

        //Create a game object for each tile
        foreach (var tile in tilemap)
        {
            Console.WriteLine(tile);
            Core.Main.CreateGameObject<BaseGameObject>(actor, tile);
        }

        Core.Main.TurnManager.StartTurn();
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

public class ChessActor : TurnTrackedActor
{
    public ChessActor() : base()
    {
    }

    public override void StartTurn()
    {
        Console.WriteLine("Doing chess stuff");
    }
}