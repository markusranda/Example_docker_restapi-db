using AutoMapper;
using Supermarket.API.Domain.Models;
using Supermarket.API.Resources;

namespace Supermarket.API.Mapping {

    public class ResourceToModelProfile {
        public ResourceToModelProfile()
        {
            var config = new MapperConfiguration(cfg => 
                { cfg.CreateMap<SaveCategoryResource, Category>(); });
        }
    }

}