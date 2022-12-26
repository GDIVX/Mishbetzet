using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mishbetzet
{
    internal abstract class GameObject : IMovable
    {
        Tile _currentTile;
        Controller _objectController;

        public Tile Tile { get => _currentTile; set => _currentTile = value; }
        public Controller ObjectController { get => _objectController; private set => _objectController = value; }

        
        public event Action<GameObject> OnStep;

        public event Action<GameObject> OnPassOver;

        public GameObject(Controller actor)
        {
            _objectController = actor;
        }

        public abstract void Move();
    }
}
