using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Mishbetzet
{
    internal abstract class GameObject : IMovable, ICloneable
    {
        Tile _currentTile;
        Actor _actor;
        int _amountOfStepsPossible; //if null then endless


        public Tile Tile { get => _currentTile; set => _currentTile = value; }
        public Actor ObjectController { get => _actor; private set => _actor = value; }


        public event Action OnStep; //should be called when gameobject finished moving? i dunno it was in the brief
                                    

        public event Action<GameObject> OnPassOver; //should be called if a game object steps on a tile without finishing his move function,
                                                    //meaning he did not land on the tile, just passed over it.

        public GameObject(Actor actor) //ctor must contain an actor because "all gameobjects need to belong to an actor"
        {
            _actor = actor;
        }


        public abstract void Move(); //does x amount of steps with rules

        public abstract void Step(StepDirection targetStep); //onstep should contain one tile movement in any direction
        //{                                                  //based on the move logic for each game object. for example moves in stepdirection North (N) so y--
        //    switch(targetStep)
        //    {
        //        case StepDirection.N:
        //            //check if can move up
        //            //TODO move up
        //            break;
        //    }
        //}

        public abstract object Clone();
        //{
        //    var clone = new GameObject(_controller); //?????????? :)
        //    clone.Tile = _currentTile;
        //    clone.OnStep = OnStep;
        //    clone.OnPassOver = OnPassOver;
        //    return clone;
        //}

        public enum StepDirection //each step can only be in one of these directions
        {
            N,
            S,
            E,
            W,
            NE,
            NW,
            SE,
            SW
        }


        //public static GameObject Create(Tile tile)
        //{
        //    GameObject gameObject = new();
        //    gameObject.Tile = tile;
        //    return gameObject;
        //}
    }
}
