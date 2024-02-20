using Microsoft.AspNetCore.Mvc;
using ToDoApp.Models;
using ToDoApp.Repository.Interface;

namespace ToDoApp.Controllers
{
    public class AppUserController : Controller
    {
        private readonly IAppUserRepository _appuserrepo;
        public AppUserController(IAppUserRepository appuserrepo)
        {
            _appuserrepo = appuserrepo;
        }


        [HttpGet]
        public IActionResult GetAllAppUser()
        {
            var appuser = _appuserrepo.GetAllAppUser();
            return View(appuser);

        }


        [HttpGet]
        public IActionResult GetAppUserId(string id)
        {
            var appuser = _appuserrepo.GetAppUserId(id);
            return View(appuser);

        }


        [HttpGet]
        public IActionResult AddAppUserId()
        {
            return View();
        }



        [HttpGet]
        public IActionResult AddAppUser()
        {
            return View();
        }


        [HttpPost]
        public IActionResult AddAppUser(AppUser user)
        {
            var result = _appuserrepo.AddAppUser(user);
            if (result)
            {
                return RedirectToAction("GetAllAppUser");
            }
            return View();
        }


        [HttpGet]
        public IActionResult DeleteAppUser(string id)
        {
            var appuser = _appuserrepo.GetAppUserId(id);
            return View(appuser);
        }

        [HttpPost]
        public IActionResult Delete(string id)
        {
            _appuserrepo.DeleteAppUser(id);
            return RedirectToAction("GetAllAppUser");
        }

        [HttpGet]
        public IActionResult EditAppUser(string id)
        {
            var appuser = _appuserrepo.GetAppUserId(id);
            return View(appuser);
        }

        [HttpPost]
        public IActionResult EditAppUser(AppUser user)
        {
            var result = _appuserrepo.EditAppUser(user);
            if (result)
            {
                return RedirectToAction("GetAllAppUser");
            }
            return View();
        }
 
    }

}
