using AutoMapper;
using vega2.Data;
using vega2.Models;

namespace vega2.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Make, MakeViewModel>();
            CreateMap<Model, ModelViewModel>();
            CreateMap<Feature, FeatureViewModel>();
        }
    }
}