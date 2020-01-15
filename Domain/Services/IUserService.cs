using System.Threading.Tasks;
using Supermarket.API.Domain.Models.Auth;
using Supermarket.API.Domain.Services.Communication;

namespace Supermarket.API.Domain.Services
{
    public interface IUserService
    {
        Task<CreateUserResponse> CreateUserAsync(User user, params ERole[] userRoles);

        Task<User> FindByEmailAsync(string email);
    }
}