using System;
using Shared.Services;
using Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class ConferenceController : ControllerBase
    {

        private readonly IConferenceService service;

        public ConferenceController(IConferenceService service)
        {
            this.service = service;
        }

        public ActionResult GetAll()
        {
            return Ok(service.GetAll());
        }
    }
}
