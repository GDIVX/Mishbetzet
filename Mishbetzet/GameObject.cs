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
        Controller _controller;

        public Tile Tile { get => _currentTile; set => _currentTile = value; }
        public Controller ObjectController { get => _controller; private set => _controller = value; }

        
        public event Action OnStep;

        public event Action<GameObject> OnPassOver;

        public GameObject(Controller actor)
        {
            _controller = actor;
        }

        public abstract void Move(); //does x amount of steps with rules

        public virtual void Step(StepDirection targetStep)
        {
            switch(targetStep)
            {
                case StepDirection.N:
                    //check if can move up
                    //TODO move up
                    break;
            }
        }

        public object Clone()
        {
            var clone = new GameObject(_controller); //?????????? :)
            clone.Tile = _currentTile;
            clone.OnStep = OnStep;
            clone.OnPassOver = OnPassOver;
            return clone;
        }

        public enum StepDirection
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
