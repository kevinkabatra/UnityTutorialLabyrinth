namespace LabyrinthBusinessLogicUnitTests.Utilities
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using LabyrinthBusinessLogic.Cultures;
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

        [Fact]
        public void CanRetrieveDefaultApplicationStartLabel()
        {
            var english = Languages.EnglishUnitedStates;
            var retriever = LabelRetriever.GetLabelRetriever(english);

            const string expectedLabelContent = "Application started.";
            var actualLabelContent = retriever.ApplicationStart;

            Assert.NotEmpty(actualLabelContent);
            Assert.Equal(expectedLabelContent, actualLabelContent);
        }

        [Fact]
        [SuppressMessage("ReSharper", "StringLiteralTypo", Justification = "Content written in Spanish.")]
        public void CanRetrieveTranslatedApplicationStartLabel()
        {
            var spanish = Languages.SpanishSpain;
            var retriever = LabelRetriever.GetLabelRetriever(spanish);

            const string expectedLabelContent = "Programa iniciado.";
            var actualLabelContent = retriever.ApplicationStart;

            Assert.NotEmpty(actualLabelContent);
            Assert.Equal(expectedLabelContent, actualLabelContent);
        }
    }
}
