using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Services;
using Supermarket.API.Resources;

namespace Supermarket.API.Controllers {

    [Route("/api/[controller]")]
    public class ProductsController : Controller {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productsService, IMapper mapper)
        {
            _productService = productsService;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<ProductResource>> ListAsync()
        {
            var products = await _productService.ListAsync();
            var resources = 
                _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products);
            return resources;
        }

    }

}