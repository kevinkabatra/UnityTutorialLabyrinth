namespace LabyrinthBusinessLogicUnitTests.StateMachines
{
    using LabyrinthBusinessLogic.Handlers.Displays;
    using LabyrinthBusinessLogic.StateMachines;
    using LabyrinthBusinessLogic.StateMachines.States;
    using LabyrinthBusinessLogic.StateMachines.Triggers;
    using Moq;
    using Stateless;
    using Xunit;
    using GameState = LabyrinthBusinessLogic.StateMachines.States.GameState;

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
            const GameState gameState = GameState.None;
            
            var stateMachine = new LabyrinthBusinessLogic.StateMachines.GameStateStateMachine(gameState, displayHandler);

            Assert.NotNull(stateMachine);
        }

        [Fact]
        public void CanTransitionStateMachineFromNoneToPlaying()
        {
            var displayHandler = _mockDisplayHandler.Object;
            const GameState gameState = GameState.None;
            
            var stateMachine = new LabyrinthBusinessLogic.StateMachines.GameStateStateMachine(gameState, displayHandler);
            stateMachine.Fire(GameStateTrigger.StartGame);

            const GameState expectedState = GameState.Playing;
            var actualState = stateMachine.State;

            Assert.Equal(expectedState, actualState);
            _mockDisplayHandler.Verify(mock => mock.DisplayMessage(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void CanTransitionStateMachineFromPayingToGameOver()
        {
            var displayHandler = _mockDisplayHandler.Object;
            const GameState gameState = GameState.Playing;

            var stateMachine = new LabyrinthBusinessLogic.StateMachines.GameStateStateMachine(gameState, displayHandler);
            stateMachine.Fire(GameStateTrigger.StopGame);

            const GameState expectedState = GameState.GameOver;
            var actualState = stateMachine.State;

            Assert.Equal(expectedState, actualState);
            _mockDisplayHandler.Verify(mock => mock.DisplayMessage(It.IsAny<string>()), Times.Once);
        }
    }
}
