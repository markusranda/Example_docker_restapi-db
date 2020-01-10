using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Services.Communication;
using Supermarket.API.Resources;

namespace Supermarket.API.Domain.Services {

    public interface ICategoryService {
        Task<IEnumerable<Category>> ListAsync();

        Task<CategoryResponse> SaveAsync(Category category);

        Task<CategoryResponse> UpdateAsync(int id, Category category);

        Task<CategoryResponse> DeleteAsync(int id);
    }

}