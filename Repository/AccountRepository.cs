using BookStroe.Data;
using BookStroe.Models;
using BookStroe.Services;
using BookStroe.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStroe.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _SignInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUserService _userService;
        public AccountRepository(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,IUserService userService)
        {
            _userManager = userManager;
            _SignInManager = signInManager;
            _roleManager = roleManager;
            _userService = userService;
        }

        public async Task<IdentityResult> CreateUserAsync(SignUpUserViewModel UserModel)
        {
            var NewUser = new ApplicationUser()
            {
                UserName = UserModel.Email,
                Email = UserModel.Email,
                FirstName = UserModel.FirstName,
                LastName = UserModel.LastName,
                Address = UserModel.Address,
                BirthDate = UserModel.BirthDate
            };

            var result = await _userManager.CreateAsync(NewUser, UserModel.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(NewUser, "Customer");
            }
            return result;
        }

        public async Task<SignInResult> PasswordSignInUserAsync(SignInUserViewModel userViewModel)
        {
            var result = await _SignInManager.PasswordSignInAsync(userViewModel.Username, userViewModel.Password, userViewModel.RememberMe, false);
            return result;
        }

        public async Task Logout()
        {
            await _SignInManager.SignOutAsync();
        }

        public async Task<IdentityResult> RoleCreate(RoleViewModel model)
        {
            var result = await _roleManager.CreateAsync(new IdentityRole(model.RoleName));
            return result;
        }

        public async Task<IdentityResult> RoleDelete(string rolename)
        {
            var role = await _roleManager.FindByNameAsync(rolename);
            var result = await _roleManager.DeleteAsync(role);
            return result;
        }

        public async Task<IdentityResult> ChangePassword(ChangePasswordViewModel model)
        {
            var userId = _userService.GetUserId();
            var user = await _userManager.FindByIdAsync(userId);
            return await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.ConfirmPassword);
        }

    }
}
