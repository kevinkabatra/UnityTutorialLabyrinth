namespace LabyrinthBusinessLogicUnitTests.StateMachines
{
    using LabyrinthBusinessLogic.StateMachines;
    using LabyrinthBusinessLogic.StateMachines.States;
    using LabyrinthBusinessLogic.StateMachines.Triggers;
    using Moq;
    using Xunit;

    /// <summary>
    ///     Unit tests that exercise the Game State state machine.
    /// </summary>
    public class GameStateStateMachineTests : StateMachineTestAbstract
    {
        [Fact]
        public void CanCreateStateMachine()
        {
            var displayHandler = MockDisplayHandler.Object;
            const GameState gameState = GameState.None;
            
            var stateMachine = new GameStateStateMachine(gameState, displayHandler);

            Assert.NotNull(stateMachine);
        }

        [Fact]
        public void CanTransitionStateMachineFromNoneToPlaying()
        {
            var displayHandler = MockDisplayHandler.Object;
            const GameState gameState = GameState.None;
            
            var stateMachine = new GameStateStateMachine(gameState, displayHandler);
            stateMachine.Fire(GameStateTrigger.StartGame);

            const GameState expectedState = GameState.Playing;
            var actualState = stateMachine.State;

            Assert.Equal(expectedState, actualState);
            MockDisplayHandler.Verify(mock => mock.DisplayMessage(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void CanTransitionStateMachineFromPayingToGameOver()
        {
            var displayHandler = MockDisplayHandler.Object;
            const GameState gameState = GameState.Playing;

            var stateMachine = new GameStateStateMachine(gameState, displayHandler);
            stateMachine.Fire(GameStateTrigger.StopGame);

            const GameState expectedState = GameState.GameOver;
            var actualState = stateMachine.State;

            Assert.Equal(expectedState, actualState);
            MockDisplayHandler.Verify(mock => mock.DisplayMessage(It.IsAny<string>()), Times.Once);
        }
    }
}
