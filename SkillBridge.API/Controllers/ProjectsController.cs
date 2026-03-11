using Microsoft.AspNetCore.Mvc;
using SkillBridge.Application.DTOs.Project;
using SkillBridge.Application.Services;

namespace SkillBridge.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController : ControllerBase
{
    private readonly ProjectService _projectService;

    public ProjectsController(ProjectService projectService)
    {
        _projectService = projectService;
    }

    // GET api/projects
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var projects = await _projectService.GetAllProjectsAsync();
        return Ok(projects);
    }

    // GET api/projects/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var project = await _projectService.GetProjectByIdAsync(id);
        if (project == null) return NotFound(new { message = "Project not found." });
        return Ok(project);
    }

    // POST api/projects
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProjectDto dto, [FromQuery] int ownerId)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var project = await _projectService.CreateProjectAsync(ownerId, dto);
        return CreatedAtAction(nameof(GetById), new { id = project.ProjectId }, project);
    }

    // GET api/projects/my/{ownerId}
    [HttpGet("my/{ownerId}")]
    public async Task<IActionResult> GetMyProjects(int ownerId)
    {
        var projects = await _projectService.GetMyProjectsAsync(ownerId);
        return Ok(projects);
    }
}