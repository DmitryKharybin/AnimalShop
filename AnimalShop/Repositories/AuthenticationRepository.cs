using AnimalShop.Models;
using Microsoft.AspNetCore.Identity;

namespace AnimalShop.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;


        public AuthenticationRepository(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public async Task<IdentityResult> AddUserAsync(Register model)
        {
            IdentityUser user = new IdentityUser
            {
                UserName = model.Username,
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            return result;

        }

        public async Task LogOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<SignInResult> LogInAsync(Login model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);

            return result;

        }
    }
}
