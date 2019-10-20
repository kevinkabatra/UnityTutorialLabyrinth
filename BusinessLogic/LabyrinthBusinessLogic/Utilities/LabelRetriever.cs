namespace LabyrinthBusinessLogic.Utilities
{
    using System.Globalization;
    using System.Threading;
    using Cultures;
    using Properties;

    /// <summary>
    ///     Supports getting labels from a language specific resource file.
    /// </summary>
    /// <remarks>Singleton class.</remarks>
    public class LabelRetriever : ILabelRetriever
    {
        private static LabelRetriever _retriever;
        private static readonly object ThreadSafeLock = new object();

        public string ApplicationStart => Labels.ApplicationStart;
        public string GameStart =>  Labels.GameStart;
        public string GameOver => Labels.GameOver;

        /// <summary>
        ///     Returns a singleton instance of <c>LabelRetriever</c>.
        /// </summary>
        /// <param name="language"></param>
        /// <returns><c>LabelRetriever</c></returns>
        /// <seealso href="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/lock-statement"/>
        public static LabelRetriever GetLabelRetriever(Cultures language = null)
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
        public void Reset()
        {
            lock (ThreadSafeLock)
            {
                _retriever = null;
            }
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="language">The language that will be used for translation purposes.</param>
        /// <remarks>If language is left null, will default to English United States.</remarks>
        private LabelRetriever(Cultures language)
        {
            var languageValue = (language ?? Cultures.EnglishUnitedStates).Value;
            var cultureInfo = CultureInfo.CreateSpecificCulture(languageValue);
            SetCultureTo(cultureInfo);
        }

        /// <summary>
        ///     Sets the Culture for the current thread.
        /// </summary>
        /// <param name="culture">Which culture are we using for our translations.</param>
        private static void SetCultureTo(CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
        }
    }
}
