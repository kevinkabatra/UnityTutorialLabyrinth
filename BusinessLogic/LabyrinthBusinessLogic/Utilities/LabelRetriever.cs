using System.Resources;

[assembly: NeutralResourcesLanguage("en-US")]

namespace LabyrinthBusinessLogic.Utilities
{
    using System;
    using System.Globalization;
    using System.Threading;
    using Cultures;
    using Properties;

    /// <summary>
    ///     Supports getting labels from a language specific resource file.
    /// </summary>
    public class LabelRetriever
    {
        private static LabelRetriever _retriever;
        private static readonly object ThreadSafeLock = new object();

        private ResourceManager _labelManager;
        private readonly Cultures _language;

        /// <summary>
        ///     Returns a specified label.
        /// </summary>
        /// <param name="key">The name of the label to return.</param>
        /// <returns>String. Representing the translated text of the label.</returns>
        public string GetLabel(string key)
        {
            var result = _labelManager.GetString(key);
            return result;
        }

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
            _language = language ?? Cultures.EnglishUnitedStates;

            SetCulture();
            SetResourceManager();
        }

        /// <summary>
        ///     Sets the Culture for the current thread.
        /// </summary>
        private void SetCulture()
        {
            var culture = CultureInfo.CreateSpecificCulture(_language.Value);
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
        }

        /// <summary>
        ///     Determines which label file to use for translation.
        /// </summary>
        private void SetResourceManager()
        {
            var language = _language.Value;

            if (language == Cultures.EnglishUnitedStates.Value)
            {
                _labelManager = Labels.ResourceManager;
            }
            else if (language == Cultures.SpanishSpain.Value)
            {
                _labelManager = Labels_es_ES.ResourceManager;
            }
            else
            {
                throw new NotSupportedException(nameof(language));
            }
        }
    }
}
