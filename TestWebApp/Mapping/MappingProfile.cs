using AutoMapper;
using TestWebApp.Mapping.Converters;
using TestWebApp.Mapping.Resolvers;
using TestWebApp.Models;

namespace TestWebApp.Mapping
{
    /// <summary>
    /// Mapping profile.
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MappingProfile" /> class.
        /// </summary>
        public MappingProfile()
        {
            // Common mapping ...
            CreateMap(typeof(IPagedList<>), typeof(IDataPage<>)).ConvertUsing(typeof(PagedListToDataPageConverter<,>));

            CreateMapForCommon();
        }

        private void CreateMapForCommon()
        {
            // Codebook base ...
            CreateMap<ICodebookEntityWithDescription, CodebookWithDescription>()
                .ForMember(d => d.Description, options => options.ResolveUsing<LocalizedDescriptionResolver>());

            // Language ...
            CreateMap<LanguageEntity, Language>()
                .IncludeBase<ICodebookEntityWithDescription, CodebookWithDescription>();        
        }
    }
}