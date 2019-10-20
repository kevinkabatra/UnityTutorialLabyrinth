namespace LabyrinthBusinessLogicUnitTests.StateMachines
{
    using LabyrinthBusinessLogic.Handlers.Displays;
    using LabyrinthBusinessLogic.StateMachines;
    using LabyrinthBusinessLogic.StateMachines.States;
    using LabyrinthBusinessLogic.StateMachines.Triggers;
    using Moq;
    using Stateless;
    using Xunit;

    public class GameStateTests
    {
        private readonly Mock<IDisplayHandler> _mockDisplayHandler;

        public GameStateTests()
        {
            _mockDisplayHandler = new Mock<IDisplayHandler>();
            _mockDisplayHandler.Setup(mock => mock.DisplayMessage(It.IsAny<string>()));
        }

        [Fact]
        public void CanCreateStateMachine()
        {
            var displayHandler = _mockDisplayHandler.Object;
            const GameStates gameState = GameStates.None;
            
            var stateMachine = new GameState(gameState, displayHandler);

            Assert.NotNull(stateMachine);
        }

        [Fact]
        public void CanCreateStateMachineWithSpecifiedFiringMode()
        {
            var displayHandler = _mockDisplayHandler.Object;
            const GameStates gameState = GameStates.None;
            const FiringMode queuedFiringMode = FiringMode.Queued;
            
            var stateMachine = new GameState(gameState, queuedFiringMode, displayHandler);

            Assert.NotNull(stateMachine);
        }

        [Fact]
        public void CanTransitionStateMachineFromNoneToPlaying()
        {
            var displayHandler = _mockDisplayHandler.Object;
            const GameStates gameState = GameStates.None;
            
            var stateMachine = new GameState(gameState, displayHandler);
            stateMachine.Fire(GameStateTriggers.StartGame);

            const GameStates expectedState = GameStates.Playing;
            var actualState = stateMachine.State;

            Assert.Equal(expectedState, actualState);
            _mockDisplayHandler.Verify(mock => mock.DisplayMessage(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void CanTransitionStateMachineFromPayingToGameOver()
        {
            var displayHandler = _mockDisplayHandler.Object;
            const GameStates gameState = GameStates.Playing;

            var stateMachine = new GameState(gameState, displayHandler);
            stateMachine.Fire(GameStateTriggers.StopGame);

            const GameStates expectedState = GameStates.GameOver;
            var actualState = stateMachine.State;

            Assert.Equal(expectedState, actualState);
            _mockDisplayHandler.Verify(mock => mock.DisplayMessage(It.IsAny<string>()), Times.Once);
        }
    }
}
