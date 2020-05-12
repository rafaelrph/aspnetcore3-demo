using System.Threading.Tasks;
using Shared.Services;
using Microsoft.AspNetCore.Mvc;

namespace Globomantics.ViewComponents
{
    public class StatisticsViewComponent : ViewComponent
    {
        private readonly IConferenceService service;

        public StatisticsViewComponent(IConferenceService service)
        {
            this.service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync(string statsCaption)
        {
            ViewBag.StatsCaption = statsCaption;
            return View(await service.GetStatistics());
        }
    }
}
