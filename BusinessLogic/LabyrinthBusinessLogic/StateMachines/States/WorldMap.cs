namespace LabyrinthBusinessLogic.StateMachines.States
{
    /// <summary>
    ///     The game board
    /// </summary>
    public enum WorldMap
    {
        FirstPieceStart,
        SecondPieceVerticalPipe,
        ThirdPieceVerticalPipe,
        FourthPieceVerticalT,
        FifthPieceHorizontalPipe,
        SixthPieceFlippedLeftAngle,
        SeventhPieceLeftAngle,
        EighthPieceHorizontalPipe,
        NinthPieceFlippedHorizontalT,
        TenthPieceLeftAngle,
        EleventhPieceFlippedRightAngle,
        TwelfthPieceExit
    }
}
