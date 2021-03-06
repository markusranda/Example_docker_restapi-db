using System.Threading.Tasks;
using Supermarket.API.Domain.Models.Auth;

namespace Supermarket.API.Domain.Repositories
{
    public interface IUserRepository
    {
        Task AddAsync(User user, ERole[] userRoles);
        Task<User> FindByEmailAsync(string email);
    }
}