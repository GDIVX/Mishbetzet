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
        Actor a1= new Actor();
        Actor a2= new Actor();
        Core.Main.CreateTileMap(10, 10);
        //Core.Main.Run();
        Core.Main.Tilemap.FillMapBasic();


        BasicGameObject bgo = new BasicGameObject(a1);
        //Console.WriteLine(bgo.ToString());
        //bgo.SetTile(Core.Main.Tilemap[0, 0]);

        Core.Main.Tilemap[0, 0].SetGameObject(bgo);
        bgo.Move(Point.SouthEast);

        foreach (var t in Core.Main.Tilemap)
        {
            Console.WriteLine(t.ToString());
        }
    }
}