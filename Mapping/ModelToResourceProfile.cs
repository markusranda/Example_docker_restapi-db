using AutoMapper;
using Supermarket.API.Domain.Models;
using Supermarket.API.Extensions;
using Supermarket.API.Resources;

namespace Supermarket.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Category, CategoryResource>();

            // Includes mapping for specific field aswell as regular mapping between the classes
            CreateMap<Product, ProductResource>()
                .ForMember(src => src.UnitOfMeasurement,
                    opt => opt.MapFrom(
                        src => src.UnitOfMeasurement.ToDescriptionString()));
        }
    }
}