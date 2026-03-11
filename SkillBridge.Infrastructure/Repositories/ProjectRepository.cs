using Microsoft.EntityFrameworkCore;
using SkillBridge.Core.Entities;
using SkillBridge.Core.Interfaces;
using SkillBridge.Infrastructure.Data;

namespace SkillBridge.Infrastructure.Repositories;

public class ProjectRepository : IProjectRepository
{
    private readonly AppDbContext _context;

    public ProjectRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Project?> GetByIdAsync(int projectId)
        => await _context.Projects
            .Include(p => p.Owner)
            .Include(p => p.ProjectSkills).ThenInclude(ps => ps.Skill)
            .FirstOrDefaultAsync(p => p.ProjectId == projectId);

    public async Task<IEnumerable<Project>> GetAllAsync()
        => await _context.Projects
            .Include(p => p.Owner)
            .Include(p => p.ProjectSkills).ThenInclude(ps => ps.Skill)
            .ToListAsync();

    public async Task<IEnumerable<Project>> GetByOwnerIdAsync(int ownerId)
        => await _context.Projects
            .Where(p => p.OwnerId == ownerId)
            .Include(p => p.ProjectSkills).ThenInclude(ps => ps.Skill)
            .ToListAsync();

    public async Task AddAsync(Project project)
        => await _context.Projects.AddAsync(project);

    public void Update(Project project)
        => _context.Projects.Update(project);

    public void Delete(Project project)
        => _context.Projects.Remove(project);
}