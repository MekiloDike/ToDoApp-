using Microsoft.AspNetCore.Mvc;
using ToDoApp.Repository.Implementation;
using ToDoApp.Repository.Interface;
using ToDoApp.ViewModel;

namespace ToDoApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        [HttpGet]
        public IActionResult RegisterUser()
        {
            return View();
        }
        public async Task<IActionResult> RegisterUser(RegisterUserVM registervm)
        {
            if (!ModelState.IsValid)
            {
                return View(registervm);
            }
            try
            {
                var result = await _userRepository.RegisterUser(registervm);                
                if (result)
                {
                    return RedirectToAction("GetAllTodos", "Todo");
                }
                else
                {
                    ModelState.AddModelError("", "Failed to register user, please try again.");
                    return View(registervm);
                }

            }
            catch (Exception ex)
            {
                throw new Exception($"Something went wrong, please try again: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> LoginUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginUser(LoginVM loginVM)
        {
            if (!ModelState.IsValid)
            {
                return View(loginVM);
            }
            try
            {
                var isLogin = await _userRepository.LoginUser(loginVM);

                if (isLogin)
                {
                    return RedirectToAction("GetAllTodos", "Todo");

                }
                else
                {
                    ModelState.AddModelError("", "Failed to login user, please try again.");
                    return View();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"log in failed: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult> LogOut()
        {
            await _userRepository.LogOut();
            return RedirectToAction("Index", "Home");
        }



    }
}
