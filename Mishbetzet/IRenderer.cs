namespace Mishbetzet
{
    public interface IRenderer
    {
        /// <summary>
        /// In charge of updating the Renderer, consider clearing before rendering 
        /// </summary>
        public void Update();

        /// <summary>
        /// Renderes 
        /// </summary>
        public void Render();

        //void InitialCreation(Tilemap tilemap);

        

    }
}
