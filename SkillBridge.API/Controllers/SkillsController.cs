using Microsoft.AspNetCore.Mvc;
using SkillBridge.Application.Services;

namespace SkillBridge.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SkillsController : ControllerBase
{
    private readonly SkillService _skillService;

    public SkillsController(SkillService skillService)
    {
        _skillService = skillService;
    }

    // GET api/skills
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var skills = await _skillService.GetAllSkillsAsync();
        return Ok(skills);
    }
}