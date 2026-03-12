using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/standings")]
public class StandingsController(StandingsService standingsService) : ControllerBase
{
    [HttpGet("drivers")]
    public async Task<IActionResult> GetDriverStandings()
    {
        return Ok(await standingsService.GetDriverStandingsAsync());
    }
    
    
    
}