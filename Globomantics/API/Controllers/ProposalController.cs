using System;
using Shared.Services;
using Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class ProposalController : ControllerBase
    {

        private readonly IProposalService service;

        public ProposalController(IProposalService service)
        {
            this.service = service;
        }


        [HttpGet("{conferenceId}", Name = "GetById")]
        public ActionResult GetById(int conferenceId)
        {
            try
            {
                return Ok(service.GetAll(conferenceId));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Approve(int id)
        {
            try
            {
                return Ok(service.Approve(id));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ProposalModel proposal)
        {
            try
            {
                await service.Add(proposal);
                return CreatedAtRoute("GetById", new { id = proposal.Id }, proposal);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
