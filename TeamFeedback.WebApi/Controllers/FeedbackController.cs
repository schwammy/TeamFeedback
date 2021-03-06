using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchwammyStreams.TeamFeedback.Shared;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TeamFeedback.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        // GET: api/<FeedbackController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<FeedbackController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<FeedbackController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FeedbackEntry feedbackEntry)
        {
            // save data...


            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            //FeedbackOrchestrator

            //if error return status code and error messages
            if (feedbackEntry.TeamId == 1)
            {
                return new BadRequestResult();
            }
            return new OkResult();
        }

        // PUT api/<FeedbackController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FeedbackController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
