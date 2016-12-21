using System.Linq;
using BloggInlämning.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BloggInlämning.Controllers
{
    public class AdminController : Controller
    {
        private readonly BloggContext _bloggContext;

        public AdminController(BloggContext bloggContext)
        {
            _bloggContext = bloggContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Admin admin)
        {
            var isAdmin = _bloggContext.Admins.FirstOrDefault(a => a.UserName == admin.UserName && a.Password == admin.Password);
            if (isAdmin != null)
            {
                return RedirectToAction("Welcome", "Home", isAdmin);
            }
            ModelState.Clear();
            TempData["message"] = "Fel Användarnamn eller lösenord";
            return View();
        }
    }
}
