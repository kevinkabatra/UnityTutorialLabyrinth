namespace LabyrinthBusinessLogic.Cultures
{
    /// <summary>
    ///     Sets the culture for the application, used to control translation.
    /// </summary>
    /// <seealso href="http://www.lingoes.net/en/translator/langcode.htm"/>
    public class Cultures
    {
        public string Value { get; set; }

        public static Cultures EnglishUnitedStates => new Cultures("en-US");
        public static Cultures SpanishSpain => new Cultures("es-ES");

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="value">The Culture Info that will be used for translation.</param>
        private Cultures(string value)
        {
            Value = value;
        }
    }
}
