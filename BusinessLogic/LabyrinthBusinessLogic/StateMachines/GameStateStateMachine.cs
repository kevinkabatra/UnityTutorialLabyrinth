namespace LabyrinthBusinessLogic.StateMachines
{
    using Handlers.Displays;
    using Triggers;

    /// <summary>
    ///     The state machine to control the various states of the game.
    /// </summary>
    /// <seealso href="https://refactoring.guru/design-patterns/state"/>
    /// <seealso href="https://github.com/dotnet-state-machine/stateless"/>
    public class GameStateStateMachine : StateMachineAbstract<States.GameState, GameStateTrigger>
    {
        private const States.GameState GameNotStarted = States.GameState.None;
        private const States.GameState UserPlayingGame = States.GameState.Playing;
        private const States.GameState UserFinishedPlaying = States.GameState.GameOver;

        /// <inheritdoc cref="StateMachineAbstract{TState,TTrigger}"/>
        public GameStateStateMachine(States.GameState initialState, IDisplayHandler displayHandler) : base(initialState, displayHandler)
        {
            SetupStateMachine();
        }

        /// <inheritdoc cref="StateMachineAbstract{TState,TTrigger}"/>
        private protected sealed override void SetupStateMachine()
        {
            ConfigureStateMachineForGameStateNone();
            ConfigureStateMachineForGameStatePlaying();
            ConfigureStateMachineForGameStateGameOver();
        }

        /// <summary>
        ///     Configures the initial state of the application.
        /// </summary>
        private void ConfigureStateMachineForGameStateNone()
        {
            Configure(GameNotStarted)
                .Permit(GameStateTrigger.StartGame, UserPlayingGame)
                .Ignore(GameStateTrigger.StopGame);
        }

        /// <summary>
        ///     Configures game start state.
        /// </summary>
        private void ConfigureStateMachineForGameStatePlaying()
        {
            var onEntryMessage = LabelRetriever.GameStart;

            Configure(UserPlayingGame)
                .OnEntry(() => DisplayHandler.DisplayMessage(onEntryMessage))
                .Permit(GameStateTrigger.StopGame, UserFinishedPlaying)
                .Ignore(GameStateTrigger.StartGame);
        }

        /// <summary>
        ///     Configures game over state.
        /// </summary>
        private void ConfigureStateMachineForGameStateGameOver()
        {
            var onEntryMessage = LabelRetriever.GameOver;

            Configure(UserFinishedPlaying)
                .OnEntry(() => DisplayHandler.DisplayMessage(onEntryMessage))
                .Ignore(GameStateTrigger.StartGame)
                .Ignore(GameStateTrigger.StopGame);
        }
    }
}
