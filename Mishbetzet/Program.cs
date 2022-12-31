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
        Tilemap tileMap = new(8,8);
        GameRenderer gameRenderer = new GameRenderer(tileMap);
        gameRenderer.Print();
    }
}
