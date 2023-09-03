using AnimalShop.Models;
using Microsoft.AspNetCore.Identity;

namespace AnimalShop.Repositories
{
    public interface IAuthenticationRepository
    {
        Task<IdentityResult> AddUserAsync(Register login);

        Task<SignInResult> LogInAsync(Login login);

        Task LogOutAsync();

    }
}
