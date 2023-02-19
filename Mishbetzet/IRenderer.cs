namespace Mishbetzet
{
    internal abstract class Renderer<T,T1>
    {

        public abstract void Render(Tilemap tilemap);

        public void ChangeTileLook(T pieceLook, Tile tile, T1 newColor)
        {
            
        }

        public void ChangeGameObjectLook(T pieceLook, GameObject gameObject, T1 newColor)
        {

        }

    }
}
