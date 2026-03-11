using Microsoft.AspNetCore.Mvc;
using SkillBridge.Application.Services;

namespace SkillBridge.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SearchController : ControllerBase
{
    private readonly MatchingService _matchingService;

    public SearchController(MatchingService matchingService)
    {
        _matchingService = matchingService;
    }

    // GET api/search/users?skill=Angular
    [HttpGet("users")]
    public async Task<IActionResult> SearchUsers([FromQuery] string skill)
    {
        if (string.IsNullOrEmpty(skill))
            return BadRequest(new { message = "Skill parameter is required." });

        var users = await _matchingService.FindUsersBySkillAsync(skill);
        return Ok(new { skill, count = users.Count, results = users });
    }

    // GET api/search/projects?skill=Angular
    [HttpGet("projects")]
    public async Task<IActionResult> SearchProjects([FromQuery] string skill)
    {
        if (string.IsNullOrEmpty(skill))
            return BadRequest(new { message = "Skill parameter is required." });

        var projects = await _matchingService.FindProjectsBySkillAsync(skill);
        return Ok(new { skill, count = projects.Count, results = projects });
    }
}