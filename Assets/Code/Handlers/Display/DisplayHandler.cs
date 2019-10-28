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

        public void DisplayStart()
        {
            var worldMap = GetCleanWorldMap();
            worldMap.Start.enabled = true;
        }

        public void DisplayVerticalPipe()
        {
            var worldMap = GetCleanWorldMap();
            worldMap.VerticalPipe.enabled = true;
        }

        public void DisplayVerticalPipeModifier()
        {
            var worldMap = GetCleanWorldMap();
            worldMap.VerticalPipe.enabled = true;
            worldMap.VerticalPipeModifier.enabled = true;
        }

        public void DisplayVerticalT()
        {
            var worldMap = GetCleanWorldMap();
            worldMap.VerticalT.enabled = true;
        }

        public void DisplayHorizontalPipe()
        {
            var worldMap = GetCleanWorldMap();
            worldMap.HorizontalPipe.enabled = true;
        }

        public void DisplayFlippedLeftAngle()
        {
            var worldMap = GetCleanWorldMap();
            worldMap.FlippedLeftAngle.enabled = true;
        }

        public void DisplayLeftAngle()
        {
            var worldMap = GetCleanWorldMap();
            worldMap.LeftAngle.enabled = true;
        }

        public void DisplayFlippedHorizontalT()
        {
            var worldMap = GetCleanWorldMap();
            worldMap.FlippedHorizontalT.enabled = true;
        }

        public void DisplayFlippedRightAngle()
        {
            var worldMap = GetCleanWorldMap();
            worldMap.FlippedRightAngle.enabled = true;
        }

        public void DisplayEnd()
        {
            var worldMap = GetCleanWorldMap();
            worldMap.End.enabled = true;
        }

        public void HideAll(WorldMap worldMap = null)
        {
            if (worldMap == null)
            {
                worldMap = GetWorldMap();
            }

            worldMap.Start.enabled = false;
            worldMap.VerticalPipe.enabled = false;
            worldMap.VerticalPipeModifier.enabled = false;
            worldMap.VerticalT.enabled = false;
            worldMap.HorizontalPipe.enabled = false;
            worldMap.FlippedLeftAngle.enabled = false;
            worldMap.LeftAngle.enabled = false;
            worldMap.FlippedHorizontalT.enabled = false;
            worldMap.FlippedRightAngle.enabled = false;
            worldMap.End.enabled = false;
        }

        private WorldMap GetCleanWorldMap()
        {
            var worldMap = GetWorldMap();
            HideAll(worldMap);
            
            return worldMap;
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