using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using ToDoApp.AppDbContext;
using ToDoApp.Models;
using ToDoApp.Repository.Interface;

namespace ToDoApp.Repository.Implementation
{
    public class AppUserRepository : IAppUserRepository
    {
        private TodoDbContext _dbContext;

        public AppUserRepository(TodoDbContext dbContext) 
        { 
            _dbContext = dbContext;
        }

        public bool AddAppUser(AppUser user)            
        {
            _dbContext.AppUsers.Add(user);
           var isSaved = _dbContext.SaveChanges() > 0;
            return isSaved;
        }

        public void DeleteAppUser(string id)
        {
            var entity = _dbContext.AppUsers.FirstOrDefault(x => x.Id == id);
            if (entity == null)
            {
            throw new NotImplementedException("App user not found");

            }
            _dbContext.AppUsers.Remove(entity);
            _dbContext.SaveChanges();
            

        }

        public bool EditAppUser(AppUser user)
        {
            var entity = _dbContext.AppUsers.FirstOrDefault(x => x.Id == user.Id );
            if (entity == null)
            {
            throw new NotImplementedException();

            }
           
            entity.FirstName = user.FirstName;
            entity.LastName = user.LastName;
            entity.Email = user.Email;
            entity.Gender = user.Gender;
            entity.Age = user.Age;

            _dbContext.AppUsers.Update(entity);
            var isSaved = _dbContext.SaveChanges() > 0;
            return isSaved;

        }

        public  List<AppUser> GetAllAppUser()
        {
           var entities = _dbContext.AppUsers.ToList();
            return entities; 
        }

        public AppUser GetAppUserId(string id)
        {
           var entity = _dbContext.AppUsers.FirstOrDefault(x => x.Id == id);
            if (entity == null)
            {
            throw new NotImplementedException();

            }
            return entity;
        
        }
    }
}
