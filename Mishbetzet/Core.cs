using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mishbetzet
{
    /// <summary>
    /// The core interface for the engine
    /// </summary>
    public class Core : Engine
    {
        public Tilemap? Tilemap { get; private set; }

        public override bool IsRunning => _isRunning;

        public event Action? onEngineStart;
        public event Action? onEngineStop;

        GameRenderer renderer;
        bool _isRunning = false;

        public Core()
        {
            renderer = new();
        }

        public void CreateTileMap(int width, int height)
        {
            Tilemap = new(width, height);
        }

        public void CreateTile<T>(Point position) where T : Tile
        {
            if (Tilemap == null)
            {
                throw new Exception("Tilemap is not initialized");
            }

            var tile = Activator.CreateInstance(typeof(T), position) as Tile;
            if (tile == null)
            {
                throw new Exception($"Tile creation failed for type {typeof(T)}");
            }
            Tilemap.AddTile(tile);
        }

        /// <summary>
        /// Called at the start
        /// </summary>
        public override void Run()
        {

            onEngineStart?.Invoke();

            if (Tilemap == null) return;
            renderer.Render(Tilemap);

            Update();
        }

        /// <summary>
        /// Called every turn to update the game state
        /// </summary>
        public void Update()
        {
            if (Tilemap == null) return;
            renderer.Render(Tilemap);

            //TODO - create a list of all game objects and call update on them
        }

        public override void Stop()
        {
            onEngineStop?.Invoke();
        }


    }
}
