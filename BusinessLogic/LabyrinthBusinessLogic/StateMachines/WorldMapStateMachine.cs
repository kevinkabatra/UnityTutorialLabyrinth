namespace LabyrinthBusinessLogic.StateMachines
{
    using Handlers.Displays;
    using States;
    using Triggers;

    /// <summary>
    ///     State machine to control the user's position within the world.
    /// </summary>
    /// <seealso href="https://refactoring.guru/design-patterns/state"/>
    /// <seealso href="https://github.com/dotnet-state-machine/stateless"/>
    public class WorldMapStateMachine : StateMachineAbstract<WorldMap, PlayerMovement>
    {
        /// <inheritdoc cref="StateMachineAbstract{TState,TTrigger}"/>
        public WorldMapStateMachine(WorldMap initialState, IDisplayHandler displayHandler) : base(initialState, displayHandler)
        {
            SetupStateMachine();
        }

        /// <inheritdoc cref="StateMachineAbstract{TState,TTrigger}"/>
        private protected sealed override void SetupStateMachine()
        {
            ConfigureForStateNone();
            ConfigureFirstPiece();
            ConfigureSecondPiece();
            ConfigureThirdPiece();
            ConfigureFourthPiece();
            ConfigureFifthPiece();
            ConfigureSixthPiece();
            ConfigureSeventhPiece();
            ConfigureEighthPiece();
            ConfigureNinthPiece();
            ConfigureTenthPiece();
            ConfigureEleventhPiece();
            ConfigureTwelfthPiece();
        }

        private void ConfigureForStateNone()
        {
            Configure(WorldMap.None)
                .Permit(PlayerMovement.Forward, WorldMap.FirstPieceStart)
                .Ignore(PlayerMovement.Backward)
                .Ignore(PlayerMovement.Left)
                .Ignore(PlayerMovement.Right);
        }

        /// <summary>
        ///     Configures player allowed movement for this piece.
        /// </summary>
        private void ConfigureFirstPiece()
        {
            Configure(WorldMap.FirstPieceStart)
                .OnEntry(() => DisplayHandler.DisplayMessage(LabelRetriever.ForwardOnlyMovement))
                .OnEntry(() => DisplayHandler.DisplayStart())
                .Permit(PlayerMovement.Forward, WorldMap.SecondPieceVerticalPipe)
                .Ignore(PlayerMovement.Backward)
                .Ignore(PlayerMovement.Left)
                .Ignore(PlayerMovement.Right);
        }

        /// <summary>
        ///     Configures player allowed movement for this piece.
        /// </summary>
        private void ConfigureSecondPiece()
        {
            Configure(WorldMap.SecondPieceVerticalPipe)
                .OnEntry(() => DisplayHandler.DisplayMessage(LabelRetriever.ForwardOrBackwardMovement))
                .OnEntry(DisplayHandler.DisplayVerticalPipe)
                .Permit(PlayerMovement.Forward, WorldMap.ThirdPieceVerticalPipe)
                .Permit(PlayerMovement.Backward, WorldMap.FirstPieceStart)
                .Ignore(PlayerMovement.Left)
                .Ignore(PlayerMovement.Right);
        }

        /// <summary>
        ///     Configures player allowed movement for this piece.
        /// </summary>
        private void ConfigureThirdPiece()
        {
            Configure(WorldMap.ThirdPieceVerticalPipe)
                .OnEntry(() => DisplayHandler.DisplayMessage(LabelRetriever.ForwardOrBackwardMovement))
                .OnEntry(DisplayHandler.DisplayVerticalPipe)
                .OnEntry(DisplayHandler.DisplayVerticalPipeModifier)
                .Permit(PlayerMovement.Forward, WorldMap.FourthPieceVerticalT)
                .Permit(PlayerMovement.Backward, WorldMap.SecondPieceVerticalPipe)
                .Ignore(PlayerMovement.Left)
                .Ignore(PlayerMovement.Right);
        }

        /// <summary>
        ///     Configures player allowed movement for this piece.
        /// </summary>
        private void ConfigureFourthPiece()
        {
            Configure(WorldMap.FourthPieceVerticalT)
                .OnEntry(() => DisplayHandler.DisplayMessage(LabelRetriever.BackwardOrRightMovement))
                .OnEntry(() => DisplayHandler.DisplayVerticalT())
                .Ignore(PlayerMovement.Forward)
                .Permit(PlayerMovement.Backward, WorldMap.ThirdPieceVerticalPipe)
                .Ignore(PlayerMovement.Left) //ToDo: add additional pieces to turn left
                .Permit(PlayerMovement.Right, WorldMap.FifthPieceHorizontalPipe);
        }

        /// <summary>
        ///     Configures player allowed movement for this piece.
        /// </summary>
        private void ConfigureFifthPiece()
        {
            Configure(WorldMap.FifthPieceHorizontalPipe)
                .OnEntry(() => DisplayHandler.DisplayMessage(LabelRetriever.LeftOrRightMovement))
                .OnEntry(() => DisplayHandler.DisplayHorizontalPipe())
                .Ignore(PlayerMovement.Forward)
                .Ignore(PlayerMovement.Backward)
                .Permit(PlayerMovement.Left, WorldMap.FourthPieceVerticalT)
                .Permit(PlayerMovement.Right, WorldMap.SixthPieceFlippedLeftAngle);
        }

        /// <summary>
        ///     Configures player allowed movement for this piece.
        /// </summary>
        private void ConfigureSixthPiece()
        {
            Configure(WorldMap.SixthPieceFlippedLeftAngle)
                .OnEntry(() => DisplayHandler.DisplayMessage(LabelRetriever.ForwardOrLeftMovement))
                .OnEntry(() => DisplayHandler.DisplayFlippedLeftAngle())
                .Permit(PlayerMovement.Forward, WorldMap.SeventhPieceLeftAngle)
                .Ignore(PlayerMovement.Backward)
                .Permit(PlayerMovement.Left, WorldMap.FifthPieceHorizontalPipe)
                .Ignore(PlayerMovement.Right);
        }

        /// <summary>
        ///     Configures player allowed movement for this piece.
        /// </summary>
        private void ConfigureSeventhPiece()
        {
            Configure(WorldMap.SeventhPieceLeftAngle)
                .OnEntry(() => DisplayHandler.DisplayMessage(LabelRetriever.BackwardOrLeftMovement))
                .OnEntry(() => DisplayHandler.DisplayLeftAngle())
                .Ignore(PlayerMovement.Forward)
                .Permit(PlayerMovement.Backward, WorldMap.SixthPieceFlippedLeftAngle)
                .Permit(PlayerMovement.Left, WorldMap.EighthPieceHorizontalPipe)
                .Ignore(PlayerMovement.Right);

        }

        /// <summary>
        ///     Configures player allowed movement for this piece.
        /// </summary>
        private void ConfigureEighthPiece()
        {
            Configure(WorldMap.EighthPieceHorizontalPipe)
                .OnEntry(() => DisplayHandler.DisplayMessage(LabelRetriever.LeftOrRightMovement))
                .OnEntry(() => DisplayHandler.DisplayHorizontalPipe())
                .Ignore(PlayerMovement.Forward)
                .Ignore(PlayerMovement.Backward)
                .Permit(PlayerMovement.Left, WorldMap.NinthPieceFlippedHorizontalT)
                .Permit(PlayerMovement.Right, WorldMap.SeventhPieceLeftAngle);
        }

        /// <summary>
        ///     Configures player allowed movement for this piece.
        /// </summary>
        private void ConfigureNinthPiece()
        {
            Configure(WorldMap.NinthPieceFlippedHorizontalT)
                .OnEntry(() => DisplayHandler.DisplayMessage(LabelRetriever.ForwardOrRightMovement))
                .OnEntry(() => DisplayHandler.DisplayFlippedHorizontalT())
                .Permit(PlayerMovement.Forward, WorldMap.TenthPieceLeftAngle)
                .Ignore(PlayerMovement.Backward)
                .Ignore(PlayerMovement.Left) //ToDo: add additional pieces to turn left
                .Permit(PlayerMovement.Right, WorldMap.EighthPieceHorizontalPipe);
        }

        /// <summary>
        ///     Configures player allowed movement for this piece.
        /// </summary>
        private void ConfigureTenthPiece()
        {
            Configure(WorldMap.TenthPieceLeftAngle)
                .OnEntry(() => DisplayHandler.DisplayMessage(LabelRetriever.BackwardOrLeftMovement))
                .OnEntry(() => DisplayHandler.DisplayLeftAngle())
                .Ignore(PlayerMovement.Forward)
                .Permit(PlayerMovement.Backward, WorldMap.NinthPieceFlippedHorizontalT)
                .Permit(PlayerMovement.Left, WorldMap.EleventhPieceFlippedRightAngle)
                .Ignore(PlayerMovement.Right);
        }

        /// <summary>
        ///     Configures player allowed movement for this piece.
        /// </summary>
        private void ConfigureEleventhPiece()
        {
            Configure(WorldMap.EleventhPieceFlippedRightAngle)
                .OnEntry(() => DisplayHandler.DisplayMessage(LabelRetriever.ForwardOrRightMovement))
                .OnEntry(() => DisplayHandler.DisplayFlippedRightAngle())
                .Permit(PlayerMovement.Forward, WorldMap.TwelfthPieceExit)
                .Ignore(PlayerMovement.Backward)
                .Ignore(PlayerMovement.Left)
                .Permit(PlayerMovement.Right, WorldMap.TenthPieceLeftAngle);
        }

        /// <summary>
        ///     Configures player allowed movement for this piece.
        /// </summary>
        private void ConfigureTwelfthPiece()
        {
            Configure(WorldMap.TwelfthPieceExit)
                .OnEntry(() => DisplayHandler.DisplayMessage(LabelRetriever.GameOver))
                .OnEntry(()=> DisplayHandler.DisplayEnd())
                .Ignore(PlayerMovement.Forward)
                .Ignore(PlayerMovement.Backward)
                .Ignore(PlayerMovement.Left)
                .Ignore(PlayerMovement.Right);
        }
    }
}
