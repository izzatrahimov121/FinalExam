using DataAccess.Contexts;
using Microsoft.AspNetCore.Mvc;
using WebUI.ViewModels;

namespace WebUI.Controllers
{
	public class HomeController : Controller
	{
		private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
		{
			HomeViewModel homeViewModel = new()
			{
				Introductions = _context.Introductions
			};
			return View(homeViewModel);
		}
	}
}
