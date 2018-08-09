namespace TestWebApp.Models
{
    public interface ICodebookEntityWithDescription
    {
        /// <summary>
        /// Gets the entity identifier.
        /// </summary>
        short Id { get; }

        /// <summary>
        /// Gets the entity code.
        /// </summary>
        string Code { get; }

        /// <summary>
        /// Gets the entity description.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Gets the entity resource key for localization description.
        /// </summary>
        string ResourceKey { get; }
    }
}
