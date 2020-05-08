using System;
using System.Threading.Tasks;
using Globomantics.Services;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace Globomantics.Controllers
{
    public class ProposalController : Controller
    {

        private readonly IConferenceService conferenceService;
        private readonly IProposalService proposalService;

        public ProposalController(IConferenceService conferenceService, IProposalService proposalService)
        {
            this.conferenceService = conferenceService;
            this.proposalService = proposalService;
        }

        public async Task<IActionResult> Index(int conferenceId)
        {
            ConferenceModel conference = await conferenceService.GetById(conferenceId);
            ViewBag.Title = $"Proposals for Conference {conference.Name} {conference.Location}";
            ViewBag.ConferenceId = conferenceId;
            return View(await proposalService.GetAll(conferenceId));
        }

        public IActionResult Add(int conferenceId)
        {
            ViewBag.Title = "Add Proposal";
            return View(proposalService.Add(new ProposalModel { ConferenceId = conferenceId }));
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProposalModel proposal)
        {
            if (ModelState.IsValid)
                await proposalService.Add(proposal);
            return RedirectToAction("Index", new { conferenceId = proposal.ConferenceId });
        }

    }
}
