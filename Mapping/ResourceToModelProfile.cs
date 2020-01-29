using AutoMapper;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Models.Auth;
using Supermarket.API.Resources;
using Supermarket.API.Resources.Auth;

namespace Supermarket.API.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveCategoryResource, Category>();

            CreateMap<UserCredentialResource, User>();

            CreateMap<SaveHighscoreResource, Highscore>();
        }
    }
}