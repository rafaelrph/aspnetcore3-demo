using System;
using Shared.Services;
using Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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

        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                return Ok(service.GetAll());
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet("statistics")]
        public ActionResult GetStatistics()
        {
            try
            {
                return Ok(service.GetStatistics());
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet("{id}", Name = "GetById")]
        public ActionResult GetById(int id)
        {
            try
            {
                return Ok(service.GetById(id));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ConferenceModel conference)
        {
            try
            {
                await service.Add(conference);
                return CreatedAtRoute("GetById", new { id = conference.Id }, conference );
            } catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            
        } 
    }
}
