using Microsoft.AspNetCore.Mvc;
using ToDoApp.Models;
using ToDoApp.Repository.Interface;

namespace ToDoApp.Controllers
{
    public class TodoController : Controller
    {
        private readonly ITodoRepository _todoRepo;
        public TodoController(ITodoRepository todoRepo)
        {
            _todoRepo = todoRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTodos()
        {
            var todos =await _todoRepo.GetAllTodo();
            return View(todos);
        }

        [HttpGet]
        public async Task<IActionResult> GetTodoById(string id)
        {
            var todo = await _todoRepo.GetTodoById(id);
            return View(todo);
        }

        [HttpGet]
        public IActionResult AddTodo()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddTodo(ToDo entity)
        {
            var result =await _todoRepo.AddTodo(entity);
            if (result)
            {
                return RedirectToAction("GetAllTodos");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var todo = await _todoRepo.GetTodoById(id);
            return View(todo);

        }

        [HttpPost]
        public async Task<IActionResult> DeleteTodo(string id)
        {
            await _todoRepo.DeleteTodo(id);
            return RedirectToAction("GetAllTodos");
        }

        [HttpGet]
        public async Task<IActionResult> EditTodo(string id)
        {
            var todo = await _todoRepo.GetTodoById(id);
            return View(todo);
        }

        [HttpPost]
        public async Task<IActionResult> EditTodo(ToDo todo)
        {
            var result =await _todoRepo.EditTodo(todo);
            if (result)
            {
                return RedirectToAction("GetAllTodos");
            }
            return View();
        }

    }
}
