namespace Mishbetzet
{
    public interface IRenderer
    {
        Enum DefualtGameObject { get; protected set; }
        Enum TileStyle { get; protected set; }

        /// <summary>
        /// In charge of updating the Renderer, consider clearing before rendering 
        /// </summary>
        public void Update();

        /// <summary>
        /// Renderes 
        /// </summary>
        public void Render();

        void InitialCreation();

        

    }
}
