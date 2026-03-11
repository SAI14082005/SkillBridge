using SkillBridge.Application.DTOs.Project;
using SkillBridge.Application.DTOs.User;
using SkillBridge.Core.Interfaces;

namespace SkillBridge.Application.Services;

public class MatchingService
{
    private readonly IUnitOfWork _uow;

    public MatchingService(IUnitOfWork uow)
    {
        _uow = uow;
    }

    // ── FIND USERS BY SKILL (LINQ Matching Engine) ────
    public async Task<List<UserProfileDto>> FindUsersBySkillAsync(string skillName)
    {
        var users = await _uow.Users.GetAllAsync();

        // LINQ skill matching — core of the platform!
        var matched = users
            .Where(u => u.IsVerified &&
                        u.UserSkills.Any(us =>
                            us.Skill != null &&
                            us.Skill.Name.ToLower().Contains(skillName.ToLower())))
            .Select(u => new UserProfileDto
            {
                UserId = u.UserId,
                FullName = u.FullName,
                Email = u.Email,
                Department = u.Department,
                Year = u.Year,
                Bio = u.Bio,
                IsVerified = u.IsVerified,
                CreatedAt = u.CreatedAt,
                Skills = u.UserSkills.Select(us => new UserSkillDto
                {
                    SkillId = us.SkillId,
                    SkillName = us.Skill?.Name ?? "",
                    Category = us.Skill?.Category ?? "",
                    Proficiency = us.Proficiency
                }).ToList()
            })
            .ToList();

        return matched;
    }

    // ── FIND PROJECTS BY SKILL ─────────────────────────
    public async Task<List<ProjectResponseDto>> FindProjectsBySkillAsync(string skillName)
    {
        var projects = await _uow.Projects.GetAllAsync();

        var matched = projects
            .Where(p => p.Status == "Open" &&
                        p.ProjectSkills.Any(ps =>
                            ps.Skill != null &&
                            ps.Skill.Name.ToLower().Contains(skillName.ToLower())))
            .Select(p => new ProjectResponseDto
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
            })
            .ToList();

        return matched;
    }
}