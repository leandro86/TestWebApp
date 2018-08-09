namespace TestWebApp.Models
{
    public class Language : CodebookWithDescription
    {
        /// <summary>
        /// Gets or sets the Iso 639-1 code of the language.
        /// </summary>
        public string Iso6391 { get; set; }

        /// <summary>
        /// Gets or sets the Iso 639-2 code of the language.
        /// </summary>
        public string Iso6392 { get; set; }
    }
}
