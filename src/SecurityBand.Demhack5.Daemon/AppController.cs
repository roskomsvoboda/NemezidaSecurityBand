using Microsoft.AspNetCore.Mvc;

namespace SecurityBand.DemHack5.Daemon;

public class AppController : ControllerBase
{
    [HttpGet]
    public IActionResult InstallCli()
    {
        return Ok();
    }

    [HttpPost]
    public IActionResult RegisterEvent(
        [FromServices] IHostApplicationLifetime lifetime,
        [FromServices] EventsConfig config,
        [FromBody] Event evt)
    {
        if (evt.Payload == config.StopPhrase)
        {
            lifetime.StopApplication();
            return StatusCode(StatusCodes.Status503ServiceUnavailable);
        }
        if (evt.Payload == config.TheNAme)
        {
            return Ok();
        }
        return StatusCode(StatusCodes.Status201Created);
    }
}