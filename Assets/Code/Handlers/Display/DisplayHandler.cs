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
            SendMessageToDebugger(message);
            SendMessageToView(message);
        }

        public void DisplayStartTileMap()
        {
            var worldMap = GetWorldMap();

            HideAllTileMaps(worldMap);
            worldMap.StartTileMap.enabled = true;
        }

        public void DisplayVerticalPipeTileMap()
        {
            var worldMap = GetWorldMap();

            HideAllTileMaps(worldMap);
            worldMap.VerticalPipeTileMap.enabled = true;
        }

        public void HideAllTileMaps(WorldMap worldMap = null)
        {
            if (worldMap == null)
            {
                worldMap = GetWorldMap();
            }

            worldMap.StartTileMap.enabled = false;
            worldMap.VerticalPipeTileMap.enabled = false;
        }

        private static WorldMap GetWorldMap()
        {
            var worldMapGameObject = GameObject.Find("WorldMap");
            var worldMap = worldMapGameObject.GetComponent<WorldMap>();

            return worldMap;
        }

        private static void SendMessageToDebugger(string message)
        {
            Debug.Log(message);
        }

        private static void SendMessageToView(string message)
        {
            var userInterfaceGameObject = GameObject.Find("UserInterface");
            var view = userInterfaceGameObject.GetComponent<View>();

            view.userInstructions.text = message;
        }
    }
}