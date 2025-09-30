using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.Services;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TrainingSessionController(ITrainingSessionService trainingSessionService) : ControllerBase
{
    private readonly ITrainingSessionService trainingSessionService = trainingSessionService;


    [HttpGet]
    public IActionResult Get()
    {
        var sessions = trainingSessionService.GetTrainingSessions();
        return Ok(sessions);
    }


    [HttpPost]
    public IActionResult Delete(string sessionId)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();

        }

        trainingSessionService.DeleteTrainingSession(sessionId);
        return Ok();
    }
}
