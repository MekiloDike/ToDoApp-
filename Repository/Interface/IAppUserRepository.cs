using ToDoApp.Models;

namespace ToDoApp.Repository.Interface
{
    public interface IAppUserRepository
    {
        public List<AppUser> GetAllAppUser();
        public AppUser GetAppUserId(string id);
        public bool AddAppUser(AppUser user);
        public bool EditAppUser(AppUser user);
        public void DeleteAppUser(string id);
    }
}
