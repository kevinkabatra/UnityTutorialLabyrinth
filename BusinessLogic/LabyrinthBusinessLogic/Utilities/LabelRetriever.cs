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
        private static LabelRetriever _retriever;
        private static readonly object ThreadSafeLock = new object();

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

        /// <summary>
        ///     Returns a singleton instance of <c>LabelRetriever</c>.
        /// </summary>
        /// <param name="language"></param>
        /// <returns><c>LabelRetriever</c></returns>
        /// <seealso href="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/lock-statement"/>
        public static new LabelRetriever GetLabelRetriever(Languages language = null)
        {
            if (_retriever == null)
            {
                // lock will prevent multiple threads from attempting to create the singleton.
                lock (ThreadSafeLock)
                {
                    // should check conditional again, after lock is released the singleton would have been creates=d during a previous thread.
                    if (_retriever == null)
                    {
                        _retriever = new LabelRetriever(language);
                    }
                }
            }

            return _retriever;
        }

        /// <summary>
        ///     Resets the singleton, this is required for unit testing.
        /// </summary>
        public static new void Reset()
        {
            lock (ThreadSafeLock)
            {
                _retriever = null;
            }
        }

        protected LabelRetriever(Languages language) : base(language)
        {
        }
    }
}
