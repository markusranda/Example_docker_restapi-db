using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Domain.Models;

namespace Supermarket.API.Domain.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> ListAsync();

        Task AddAsync(Category category);

        Task<Category> FindByIdAsync(int id);

        /**
         * The reason for this method not being async, is because EF COre API does
         * not require an asynchronous method to update models.
         */
        void Update(Category category);

        // Same as above concerning the async
        void Remove(Category category);
    }
}