namespace LabyrinthBusinessLogic.StateMachines
{
    using System;
    using Handlers.Displays;
    using Stateless;
    using Utilities;

    public abstract class StateMachineAbstract<TState, TTrigger> : StateMachine<TState, TTrigger>
    {
        private protected IDisplayHandler DisplayHandler;
        private protected LabelRetriever LabelRetriever;

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="stateAccessor">A function that will be called to read the current state value.</param>
        /// <param name="stateMutator">An action that will be called to write new state values.</param>
        protected StateMachineAbstract(Func<TState> stateAccessor, Action<TState> stateMutator) : base(stateAccessor, stateMutator)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Default constructor.
        /// </summary>
        /// <param name="initialState">Initial state to set the state machine to.</param>
        /// <param name="displayHandler">Handler that will display the messages from the state machine.</param>
        protected StateMachineAbstract(TState initialState, IDisplayHandler displayHandler) : base(initialState)
        {
            Initialize(displayHandler);
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="stateAccessor">A function that will be called to read the current state value.</param>
        /// <param name="stateMutator">An action that will be called to write new state values.</param>
        /// <param name="firingMode">Optional specification of firing mode.</param>
        protected StateMachineAbstract(Func<TState> stateAccessor, Action<TState> stateMutator, FiringMode firingMode) : base(stateAccessor, stateMutator, firingMode)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="initialState">The initial state of the game.</param>
        /// <param name="firingMode">Optional specification of firing mode.</param>
        protected StateMachineAbstract(TState initialState, FiringMode firingMode) : base(initialState, firingMode)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Handles initialization for any instance variables of this class.
        /// </summary>
        /// <param name="displayHandler">The display handler to use.</param>
        private void Initialize(IDisplayHandler displayHandler)
        {
            DisplayHandler = displayHandler;
            LabelRetriever = LabelRetriever.GetLabelRetriever();
        }

        /// <summary>
        ///     Sets up the state machine.
        /// </summary>
        private protected abstract void SetupStateMachine();
    }
}
