using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Mishbetzet
{
    public abstract class GameObject : IMovable, ICloneable
    {
        Tile _currentTile;
        Actor _actor;
        /// <summary>
        /// The distance the game object is allowed to move per turn. 
        /// </summary>
        public int MovementRange { get; set; }
        public int RemainingSteps { get; set; }


        public Tile Tile { get => _currentTile; set => _currentTile = value; }
        public Actor Actor { get => _actor; private set => _actor = value; }


        public event Action OnStep;


        //should be called if a game object steps on a tile without finishing his move function,
        //meaning he did not land on the tile, just passed over it.
        public event Action<GameObject> OnPassOver;

        //ctor must contain an actor because "all gameobjects need to belong to an actor"
        internal GameObject(Actor actor, Tile tile)
        {
            Actor = actor;
            Tile = tile;
        }


        //does x amount of steps with rules
        public abstract void Move();


        //onstep should contain one tile movement in any direction
        //based on the move logic for each game object. for example moves in stepdirection North (N) so y--
        public abstract void Step(Point direction);

        object ICloneable.Clone()
        {
            throw new NotImplementedException();
        }
    }
}
