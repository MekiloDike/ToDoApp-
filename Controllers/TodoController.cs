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
            try
            {
                var todos = await _todoRepo.GetAllTodo();
                return View(todos);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetTodoById(string id)
        {
            try
            {
                var todo = await _todoRepo.GetTodoById(id);
                return View(todo);

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        public IActionResult AddTodo()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddTodo(ToDo entity)
        {
            try
            {
                var result = await _todoRepo.AddTodo(entity);
                if (result)
                {
                    return RedirectToAction("GetAllTodos");
                }
                return View();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {

                var todo = await _todoRepo.GetTodoById(id);
                return View(todo);

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteTodo(string id)
        {
            try
            {
                await _todoRepo.DeleteTodo(id);
                return RedirectToAction("GetAllTodos");

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditTodo(string id)
        {
            try
            {
                var todo = await _todoRepo.GetTodoById(id);
                return View(todo);

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditTodo(ToDo todo)
        {
            try
            {

                var result = await _todoRepo.EditTodo(todo);
                if (result)
                {
                    return RedirectToAction("GetAllTodos");
                }
                return View();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
