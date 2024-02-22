using Microsoft.AspNetCore.Identity;
using ToDoApp.ViewModel;

namespace ToDoApp.Repository.Interface
{
    public interface IUserRepository
    {
        public Task<bool> RegisterUser(RegisterUserVM vm);
        public Task<bool> LoginUser(LoginVM log);
        public Task LogOut();



    }
}
