using Microsoft.EntityFrameworkCore;
using ToDoApp.AppDbContext;
using ToDoApp.Models;
using ToDoApp.Repository.Interface;

namespace ToDoApp.Repository.Implementation
{
    public class TodoRepository : ITodoRepository
    {
        //bring in your database connection
        private readonly TodoDbContext _dbContext;
        public TodoRepository(TodoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddTodo(ToDo toDo)
        {
            //add the todo model to database table
            await _dbContext.ToDos.AddAsync(toDo);
            //save to database
           var isSaved = await _dbContext.SaveChangesAsync() > 0;
            return isSaved;          
        }
        
        public async Task DeleteTodo(string id)
        {
            //first find the entity
            var entity = await _dbContext.ToDos.FirstOrDefaultAsync(x => x.Id == id);
            if(entity == null)
            {
                throw new NullReferenceException("Todo not found or does not exist");
            }
             _dbContext.ToDos.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> EditTodo(ToDo toDo)
        {
            //first find the entity in the database table
            var entity = await _dbContext.ToDos.FirstOrDefaultAsync(t => t.Id == toDo.Id);
            if (entity == null)
            {
                throw new NullReferenceException("Todo not found or does not exist");
            }
            //map the new todo to the old todo(replace)

            //entity.Id = toDo.Id; no need updating id
            entity.Title = toDo.Title;
            entity.Description = toDo.Description;
            entity.Date = toDo.Date;
            entity.IsActive = toDo.IsActive;

            //update the entity
           _dbContext.ToDos.Update(entity);
           var isSaved= await _dbContext.SaveChangesAsync() > 0;

            return isSaved;
        }

        public async Task<List<ToDo>> GetAllTodo()
        {
            var entities = await _dbContext.ToDos.ToListAsync();
            return entities;
        }

        public async Task<ToDo> GetTodoById(string id)
        {
              var entity = await _dbContext.ToDos.FirstOrDefaultAsync(x => x.Id == id) ?? throw new NullReferenceException("ToDo does not exist");
            if (entity == null)
            {
                throw new NullReferenceException("ToDo does not exist");
            }            
            return entity;
        }
    }
}
