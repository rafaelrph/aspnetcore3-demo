using System;
using System.Threading.Tasks;
using Globomantics.Services;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace Globomantics.Controllers
{
    public class ConferenceController: Controller
    {
        private readonly IConferenceService conferenceService;

        public ConferenceController(IConferenceService conferenceService)
        {
            this.conferenceService = conferenceService;
        }

        public async Task<IActionResult> Index()
        {
            return Ok(await conferenceService.GetAll());
            //ViewBag.Title = "Conferences";
            //return View(await conferenceService.GetAll());
        }

        public IActionResult Add()
        {
            ViewBag.Title = "Add Conference";
            return View(new ConferenceModel());
        }

        [HttpPost]
        public async Task<IActionResult> Add(ConferenceModel conference)
        {
            if (ModelState.IsValid)
                await conferenceService.Add(conference);
            return RedirectToAction("Index");
        }
    }
}
