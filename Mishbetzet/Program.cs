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
        Core coreEngine = new();
        coreEngine.CreateTileMap(10, 10);
        coreEngine.Run();
    }
}
