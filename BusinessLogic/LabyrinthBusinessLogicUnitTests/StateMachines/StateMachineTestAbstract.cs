namespace LabyrinthBusinessLogicUnitTests.StateMachines
{
    using LabyrinthBusinessLogic.Handlers.Displays;
    using Moq;

    /// <summary>
    ///     Abstract class to setup the unit tests for a state machine.
    /// </summary>
    public abstract class StateMachineTestAbstract
    {
        protected readonly Mock<IDisplayHandler> MockDisplayHandler;

        /// <summary>
        ///     Mock any dependencies.
        /// </summary>
        protected StateMachineTestAbstract()
        {
            MockDisplayHandler = new Mock<IDisplayHandler>();
            MockDisplayHandler.Setup(mock => mock.DisplayMessage(It.IsAny<string>()));
        }
    }
}
