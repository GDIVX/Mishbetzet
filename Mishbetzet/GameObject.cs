using System;
using System.Collections.Generic;
using System.Linq;
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

        
        public event Action OnStep;

        public event Action<GameObject> OnPassOver;

        public GameObject(Actor actor)
        {
            _actor = actor;
        }
        

        public abstract void Move(); //does x amount of steps with rules

        public abstract void Step(StepDirection targetStep);
        //{
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
    }
}
