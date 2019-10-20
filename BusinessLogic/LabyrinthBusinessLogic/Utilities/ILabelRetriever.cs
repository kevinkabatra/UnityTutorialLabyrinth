namespace LabyrinthBusinessLogic.Utilities
{
    /// <summary>
    ///     Interface for displaying contents of labels using the auto-generated designer.
    /// </summary>
    public interface ILabelRetriever
    {
        string ApplicationStart { get; }
        string GameStart { get; }
        string GameOver { get; }
    }
}
