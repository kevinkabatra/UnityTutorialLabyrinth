namespace Assets.Code.Handlers.Display
{
    using LabyrinthBusinessLogic.Handlers.Displays;
    using UnityEngine;

    /// <summary>
    ///     Implementation of the Display Handler interface.
    /// </summary>
    public class DisplayHandler : IDisplayHandler
    {
        /// <summary>
        ///     Displays a message to the user.
        /// </summary>
        /// <param name="message">Message to display.</param>
        public void DisplayMessage(string message)
        {
            Debug.Log(message);
        }
    }
}