namespace Assets.Code.Handlers.Input
{
    using UnityEngine;

    /// <summary>
    ///     Finds the key press and returns it to the mediator.
    /// </summary>
    public class InputHandler
    {
        /// <summary>
        ///     Listens for any of the currently supported key codes.
        /// </summary>
        /// <returns>KeyCode. Returns the supported key that was pressed.</returns>
        public KeyCode Listen()
        {
            if (ListenForUpArrow())
            {
                return KeyCode.UpArrow;
            }

            if (ListenForDownArrow())
            {
                return KeyCode.DownArrow;
            }

            if (ListenForLeftArrow())
            {
                return KeyCode.LeftArrow;
            }

            if (ListenForRightArrow())
            {
                return KeyCode.RightArrow;
            }

            if (ListenForSpaceBar())
            {
                return KeyCode.Space;
            }

            return KeyCode.None;
        }

        /// <summary>
        ///     Handles the actual listening.
        /// </summary>
        /// <param name="key">The Key Code that should be listened for.</param>
        /// <returns>Boolean. If the listener found its key press.</returns>
        private static bool Listener(KeyCode key)
        {
            var result = Input.GetKeyDown(key);
            return result;
        }

        /// <summary>
        ///     Listens for Up Arrow key press.
        /// </summary>
        /// <returns>Boolean. If the key was pressed.</returns>
        private static bool ListenForUpArrow()
        {
            return Listener(KeyCode.UpArrow);
        }

        /// <summary>
        ///     Listens for Down Arrow key press.
        /// </summary>
        /// <returns>Boolean. If the key was pressed.</returns>
        private static bool ListenForDownArrow()
        {
            return Listener(KeyCode.DownArrow);
        }

        /// <summary>
        ///     Listens for Left Arrow key press.
        /// </summary>
        /// <returns>Boolean. If the key was pressed.</returns>
        private static bool ListenForLeftArrow()
        {
            return Listener(KeyCode.LeftArrow);
        }

        /// <summary>
        ///     Listens for Right Arrow key press.
        /// </summary>
        /// <returns>Boolean. If the key was pressed.</returns>
        private static bool ListenForRightArrow()
        {
            return Listener(KeyCode.RightArrow);
        }

        /// <summary>
        ///     Listens for Space Bar key press.
        /// </summary>
        /// <returns>Boolean. If the key was pressed.</returns>
        private static bool ListenForSpaceBar()
        {
            return Listener(KeyCode.Space);
        }
    }
}
