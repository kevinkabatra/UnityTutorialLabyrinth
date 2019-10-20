namespace LabyrinthBusinessLogicUnitTests.Utilities
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using LabyrinthBusinessLogic.Cultures;
    using LabyrinthBusinessLogic.Utilities;
    using Xunit;

    public class LabelRetrieverTests : IDisposable
    {
        /// <summary>
        ///     Need to reset the singleton after each test.
        /// </summary>
        public void Dispose()
        {
            var retriever = LabelRetriever.GetLabelRetriever();
            retriever.Reset();
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
            var english = Cultures.EnglishUnitedStates;
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
            var spanish = Cultures.SpanishSpain;
            var retriever = LabelRetriever.GetLabelRetriever(spanish);

            const string expectedLabelContent = "Programa iniciado.";
            var actualLabelContent = retriever.ApplicationStart;

            Assert.NotEmpty(actualLabelContent);
            Assert.Equal(expectedLabelContent, actualLabelContent);
        }
    }
}
