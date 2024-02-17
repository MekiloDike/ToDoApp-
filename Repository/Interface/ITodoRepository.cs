using ToDoApp.Models;

namespace ToDoApp.Repository.Interface
{
    public interface ITodoRepository
    {
        public Task<List<ToDo>> GetAllTodo();
        public Task<ToDo> GetTodoById(string Id);
        public Task<bool> AddTodo(ToDo toDo);
        public Task<bool> EditTodo(ToDo toDo);
        public Task DeleteTodo(string id);
    }

}
