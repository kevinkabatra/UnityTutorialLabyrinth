namespace LabyrinthBusinessLogic.Cultures
{
    /// <summary>
    ///     Sets the culture for the application, used to control translation.
    /// </summary>
    /// <seealso href="http://www.lingoes.net/en/translator/langcode.htm"/>
    public class Languages
    {
        public string Value { get; set; }

        public static Languages EnglishUnitedStates => new Languages("en-US");
        public static Languages SpanishSpain => new Languages("es-ES");

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="value">The Culture Info that will be used for translation.</param>
        private Languages(string value)
        {
            Value = value;
        }
    }
}
