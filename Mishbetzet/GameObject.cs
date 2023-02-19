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

        public string Name { get; set; } = "Game Object";

        /// <summary>
        /// The distance the game object is allowed to move per turn. 
        /// </summary>
        public int MovementRange { get; set; }
        public int RemainingSteps { get; set; }

        public Tile Tile { get => _currentTile; private set => _currentTile = value; }
        public Actor? Actor { get => _actor; internal set => _actor = value; }

        public GameObject(Actor actor,Tile tile, int movementRange = 10)
        {
            _actor = actor;
            Tile = tile;
            MovementRange = movementRange;
            _actor.AddGameObject(this);
        }

        public GameObject(Actor actor, Tile tile)
        {
            _actor = actor;
            Tile = tile;
            MovementRange = 10;
            _actor.AddGameObject(this);
        }


        public event Action OnStep;


        //should be called if a game object steps on a tile without finishing his move function,
        //meaning he did not land on the tile, just passed over it.
        public event Action<Point> OnPassOver;

        #region Senquancing
        /// <summary>
        /// Called every turn
        /// </summary>
        public virtual void Update()
        {

        }

        /// <summary>
        /// Called when the game object is added to the game
        /// </summary>
        public virtual void Start() { }

        #endregion


        /// <summary>
        /// Move the game object to the given position
        /// </summary>
        /// <param name="position"></param>
        public virtual void Move(Point position)
        {
            Tilemap? tilemap = Core.Main.Tilemap;

            if (tilemap == null)
            {
                throw new NullReferenceException("Trying to move before the tilemap was created");
            }

            Tile? tile = tilemap[position.X, position.Y];

            if (tile == null)
            {
                return;
            }

            //check if tile or gameObject on the tile that you want to move to blocks movement

            int remainingSteps = RemainingSteps;

            while (TryStep(position))
            {
                remainingSteps--;
                if (remainingSteps <= 0)
                {
                    break;

                }
            }
        }

        /// <summary>
        /// Handle setting tiles
        /// </summary>
        /// <param name="tile"></param>
        internal void SetTile(Tile tile)
        {
            //Remove old tile if needed
            if (Tile != null)
            {
                Tile.gameObject = null;
                Actor?.RemoveTile(Tile);
            }

            //Set new tile
            Actor?.AddTile(tile);
            Tile = tile;
            tile.gameObject = this;
        }


        //onstep should contain one tile movement in any direction
        //based on the move logic for each game object. for example moves in stepdirection North (N) so y--
        //public abstract void Step(Point direction);

        object ICloneable.Clone()
        {
            throw new NotImplementedException();
        }

        public void PrintPos()
        {
            Console.WriteLine(Tile.Position);
        }

        /// <summary>
        /// Tries to step in a direction
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        public virtual bool TryStep(Point direction)
        {
            Point currentPoint = Tile.Position;
            Point pos = new Point();
            pos = Tile.Position - direction;

            currentPoint = Step(currentPoint, pos);

            if (currentPoint.Equals(Tile.Position))
            {
                return false;
            }

            Tile? newTile = Core.Main.Tilemap[currentPoint.X, currentPoint.Y];

            if(newTile == null)
            {
                return false;
            }

            GameObject? go = Tile.gameObject;

            //check if tile or game object iblockmovement
            if(newTile is IBlockMovementMarker || go is IBlockMovementMarker)
            {
                return false;
            }

            //check if tile has game object
            if(go != null)
            {
                //check if game object is from the same actor
                if (go.Actor == this.Actor)
                {
                    return false;
                }
            }

            SetTile(newTile);

            return true;
        }

        /// <summary>
        /// Moves pointToMove one step closer to 0,0 based on pos
        /// </summary>
        /// <param name="pointToMove"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        private Point Step(Point pointToMove, Point pos)
        {
            switch (pos.X)
            {
                case < 0 when pos.Y == 0:
                    pointToMove += Point.East;
                    break;
                case < 0 when pos.Y < 0:
                    pointToMove += Point.NorthEast;
                    break;
                case 0 when pos.Y < 0:
                    pointToMove += Point.North;
                    break;
                case > 0 when pos.Y < 0:
                    pointToMove += Point.NorthWest;
                    break;
                case > 0 when pos.Y == 0:
                    pointToMove += Point.West;
                    break;
                case > 0 when pos.Y > 0:
                    pointToMove += Point.SouthWest;
                    break;
                case 0 when pos.Y > 0:
                    pointToMove += Point.South;
                    break;
                case < 0 when pos.Y > 0:
                    pointToMove += Point.SouthEast;
                    break;
            }
            OnPassOver?.Invoke(pointToMove);
            return pointToMove;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
