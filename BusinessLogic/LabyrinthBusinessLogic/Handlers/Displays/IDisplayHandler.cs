namespace LabyrinthBusinessLogic.Handlers.Displays
{
    /// <summary>
    ///     Interface for displays.
    /// </summary>
    public interface IDisplayHandler
    {
        void DisplayMessage(string message);
        void DisplayStart();
        void DisplayVerticalPipe();
        void DisplayVerticalPipeModifier();
        void DisplayVerticalT();
        void DisplayHorizontalPipe();
        void DisplayFlippedLeftAngle();
        void DisplayLeftAngle();
        void DisplayFlippedHorizontalT();
        void DisplayFlippedRightAngle();
        void DisplayEnd();
    }
}
