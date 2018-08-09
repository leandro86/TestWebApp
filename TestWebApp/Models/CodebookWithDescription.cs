namespace TestWebApp.Models
{
    public abstract class CodebookWithDescription
    {
        /// <summary>
        /// Gets or sets the unique code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the description text.
        /// </summary>
        public string Description { get; set; }
    }
}
