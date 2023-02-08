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
        Tilemap tmap = Core.Main.Tilemap;
        for (int i = 0; i < tmap.Height; i++)
        {
            for (int j = 0; j < tmap.Width; j++)
            {
                Core.Main.Tilemap.AddTile(new BasicTile(new Point(j, i)));
            }
        }



        BasicGameObject bgo= new BasicGameObject(a1);
        //Console.WriteLine(bgo.ToString());
        //bgo.SetTile(Core.Main.Tilemap[0, 0]);

        //foreach(var t in Core.Main.Tilemap)
        //{
        //    Console.WriteLine(t.ToString());
        //}
    }
}