namespace LabyrinthBusinessLogic.StateMachines.States
{
    /// <summary>
    ///     The game board
    /// </summary>
    public enum WorldMap
    {
        None,
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
