namespace LabyrinthBusinessLogic.StateMachines.States
{
    /// <summary>
    ///     The various pieces that will make up the labyrinth.
    /// </summary>
    public enum GamePiece
    {
        Start,
        VerticalPipe,
        HorizontalPipe,
        VerticalT,
        HorizontalT,
        FlippedVerticalT,
        FlippedHorizontalT,
        LeftTurnRightAngle,
        RightTurnRightAngle,
        FlippedLeftTurnRightAngle,
        FlippedRightTurnRightAngle,
        Exit
    }
}
