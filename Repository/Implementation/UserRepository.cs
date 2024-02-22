using Microsoft.AspNetCore.Identity;
using ToDoApp.Models;
using ToDoApp.Repository.Interface;
using ToDoApp.ViewModel;

namespace ToDoApp.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public UserRepository(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;            
        }

        public async Task<bool> RegisterUser(RegisterUserVM userVM)
        {
            //first check if you can find a user with that email
            var existingUser = await _userManager.FindByEmailAsync(userVM.Email);
            if (existingUser != null)
            {
                //user exist already
                throw new Exception("Email already exists");
            }
            //else, if user with the email doesn't exist, create the user
            var userModel = new User
            {
                FirstName = userVM.FirstName,
                LastName = userVM.LastName,
                Email = userVM.Email,
                Gender = userVM.Gender,
                PhoneNumber = userVM.PhoneNumber,
                UserName = userVM.Email
            };
            var result = await _userManager.CreateAsync(userModel, userVM.Password);
            if (result.Succeeded)
            {
                //this is optional
                // Sign in the user after successful registration
                await _signInManager.SignInAsync(userModel, isPersistent: false);
            }
            return result.Succeeded;
        }
        public async Task<bool> LoginUser(LoginVM loginVm)
        {
          var login =  await _signInManager.PasswordSignInAsync(loginVm.Email, loginVm.Password, loginVm.RememberMe, lockoutOnFailure: false);
            if (login.Succeeded)
            {
                return true;
            }
            else return false;
        }
        public async Task LogOut()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
