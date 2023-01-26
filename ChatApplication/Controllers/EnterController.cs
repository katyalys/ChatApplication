using ChatApplication.Data;
using ChatApplication.Hubs;
using ChatApplication.Models;
using javax.jws;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
using System.Security.Claims;

namespace ChatApplication.Controllers
{
    public class EnterController : Controller
    {
        public readonly MvcDbContext _context;

        public EnterController(MvcDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Enter()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Enter(User usersModel)
        {
            if (!(_context.Users.Any(x => x.Name == usersModel.Name)))
            {
                var user = new UsersModel()
                {
                    Name = usersModel.Name,
                };     
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
            }
            var userGet = await _context.Users.Where(x => x.Name == usersModel.Name).FirstAsync();
            await Authenticate(userGet.UserId);
            return RedirectToAction("SendMessage", "Enter");
        }

        [HttpGet]
        [Authorize]
        public IActionResult SendMessage()
        {
            return View();
        }

        private async Task Authenticate(int userId)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userId.ToString())
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public void ShowRecievers()
        {

        }

        [HttpPost]
        public IActionResult ReturnUsersList()
        {
            string[] users = _context.Users.Select(t => t.Name).ToArray();
            return Ok(users);
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
