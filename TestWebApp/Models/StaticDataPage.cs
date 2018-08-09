using System;
using System.Collections.Generic;
using System.Linq;

namespace TestWebApp.Models
{
    /// <summary>
    /// Represents a strongly typed page of objects.
    /// </summary>
    /// <typeparam name="T">The type of the elements.</typeparam>
    public class StaticDataPage<T> : IDataPage<T>
    {
        /// <inheritdoc />
        public int Count { get; }

        /// <inheritdoc />
        public int TotalCount { get; }

        /// <inheritdoc />
        public int TotalPages { get; }

        /// <inheritdoc />
        public int PageNumber { get; }

        /// <inheritdoc />
        public int PageSize { get; }

        /// <inheritdoc />
        public IEnumerable<T> Data { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="StaticDataPage{T}"/> class initialized with elements from the specified <see cref="IEnumerable{T}"/> source.
        /// </summary>
        /// <param name="data">The <see cref="IEnumerable{T}"/> to initialize the new page with.</param>
        /// <param name="pageNumber">The page index of the new list.</param>
        /// <param name="pageSize">The size of one page in the new list.</param>
        /// <param name="totalCount">The total count of items.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="pageNumber"/> or <paramref name="pageSize"/> is less than 1 or <paramref name="totalCount"/> 
        ///     is less than 0 or <paramref name="pageNumber"/> is greater than total number of pages.
        /// </exception>
        public StaticDataPage(IEnumerable<T> data, int pageNumber, int pageSize, int totalCount)
        {
            if (pageNumber < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(pageNumber), pageNumber, "Page index must be greater than 0.");
            }
            if (pageSize < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(pageSize), pageSize, "Page size must be greater than 0.");
            }
            if (totalCount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(totalCount), totalCount, "Total count must be greater than or equal to 0.");
            }

            Data = data == null ? new T[0] : data.ToArray();
            Count = Data.Count();

            if (Count > pageSize)
            {
                throw new ArgumentOutOfRangeException(nameof(pageSize), pageSize, "Page size must be lower or equal than count of items in source.");
            }

            TotalCount = data == null ? 0 : totalCount;
            TotalPages = TotalCount == 0 ? 1 : (int)Math.Ceiling(TotalCount / (double)pageSize);
            PageNumber = TotalPages != 0 && pageNumber > TotalPages ? TotalPages : pageNumber;            
            PageSize = pageSize;
        }
    }
}