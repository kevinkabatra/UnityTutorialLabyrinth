namespace LabyrinthBusinessLogic.Handlers.Displays
{
    /// <summary>
    ///     Interface for displays.
    /// </summary>
    public interface IDisplayHandler
    {
        void DisplayMessage(string message);
        void DisplayStartTileMap();
        void DisplayVerticalPipeTileMap();
        void DisplayVerticalPipeModifierTileMap();
    }
}
