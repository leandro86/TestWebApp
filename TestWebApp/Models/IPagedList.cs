using System.Collections;

namespace TestWebApp.Models
{
    /// <summary>
    /// Defines a paged result.
    /// </summary>
    public interface IPagedList : ICollection
    {
        /// <summary>
        /// Gets the total count of elements in this page.
        /// </summary>
        int TotalCount { get; }

        /// <summary>
        /// Gets the total number of pages.
        /// </summary>
        int TotalPages { get; }

        /// <summary>
        /// Gets the index of the current page. The first page index equals to 1.
        /// </summary>
        int PageNumber { get; }

        /// <summary>
        /// Gets the size of one page.
        /// </summary>
        int PageSize { get; }
    }
}
