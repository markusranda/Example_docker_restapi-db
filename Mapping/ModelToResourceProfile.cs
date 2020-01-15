using System.Linq;
using AutoMapper;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Models.Auth;
using Supermarket.API.Domain.Models.Auth.Token;
using Supermarket.API.Extensions;
using Supermarket.API.Resources;
using Supermarket.API.Resources.Auth;

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

            CreateMap<User, UserResource>()
                .ForMember(u => u.Roles, opt => opt.MapFrom(u => u.UserRoles.Select(ur => ur.Role.Name)));

            CreateMap<AccessToken, AccessTokenResource>()
                .ForMember(a => a.AccessToken, opt => opt.MapFrom(a => a.Token))
                .ForMember(a => a.RefreshToken, opt => opt.MapFrom(a => a.RefreshToken.Token))
                .ForMember(a => a.Expiration, opt => opt.MapFrom(a => a.Expiration));
        }
    }
}