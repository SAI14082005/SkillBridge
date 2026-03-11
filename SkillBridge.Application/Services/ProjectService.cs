using SkillBridge.Application.DTOs.Project;
using SkillBridge.Core.Entities;
using SkillBridge.Core.Interfaces;

namespace SkillBridge.Application.Services;

public class ProjectService
{
    private readonly IUnitOfWork _uow;

    public ProjectService(IUnitOfWork uow)
    {
        _uow = uow;
    }

    // ── CREATE PROJECT ────────────────────────────────
    public async Task<ProjectResponseDto> CreateProjectAsync(int ownerId, CreateProjectDto dto)
    {
        var project = new Project
        {
            OwnerId = ownerId,
            Title = dto.Title,
            Description = dto.Description,
            Status = "Open"
        };

        foreach (var skillId in dto.RequiredSkillIds)
        {
            project.ProjectSkills.Add(new ProjectSkill
            {
                SkillId = skillId
            });
        }

        await _uow.Projects.AddAsync(project);
        await _uow.SaveChangesAsync();

        var created = await _uow.Projects.GetByIdAsync(project.ProjectId);
        return MapToDto(created!);
    }

    // ── GET ALL PROJECTS ──────────────────────────────
    public async Task<List<ProjectResponseDto>> GetAllProjectsAsync()
    {
        var projects = await _uow.Projects.GetAllAsync();
        return projects.Select(MapToDto).ToList();
    }

    // ── GET PROJECT BY ID ─────────────────────────────
    public async Task<ProjectResponseDto?> GetProjectByIdAsync(int projectId)
    {
        var project = await _uow.Projects.GetByIdAsync(projectId);
        return project == null ? null : MapToDto(project);
    }

    // ── GET MY PROJECTS ───────────────────────────────
    public async Task<List<ProjectResponseDto>> GetMyProjectsAsync(int ownerId)
    {
        var projects = await _uow.Projects.GetByOwnerIdAsync(ownerId);
        return projects.Select(MapToDto).ToList();
    }

    // ── MAPPER ────────────────────────────────────────
    private static ProjectResponseDto MapToDto(Project p) => new()
    {
        ProjectId = p.ProjectId,
        Title = p.Title,
        Description = p.Description,
        Status = p.Status,
        CreatedAt = p.CreatedAt,
        OwnerId = p.OwnerId,
        OwnerName = p.Owner?.FullName ?? "",
        RequiredSkills = p.ProjectSkills
            .Select(ps => ps.Skill?.Name ?? "")
            .ToList()
    };
}