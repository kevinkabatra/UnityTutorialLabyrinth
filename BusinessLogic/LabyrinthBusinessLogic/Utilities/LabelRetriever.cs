namespace LabyrinthBusinessLogic.Utilities
{
    using System.Diagnostics.CodeAnalysis;
    using Kabatra.Common.LabelRetriever.Cultures;
    using Properties;

    /// <summary>
    ///     Supports getting labels from a language specific resource file.
    /// </summary>
    /// <seealso href="https://refactoring.guru/design-patterns/singleton"/>
    /// <remarks>Singleton class.</remarks>
    [SuppressMessage("Microsoft.Performance","CA1822", Justification = "Instance determines translation")]
    public class LabelRetriever : Kabatra.Common.LabelRetriever.LabelRetriever
    {
        #region  Movement labels
        public string PlayerMovingForward => Labels.PlayerMovingForward;
        public string PlayerMovingBackward => Labels.PlayerMovingBackward;
        public string PlayerMovingLeft => Labels.PlayerMovingLeft;
        public string PlayerMovingRight => Labels.PlayerMovingRight;
        #endregion

        #region User instruction labels
        public string ForwardOnlyMovement => Labels.ForwardOnlyMovement;
        public string ForwardOrBackwardMovement => Labels.ForwardOrBackwardMovement;
        public string ForwardOrLeftMovement => Labels.ForwardOrLeftMovement;
        public string ForwardOrRightMovement => Labels.ForwardOrRightMovement;
        public string BackwardOrLeftMovement => Labels.BackwardOrLeftMovement;
        public string BackwardOrRightMovement => Labels.BackwardOrRightMovement;
        public string LeftOrRightMovement => Labels.LeftOrRightMovement;
        #endregion

        protected LabelRetriever(Languages language) : base(language)
        {
        }
    }
}
