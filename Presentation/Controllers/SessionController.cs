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
        public IActionResult GetSessions()
        {
            var sessions = _sessionService.GetSessions();
            return Ok(sessions);
        }

        [HttpPost] 
        public IActionResult CreateSessions(AddSessionDto formData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _sessionService.CreateSession(formData);
            return Ok();
        }

    }
}
