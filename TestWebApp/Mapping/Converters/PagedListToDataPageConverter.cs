using System.Collections.Generic;
using AutoMapper;
using TestWebApp.Models;

namespace TestWebApp.Mapping.Converters
{
    /// <summary>
    /// The converter for paged list to data page conversion.
    /// </summary>
    /// <typeparam name="TSource">The type of the source.</typeparam>
    /// <typeparam name="TDestination">The type of the destination.</typeparam>
    public class PagedListToDataPageConverter<TSource, TDestination> : ITypeConverter<IPagedList<TSource>, IDataPage<TDestination>>
    {
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="PagedListToDataPageConverter{TSource, TDestination}" /> class.
        /// </summary>
        /// <param name="mapper">The auto mapper.</param>
        public PagedListToDataPageConverter(IMapper mapper)
        {
            this.mapper = mapper;
        }

        /// <inheritdoc />
        public IDataPage<TDestination> Convert(IPagedList<TSource> source, IDataPage<TDestination> destination, ResolutionContext context)
        {
            if (source == null)
            {
                return null;
            }

            return new StaticDataPage<TDestination>(mapper.Map<IList<TDestination>>(source), source.PageNumber, source.PageSize, source.TotalCount);
        }
    }
}