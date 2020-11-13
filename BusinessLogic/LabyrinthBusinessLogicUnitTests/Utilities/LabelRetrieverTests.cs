namespace LabyrinthBusinessLogicUnitTests.Utilities
{
    using System;
    using LabyrinthBusinessLogic.Utilities;
    using Xunit;

    /// <summary>
    ///     Unit tests that exercise the label retriever.
    /// </summary>
    public class LabelRetrieverTests : IDisposable
    {
        /// <summary>
        ///     Need to reset the singleton after each test.
        /// </summary>
        public void Dispose()
        {
            LabelRetriever.Reset();
        }

        [Fact]
        public void CanCreateLabelRetriever()
        {
            var retriever = LabelRetriever.GetLabelRetriever();

            Assert.NotNull(retriever);
        }
    }
}
