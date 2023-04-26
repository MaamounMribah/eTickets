using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class CinemasController : Controller
    {
        private AppDbContext appDbcontext;

        public CinemasController(AppDbContext context)
        {
            appDbcontext = context;
        }

        public async Task<IActionResult> Index()
        {
            var cinemaList = await appDbcontext.Cinemas.ToListAsync();
            return View(cinemaList);
        }
    }
}
