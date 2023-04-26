using eTickets.Models;
using eTickets.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsService ActorsService;

        public ActorsController(IActorsService actorsService)
        {
            ActorsService = actorsService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var actorsList=await ActorsService.GetAllAsync();       
            return View(actorsList);
        }
         //Get: Actors/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureURL,FullName,Bio")]Actor actor)
        {
            
            await ActorsService.AddAsync(actor);
            return RedirectToAction(nameof(Index));
        }
        //Get: Actors/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var actorDetails = await ActorsService.GetByIdAsync(id);

            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }

        //Edit: Actors/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var previousActor = await ActorsService.GetByIdAsync(id);
            if (previousActor == null) return View("NotFound");
            return View(previousActor);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("Id,ProfilePictureURL,FullName,Bio")] Actor newActor)
        {

            await ActorsService.UpdateAsync(id,newActor);
            return RedirectToAction(nameof(Index));
        }

        //Delete: Actors/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var actor = await ActorsService.GetByIdAsync(id);
            if (actor == null) return View("NotFound");
            return View(actor);
        }

        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            await ActorsService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
