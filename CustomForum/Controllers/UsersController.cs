using CustomForum.Services;
using CustomForum.ViewModels.Users;
using Microsoft.AspNetCore.Mvc;

namespace CustomForum.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Login(LoginUserViewModel input)
        {
            int? userId = usersService.GetUserId(input);

            return this.Redirect("/");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Register(RegisterUserViewModel input)
        {
            return this.Redirect("/");
        }
    }
}
