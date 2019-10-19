namespace LabyrinthBusinessLogic.StateMachines
{
    using System;
    using Handlers.Displays;
    using Stateless;
    using States;
    using Triggers;
    using Utilities;

    /// <summary>
    ///     The state machine to control the various states of the game.
    /// </summary>
    public class GameState : StateMachine<GameStates, GameStateTriggers>
    {
        private const GameStates GameNotStarted = GameStates.None;
        private const GameStates UserPlayingGame = GameStates.Playing;
        private const GameStates UserFinishedPlaying = GameStates.GameOver;

        private IDisplayHandler _displayHandler;
        private LabelRetriever _labelRetriever;

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="stateAccessor">A function that will be called to read the current state value.</param>
        /// <param name="stateMutator">An action that will be called to write new state values.</param>
        /// <param name="displayHandler">Handler that will display the messages from the state machine.</param>
        public GameState(Func<GameStates> stateAccessor, Action<GameStates> stateMutator, IDisplayHandler displayHandler) : base(stateAccessor, stateMutator)
        {
            Initialize(displayHandler);
            SetupStateMachine();
        }

        /// <summary>
        ///     Default constructor.
        /// </summary>
        /// <param name="initialState">Initial state to set the state machine to.</param>
        /// <param name="displayHandler">Handler that will display the messages from the state machine.</param>
        public GameState(GameStates initialState, IDisplayHandler displayHandler) : base(initialState)
        {
            Initialize(displayHandler);
            SetupStateMachine();
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="stateAccessor">A function that will be called to read the current state value.</param>
        /// <param name="stateMutator">An action that will be called to write new state values.</param>
        /// <param name="firingMode">Optional specification of firing mode.</param>
        /// <param name="displayHandler">Handler that will display the messages from the state machine.</param>
        public GameState(Func<GameStates> stateAccessor, Action<GameStates> stateMutator, FiringMode firingMode, IDisplayHandler displayHandler) : base(stateAccessor, stateMutator, firingMode)
        {
            Initialize(displayHandler);
            SetupStateMachine();
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="initialState">The initial state of the game.</param>
        /// <param name="firingMode">Optional specification of firing mode.</param>
        /// <param name="displayHandler">Handler that will display the messages from the state machine.</param>
        public GameState(GameStates initialState, FiringMode firingMode, IDisplayHandler displayHandler) : base(initialState, firingMode)
        {
            Initialize(displayHandler);
            SetupStateMachine();
        }

        /// <summary>
        ///     Handles initialization for any instance variables of this class.
        /// </summary>
        /// <param name="displayHandler">The display handler to use.</param>
        private void Initialize(IDisplayHandler displayHandler)
        {
            _displayHandler = displayHandler;
            _labelRetriever = LabelRetriever.GetLabelRetriever();
        }

        /// <summary>
        ///     Sets up the state machine.
        /// </summary>
        private void SetupStateMachine()
        {
            ConfigureStateMachineForGameStatesNone();
            ConfigureStateMachineForGameStatesPlaying();
            ConfigureStateMachineForGameStatesGameOver();
        }

        /// <summary>
        ///     Configures the initial state of the application.
        /// </summary>
        private void ConfigureStateMachineForGameStatesNone()
        {
            var onEntryMessage = _labelRetriever.GetLabel("Application started.");

            Configure(GameNotStarted)
                .OnEntry(() => _displayHandler.DisplayMessage(onEntryMessage))
                .Permit(GameStateTriggers.StartGame, UserPlayingGame)
                .Ignore(GameStateTriggers.StopGame);
        }

        /// <summary>
        ///     Configures game start state.
        /// </summary>
        private void ConfigureStateMachineForGameStatesPlaying()
        {
            var onEntryMessage = _labelRetriever.GetLabel("GameStart");

            Configure(UserPlayingGame)
                .OnEntry(() => _displayHandler.DisplayMessage(onEntryMessage))
                .Permit(GameStateTriggers.StopGame, UserFinishedPlaying)
                .Ignore(GameStateTriggers.StartGame);
        }

        /// <summary>
        ///     Configures game over state.
        /// </summary>
        private void ConfigureStateMachineForGameStatesGameOver()
        {
            var onEntryMessage = _labelRetriever.GetLabel("GameOver");

            Configure(UserFinishedPlaying)
                .OnEntry(() => _displayHandler.DisplayMessage(onEntryMessage))
                .Ignore(GameStateTriggers.StartGame)
                .Ignore(GameStateTriggers.StopGame);
        }
    }
}
