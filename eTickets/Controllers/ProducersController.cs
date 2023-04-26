using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class ProducersController : Controller
    {
        private AppDbContext appDbcontext;

        public ProducersController(AppDbContext context)
        {
            appDbcontext = context;
        }

        public async Task<IActionResult> Index()
        {
            var producersList = await appDbcontext.Producers.ToListAsync();
            return View(producersList);
        }
    }
}
