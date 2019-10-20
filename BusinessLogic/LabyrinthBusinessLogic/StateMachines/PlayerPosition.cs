namespace LabyrinthBusinessLogic.StateMachines
{
    using Handlers.Displays;
    using States;
    using Triggers;

    /// <summary>
    ///     The state machine to control the various positions of the player.
    /// </summary>
    public class PlayerPosition : StateMachineAbstract<GamePiece, PlayerMovement>
    {
        public TriggerWithParameters<GamePiece> PlayerMovementForward { get; private set; }
        public TriggerWithParameters<GamePiece> PlayerMovementBackward { get; private set; }
        public TriggerWithParameters<GamePiece> PlayerMovementLeft { get; private set; }
        public TriggerWithParameters<GamePiece> PlayerMovementRight { get; private set; }

        /// <inheritdoc cref="StateMachineAbstract{TState,TTrigger}"/>
        public PlayerPosition(GamePiece initialState, IDisplayHandler displayHandler) : base(initialState, displayHandler)
        {
            SetupTriggerParameters();
            SetupStateMachine();
        }

        /// <summary>
        ///     Sets up the player movement triggers to accept a game piece as a parameter. Used to determine movement between pieces.
        /// </summary>
        private void SetupTriggerParameters()
        {
            PlayerMovementForward = SetTriggerParameters<GamePiece>(PlayerMovement.Forward);
            PlayerMovementBackward = SetTriggerParameters<GamePiece>(PlayerMovement.Backward);
            PlayerMovementLeft = SetTriggerParameters<GamePiece>(PlayerMovement.Left);
            PlayerMovementRight = SetTriggerParameters<GamePiece>(PlayerMovement.Right);
        }

        /// <inheritdoc cref="StateMachineAbstract{TState,TTrigger}"/>
        private protected sealed override void SetupStateMachine()
        {
            ConfigureStateMachineForGamePieceVerticalPipe();
            ConfigureStateMachineForGamePieceHorizontalPipe();
            ConfigureStateMachineForGamePieceVerticalT();
            ConfigureStateMachineForGamePieceHorizontalT();
            ConfigureStateMachineForGamePieceFlippedVerticalT();
            ConfigureStateMachineForGamePieceFlippedHorizontalT();
            ConfigureStateMachineForGamePieceLeftTurnRightAngle();
            ConfigureStateMachineForGamePieceRightTurnRightAngle();
        }

        /// <summary>
        ///     Configures the paths that a player may travel when in a vertical pipe. 
        /// </summary>
        private void ConfigureStateMachineForGamePieceVerticalPipe()
        {
            Configure(GamePiece.VerticalPipe)
                #region Permit forward movement to
                .PermitReentryIf(
                    PlayerMovementForward,
                    destinationGamePiece => destinationGamePiece == GamePiece.VerticalPipe
                )
                .PermitIf(
                    PlayerMovementForward,
                    GamePiece.VerticalT,
                    destinationGamePiece => destinationGamePiece == GamePiece.VerticalT
                )
                .PermitIf(
                    PlayerMovementForward,
                    GamePiece.HorizontalT,
                    destinationGamePiece => destinationGamePiece == GamePiece.HorizontalT
                )
                .PermitIf(
                    PlayerMovementForward,
                    GamePiece.FlippedHorizontalT,
                    destinationGamePiece => destinationGamePiece == GamePiece.FlippedHorizontalT
                )
                .PermitIf(
                    PlayerMovementForward,
                    GamePiece.LeftTurnRightAngle,
                    destinationGamePiece => destinationGamePiece == GamePiece.LeftTurnRightAngle
                )
                .PermitIf(
                    PlayerMovementForward,
                    GamePiece.RightTurnRightAngle,
                    destinationGamePiece => destinationGamePiece == GamePiece.RightTurnRightAngle
                )
                #endregion

                #region Permit backward movement to
                .PermitReentryIf(
                    PlayerMovementBackward,
                    destinationGamePiece => destinationGamePiece == GamePiece.VerticalPipe
                )
                .PermitIf(
                    PlayerMovementBackward,
                    GamePiece.FlippedVerticalT,
                    destinationGamePiece => destinationGamePiece == GamePiece.FlippedVerticalT
                )
                .PermitIf(
                    PlayerMovementBackward,
                    GamePiece.HorizontalT,
                    destinationGamePiece => destinationGamePiece == GamePiece.HorizontalT
                )
                .PermitIf(
                    PlayerMovementBackward,
                    GamePiece.FlippedHorizontalT,
                    destinationGamePiece => destinationGamePiece == GamePiece.FlippedHorizontalT
                )
                #endregion

                #region Prevent forward movement to
                .IgnoreIf(
                    PlayerMovementForward,
                    destinationGamePiece => destinationGamePiece == GamePiece.HorizontalPipe
                )
                .IgnoreIf(
                    PlayerMovementForward,
                    destinationGamePiece => destinationGamePiece == GamePiece.FlippedVerticalT
                )
                #endregion

                #region Prevent backward movement to
                .IgnoreIf(
                    PlayerMovementBackward,
                    destinationGamePiece => destinationGamePiece == GamePiece.HorizontalPipe
                )
                .IgnoreIf(
                    PlayerMovementBackward,
                    destinationGamePiece => destinationGamePiece == GamePiece.VerticalT
                )
                .IgnoreIf(
                    PlayerMovementBackward,
                    destinationGamePiece => destinationGamePiece == GamePiece.LeftTurnRightAngle
                )
                .IgnoreIf(
                    PlayerMovementBackward,
                    destinationGamePiece => destinationGamePiece == GamePiece.RightTurnRightAngle
                )
                #endregion

                #region Ignore impossible movement
                .IgnoreIf(
                    PlayerMovementLeft
                )
                .IgnoreIf(
                    PlayerMovementRight
                );
                #endregion
        }

        private void ConfigureStateMachineForGamePieceHorizontalPipe()
        {
            Configure(GamePiece.HorizontalPipe);
        }

        private void ConfigureStateMachineForGamePieceVerticalT()
        {
            Configure(GamePiece.VerticalT);
        }

        private void ConfigureStateMachineForGamePieceHorizontalT()
        {
            Configure(GamePiece.HorizontalT);
        }

        private void ConfigureStateMachineForGamePieceFlippedVerticalT()
        {
            Configure(GamePiece.FlippedVerticalT);
        }

        private void ConfigureStateMachineForGamePieceFlippedHorizontalT()
        {
            Configure(GamePiece.FlippedHorizontalT);
        }

        private void ConfigureStateMachineForGamePieceLeftTurnRightAngle()
        {
            Configure(GamePiece.LeftTurnRightAngle);
        }

        private void ConfigureStateMachineForGamePieceRightTurnRightAngle()
        {
            Configure(GamePiece.RightTurnRightAngle);
        }
    }
}
