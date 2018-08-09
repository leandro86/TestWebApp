using System;
using System.Collections.Generic;
using System.Linq;

namespace TestWebApp.Models
{
    /// <summary>
    /// Represents a strongly typed paged collection of elements that can be accessed by index.
    /// </summary>
    /// <typeparam name="T">The type of the items.</typeparam>
    public class PagedList<T> : List<T>, IPagedList<T>
    {
        /// <inheritdoc />
        public int TotalCount { get; }

        /// <inheritdoc />
        public int TotalPages { get; }

        /// <inheritdoc />
        public int PageNumber { get; }

        /// <inheritdoc />
        public int PageSize { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PagedList{T}"/> class that is initialized with elements from the specified <see cref="IQueryable{T}"/> source.
        /// </summary>
        /// <param name="source">The <see cref="IQueryable{T}"/> to initialize the new list with.</param>
        /// <param name="pageNumber">The page index of the list.</param>
        /// <param name="pageSize">The size of one page in the list.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="pageNumber"/> is less than 1 or <paramref name="pageSize"/> is less than 1.
        /// </exception>
        public PagedList(IQueryable<T> source, int pageNumber, int pageSize)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (pageNumber < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(pageNumber), pageNumber, "Page index must be greater than 0.");
            }
            if (pageSize < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(pageSize), pageSize, "Page size must be greater than 0.");
            }

            PageSize = pageSize;
            TotalCount = source.Count();
            TotalPages = TotalCount == 0 ? 1 : (int)Math.Ceiling(TotalCount / (double)PageSize);
            PageNumber = pageNumber > TotalPages ? TotalPages : pageNumber;

            if (TotalCount > 0)
            {
                AddRange(source.Skip((PageNumber - 1) * PageSize).Take(PageSize).ToList());
            }
        }
    }
}
