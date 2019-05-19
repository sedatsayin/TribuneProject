using Microsoft.AspNetCore.Mvc;
using Boreass.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Boreass.Controllers
{
    public class BoreassController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            BoreassContext context = HttpContext.RequestServices.GetService(typeof(Boreass.Models.BoreassContext)) as BoreassContext;

            return View(context.GetAllAreas());
        }
        public IActionResult Tribunes()
        {
            BoreassContext context = HttpContext.RequestServices.GetService(typeof(Boreass.Models.BoreassContext)) as BoreassContext;

            return View(context.GetAllTribunes());
        }

        public IActionResult Login()
        {
            BoreassContext context = HttpContext.RequestServices.GetService(typeof(Boreass.Models.BoreassContext)) as BoreassContext;

            return View(context.GetLoginInfo());
        }

        public IActionResult Deneme()
        {
            return View();
        }
    }
}