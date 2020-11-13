// ReSharper disable UnusedMember.Global, Start and Update are called by the Unity Engine, attached to Scene.Main.
namespace Assets.Code
{
    using System;
    using Handlers.Display;
    using Handlers.Input;
    using Kabatra.Game.StateMachine.StateMachines;
    using Kabatra.Game.StateMachine.StateMachines.States;
    using Kabatra.Game.StateMachine.StateMachines.Triggers;
    using LabyrinthBusinessLogic.StateMachines;
    using LabyrinthBusinessLogic.StateMachines.Triggers;
    using UnityEngine;

    /// <summary>
    ///     Entry point to the application.
    /// </summary>
    /// <remarks>
    ///     This class follows the Mediator design pattern. All
    /// communication between the various components originates
    /// within this class.
    /// </remarks>
    /// <seealso href="https://refactoring.guru/design-patterns/mediator"/>
    public class Main : MonoBehaviour
    {
        private DisplayHandler _displayHandler;
        private InputHandler _inputHandler;

        private StateMachineGameState _gameStateStateMachine;
        private WorldMapStateMachine _worldMapStateMachine;

        /// <summary>
        ///     Start is called before the first frame update.
        /// </summary>
        /// <remarks>
        ///     Unity Engine method.
        /// </remarks>
        public void Start()
        {
            Initialize();
            DisplayStartMessage();
        }

        /// <summary>
        ///     Update is called once per frame. 
        /// </summary>
        /// <remarks>
        ///     Unity Engine method.
        /// </remarks>
        public void Update()
        {
            HandleUserInput();
        }

        /// <summary>
        ///     Displays the start message to the user.
        /// </summary>
        private void DisplayStartMessage()
        {
            var startMessage = $"Press the space bar when ready to continue...";
            _displayHandler.DisplayMessage(startMessage);
        }

        /// <summary>
        ///     Handler for all keyboard input, actions taken depend on the Game State.
        /// </summary>
        private void HandleUserInput()
        {
            var currentGameState = _gameStateStateMachine.State;

            var input = _inputHandler.Listen();
            // ReSharper disable once SwitchStatementMissingSomeCases, most inputs are not supported.
            switch (input)
            {
                case KeyCode.Space:
                    if (currentGameState == GameState.None)
                    {
                        _gameStateStateMachine.Fire(GameStateTrigger.StartGame);
                        _worldMapStateMachine.Fire(PlayerMovement.Forward);
                    }
                    break;

                case KeyCode.None:
                    break;

                case KeyCode.UpArrow:
                    if (currentGameState == GameState.Playing)
                    {
                        _worldMapStateMachine.Fire(PlayerMovement.Forward);
                    }
                    break;

                case KeyCode.DownArrow:
                    if (currentGameState == GameState.Playing)
                    {
                        _worldMapStateMachine.Fire(PlayerMovement.Backward);
                    }
                    break;

                case KeyCode.LeftArrow:
                    if (currentGameState == GameState.Playing)
                    {
                        _worldMapStateMachine.Fire(PlayerMovement.Left);
                    }
                    break;

                case KeyCode.RightArrow:
                    if (currentGameState == GameState.Playing)
                    {
                        _worldMapStateMachine.Fire(PlayerMovement.Right);
                    }
                    break;

                default:
                    var errorMessage = $"KeyCode: {input} is not supported.";
                    throw new NotSupportedException(errorMessage);
            }
        }

        /// <summary>
        ///     Initializes all of the components.
        /// </summary>
        private void Initialize()
        {
            _displayHandler = new DisplayHandler();

            _inputHandler = new InputHandler();

            _gameStateStateMachine = new StateMachineGameState(GameState.None, _displayHandler);
            _worldMapStateMachine = new WorldMapStateMachine(LabyrinthBusinessLogic.StateMachines.States.WorldMap.None, _displayHandler);

            _displayHandler.HideAll();
        }
    }
}
