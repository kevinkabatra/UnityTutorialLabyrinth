namespace LabyrinthBusinessLogicUnitTests.StateMachines
{
    using LabyrinthBusinessLogic.StateMachines;
    using LabyrinthBusinessLogic.StateMachines.States;
    using LabyrinthBusinessLogic.StateMachines.Triggers;
    using Moq;
    using Xunit;

    /// <summary>
    ///     Unit tests that exercise the World Map state machine,
    /// also ensures that game can be completed as expected.
    /// </summary>
    public class WorldMapStateMachineTests : StateMachineTestAbstract
    {
        [Fact]
        public void CanCreateStateMachine()
        {
            var displayHandler = MockDisplayHandler.Object;
            const WorldMap worldMapPosition = WorldMap.FirstPieceStart;

            var stateMachine = new WorldMapStateMachine(worldMapPosition, displayHandler);

            Assert.NotNull(stateMachine);
        }

        [Fact]
        public void CanTransitionStateMachineFromStartToSecondPiece()
        {
            var displayHandler = MockDisplayHandler.Object;
            const WorldMap worldMapPosition = WorldMap.FirstPieceStart;

            var stateMachine = new WorldMapStateMachine(worldMapPosition, displayHandler);
            stateMachine.Fire(PlayerMovement.Forward);

            const WorldMap expectedWorldMapPosition = WorldMap.SecondPieceVerticalPipe;
            var actualWorldMapPosition = stateMachine.State;

            Assert.Equal(expectedWorldMapPosition, actualWorldMapPosition);
            MockDisplayHandler.Verify(mock => mock.DisplayMessage(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void CanTransitionStateMachineFromSecondPieceToThirdPiece()
        {
            var displayHandler = MockDisplayHandler.Object;
            const WorldMap worldMapPosition = WorldMap.SecondPieceVerticalPipe;

            var stateMachine = new WorldMapStateMachine(worldMapPosition, displayHandler);
            stateMachine.Fire(PlayerMovement.Forward);

            const WorldMap expectedWorldMapPosition = WorldMap.ThirdPieceVerticalPipe;
            var actualWorldMapPosition = stateMachine.State;

            Assert.Equal(expectedWorldMapPosition, actualWorldMapPosition);
            MockDisplayHandler.Verify(mock => mock.DisplayMessage(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void CanTransitionStateMachineFromThirdPieceToFourthPiece()
        {
            var displayHandler = MockDisplayHandler.Object;
            const WorldMap worldMapPosition = WorldMap.ThirdPieceVerticalPipe;

            var stateMachine = new WorldMapStateMachine(worldMapPosition, displayHandler);
            stateMachine.Fire(PlayerMovement.Forward);

            const WorldMap expectedWorldMapPosition = WorldMap.FourthPieceVerticalT;
            var actualWorldMapPosition = stateMachine.State;

            Assert.Equal(expectedWorldMapPosition, actualWorldMapPosition);
            MockDisplayHandler.Verify(mock => mock.DisplayMessage(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void CanTransitionStateMachineFromFourthPieceToFifthPiece()
        {
            var displayHandler = MockDisplayHandler.Object;
            const WorldMap worldMapPosition = WorldMap.FourthPieceVerticalT;

            var stateMachine = new WorldMapStateMachine(worldMapPosition, displayHandler);
            stateMachine.Fire(PlayerMovement.Right);

            const WorldMap expectedWorldMapPosition = WorldMap.FifthPieceHorizontalPipe;
            var actualWorldMapPosition = stateMachine.State;

            Assert.Equal(expectedWorldMapPosition, actualWorldMapPosition);
            MockDisplayHandler.Verify(mock => mock.DisplayMessage(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void CanTransitionStateMachineFromFifthPieceToSixthPiece()
        {
            var displayHandler = MockDisplayHandler.Object;
            const WorldMap worldMapPosition = WorldMap.FifthPieceHorizontalPipe;

            var stateMachine = new WorldMapStateMachine(worldMapPosition, displayHandler);
            stateMachine.Fire(PlayerMovement.Right);

            const WorldMap expectedWorldMapPosition = WorldMap.SixthPieceFlippedLeftAngle;
            var actualWorldMapPosition = stateMachine.State;

            Assert.Equal(expectedWorldMapPosition, actualWorldMapPosition);
            MockDisplayHandler.Verify(mock => mock.DisplayMessage(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void CanTransitionStateMachineFromSixthPieceToSeventhPiece()
        {
            var displayHandler = MockDisplayHandler.Object;
            const WorldMap worldMapPosition = WorldMap.SixthPieceFlippedLeftAngle;

            var stateMachine = new WorldMapStateMachine(worldMapPosition, displayHandler);
            stateMachine.Fire(PlayerMovement.Forward);

            const WorldMap expectedWorldMapPosition = WorldMap.SeventhPieceLeftAngle;
            var actualWorldMapPosition = stateMachine.State;

            Assert.Equal(expectedWorldMapPosition, actualWorldMapPosition);
            MockDisplayHandler.Verify(mock => mock.DisplayMessage(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void CanTransitionStateMachineFromSeventhPieceToEighthPiece()
        {
            var displayHandler = MockDisplayHandler.Object;
            const WorldMap worldMapPosition = WorldMap.SeventhPieceLeftAngle;

            var stateMachine = new WorldMapStateMachine(worldMapPosition, displayHandler);
            stateMachine.Fire(PlayerMovement.Left);

            const WorldMap expectedWorldMapPosition = WorldMap.EighthPieceHorizontalPipe;
            var actualWorldMapPosition = stateMachine.State;

            Assert.Equal(expectedWorldMapPosition, actualWorldMapPosition);
            MockDisplayHandler.Verify(mock => mock.DisplayMessage(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void CanTransitionStateMachineFromEighthPieceToNinthPiece()
        {
            var displayHandler = MockDisplayHandler.Object;
            const WorldMap worldMapPosition = WorldMap.EighthPieceHorizontalPipe;

            var stateMachine = new WorldMapStateMachine(worldMapPosition, displayHandler);
            stateMachine.Fire(PlayerMovement.Left);

            const WorldMap expectedWorldMapPosition = WorldMap.NinthPieceFlippedHorizontalT;
            var actualWorldMapPosition = stateMachine.State;

            Assert.Equal(expectedWorldMapPosition, actualWorldMapPosition);
            MockDisplayHandler.Verify(mock => mock.DisplayMessage(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void CanTransitionStateMachineFromNinthPieceToTenthPiece()
        {
            var displayHandler = MockDisplayHandler.Object;
            const WorldMap worldMapPosition = WorldMap.NinthPieceFlippedHorizontalT;

            var stateMachine = new WorldMapStateMachine(worldMapPosition, displayHandler);
            stateMachine.Fire(PlayerMovement.Forward);

            const WorldMap expectedWorldMapPosition = WorldMap.TenthPieceLeftAngle;
            var actualWorldMapPosition = stateMachine.State;

            Assert.Equal(expectedWorldMapPosition, actualWorldMapPosition);
            MockDisplayHandler.Verify(mock => mock.DisplayMessage(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void CanTransitionStateMachineFromTenthPieceToEleventhPiece()
        {
            var displayHandler = MockDisplayHandler.Object;
            const WorldMap worldMapPosition = WorldMap.TenthPieceLeftAngle;

            var stateMachine = new WorldMapStateMachine(worldMapPosition, displayHandler);
            stateMachine.Fire(PlayerMovement.Left);

            const WorldMap expectedWorldMapPosition = WorldMap.EleventhPieceFlippedRightAngle;
            var actualWorldMapPosition = stateMachine.State;

            Assert.Equal(expectedWorldMapPosition, actualWorldMapPosition);
            MockDisplayHandler.Verify(mock => mock.DisplayMessage(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void CanTransitionStateMachineFromEleventhPieceToTwelfthPiece()
        {
            var displayHandler = MockDisplayHandler.Object;
            const WorldMap worldMapPosition = WorldMap.EleventhPieceFlippedRightAngle;

            var stateMachine = new WorldMapStateMachine(worldMapPosition, displayHandler);
            stateMachine.Fire(PlayerMovement.Forward);

            const WorldMap expectedWorldMapPosition = WorldMap.TwelfthPieceExit;
            var actualWorldMapPosition = stateMachine.State;

            Assert.Equal(expectedWorldMapPosition, actualWorldMapPosition);
            MockDisplayHandler.Verify(mock => mock.DisplayMessage(It.IsAny<string>()), Times.Once);
        }
    }
}
