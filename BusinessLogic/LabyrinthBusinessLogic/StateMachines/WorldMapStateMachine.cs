namespace LabyrinthBusinessLogic.StateMachines
{
    using Handlers.Displays;
    using States;
    using Triggers;

    public class WorldMapStateMachine : StateMachineAbstract<WorldMap, PlayerMovement>
    {
        public WorldMapStateMachine(WorldMap initialState, IDisplayHandler displayHandler) : base(initialState, displayHandler)
        {
            SetupStateMachine();
        }

        private protected sealed override void SetupStateMachine()
        {
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

        private void ConfigureFirstPiece()
        {
            Configure(WorldMap.FirstPieceStart)
                .Permit(PlayerMovement.Forward, WorldMap.SecondPieceVerticalPipe)
                .Ignore(PlayerMovement.Backward)
                .Ignore(PlayerMovement.Left)
                .Ignore(PlayerMovement.Right);
        }

        private void ConfigureSecondPiece()
        {
            Configure(WorldMap.SecondPieceVerticalPipe)
                .Permit(PlayerMovement.Forward, WorldMap.ThirdPieceVerticalPipe)
                .Permit(PlayerMovement.Backward, WorldMap.FirstPieceStart)
                .Ignore(PlayerMovement.Left)
                .Ignore(PlayerMovement.Right);
        }

        private void ConfigureThirdPiece()
        {
            Configure(WorldMap.ThirdPieceVerticalPipe)
                .Permit(PlayerMovement.Forward, WorldMap.FourthPieceVerticalT)
                .Permit(PlayerMovement.Backward, WorldMap.SecondPieceVerticalPipe)
                .Ignore(PlayerMovement.Left)
                .Ignore(PlayerMovement.Right);
        }

        private void ConfigureFourthPiece()
        {
            Configure(WorldMap.FourthPieceVerticalT)
                .Ignore(PlayerMovement.Forward)
                .Permit(PlayerMovement.Backward, WorldMap.ThirdPieceVerticalPipe)
                .Ignore(PlayerMovement.Left) //ToDo: add additional pieces to turn left
                .Permit(PlayerMovement.Right, WorldMap.FifthPieceHorizontalPipe);
        }

        private void ConfigureFifthPiece()
        {
            Configure(WorldMap.FifthPieceHorizontalPipe)
                .Ignore(PlayerMovement.Forward)
                .Ignore(PlayerMovement.Backward)
                .Permit(PlayerMovement.Left, WorldMap.FourthPieceVerticalT)
                .Permit(PlayerMovement.Right, WorldMap.SixthPieceFlippedLeftAngle);
        }

        private void ConfigureSixthPiece()
        {
            Configure(WorldMap.SixthPieceFlippedLeftAngle)
                .Permit(PlayerMovement.Forward, WorldMap.SeventhPieceLeftAngle)
                .Ignore(PlayerMovement.Backward)
                .Permit(PlayerMovement.Left, WorldMap.SixthPieceFlippedLeftAngle)
                .Ignore(PlayerMovement.Right);
        }

        private void ConfigureSeventhPiece()
        {
            Configure(WorldMap.SeventhPieceLeftAngle)
                .Ignore(PlayerMovement.Forward)
                .Permit(PlayerMovement.Backward, WorldMap.SixthPieceFlippedLeftAngle)
                .Permit(PlayerMovement.Left, WorldMap.EighthPieceHorizontalPipe)
                .Ignore(PlayerMovement.Right);

        }

        private void ConfigureEighthPiece()
        {
            Configure(WorldMap.EighthPieceHorizontalPipe)
                .Ignore(PlayerMovement.Forward)
                .Ignore(PlayerMovement.Backward)
                .Permit(PlayerMovement.Left, WorldMap.NinthPieceFlippedHorizontalT)
                .Permit(PlayerMovement.Right, WorldMap.EighthPieceHorizontalPipe);
        }

        private void ConfigureNinthPiece()
        {
            Configure(WorldMap.NinthPieceFlippedHorizontalT)
                .Permit(PlayerMovement.Forward, WorldMap.TenthPieceLeftAngle)
                .Ignore(PlayerMovement.Backward)
                .Ignore(PlayerMovement.Left) //ToDo: add additional pieces to turn left
                .Permit(PlayerMovement.Right, WorldMap.EighthPieceHorizontalPipe);
        }

        private void ConfigureTenthPiece()
        {
            Configure(WorldMap.TenthPieceLeftAngle)
                .Ignore(PlayerMovement.Forward)
                .Permit(PlayerMovement.Backward, WorldMap.NinthPieceFlippedHorizontalT)
                .Permit(PlayerMovement.Left, WorldMap.EleventhPieceFlippedRightAngle)
                .Ignore(PlayerMovement.Right);
        }

        private void ConfigureEleventhPiece()
        {
            Configure(WorldMap.EleventhPieceFlippedRightAngle)
                .Permit(PlayerMovement.Forward, WorldMap.TwelfthPieceExit)
                .Ignore(PlayerMovement.Backward)
                .Ignore(PlayerMovement.Left)
                .Permit(PlayerMovement.Right, WorldMap.TenthPieceLeftAngle);
        }

        private void ConfigureTwelfthPiece()
        {
            Configure(WorldMap.TwelfthPieceExit)
                .Ignore(PlayerMovement.Forward)
                .Ignore(PlayerMovement.Backward)
                .Ignore(PlayerMovement.Left)
                .Ignore(PlayerMovement.Right);
        }
    }
}
