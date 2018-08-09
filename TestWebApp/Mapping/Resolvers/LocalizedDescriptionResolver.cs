using AutoMapper;
using TestWebApp.Models;

namespace TestWebApp.Mapping.Resolvers
{
    /// <summary>
    /// Value resolver for getting localized description of a codebook.
    /// </summary>
    public class LocalizedDescriptionResolver : IValueResolver<ICodebookEntityWithDescription, CodebookWithDescription, string>
    {
        /// <summary>
        /// Gets the localized description by the resource key, or default.
        /// </summary>
        /// <param name="source">The source of the mapping.</param>
        /// <param name="destination">The destination of the mapping.</param>
        /// <param name="member">The member of destination.</param>
        /// <param name="context">Resolution context.</param>
        /// <returns>Localized description.</returns>
        public string Resolve(ICodebookEntityWithDescription source, CodebookWithDescription destination, string member, ResolutionContext context)
        {
            return source.Description ?? "something";
        }
    }
}