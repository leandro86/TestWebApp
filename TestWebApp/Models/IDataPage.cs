using System.Collections.Generic;

namespace TestWebApp.Models
{
    public interface IDataPage<out T>
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

        /// <summary>
        /// Gets the current count of elements in this page.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Gets a sequence of the items in this page.
        /// </summary>
        IEnumerable<T> Data { get; }
    }
}
