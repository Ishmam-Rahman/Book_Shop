using BookStroe.ViewModel;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace BookStroe.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(SignUpUserViewModel UserModel);
        Task<SignInResult> PasswordSignInUserAsync(SignInUserViewModel userViewModel);
        Task Logout();
        Task<IdentityResult> RoleCreate(RoleViewModel usermodel);
        Task<IdentityResult> ChangePassword(ChangePasswordViewModel model);
    }
}