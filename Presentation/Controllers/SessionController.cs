using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Dtos;
using Service.Interfaces;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController(ISessionService sessionService) : ControllerBase
    {
        //ida was here :3
        private readonly ISessionService _sessionService = sessionService;

        [HttpGet]
        public async Task<IActionResult> GetSessions()
        {
            var sessions = await _sessionService.GetSessions();
            return Ok(sessions);
        }

        [HttpPost] 
        public async Task<IActionResult> CreateSessions(AddSessionDto formData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _sessionService.CreateSession(formData);
            return Ok();
        }

        [HttpDelete("{sessionId}")]
        public async Task<IActionResult> Delete(string sessionId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();

            }
            await _sessionService.DeleteTrainingSession(sessionId);
            return Ok();
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(EditSessionDto formData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();

            }
            await _sessionService.EditTrainingSession(formData);
            return Ok();
        }
    }
}

