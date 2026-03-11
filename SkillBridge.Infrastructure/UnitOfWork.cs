using SkillBridge.Core.Interfaces;
using SkillBridge.Infrastructure.Data;
using SkillBridge.Infrastructure.Repositories;

namespace SkillBridge.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public IUserRepository Users { get; }
    public IProjectRepository Projects { get; }
    public ISkillRepository Skills { get; }
    public ITeamRequestRepository TeamRequests { get; }

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
        Users = new UserRepository(context);
        Projects = new ProjectRepository(context);
        Skills = new SkillRepository(context);
        TeamRequests = new TeamRequestRepository(context);
    }

    public async Task<int> SaveChangesAsync()
        => await _context.SaveChangesAsync();

    public void Dispose()
        => _context.Dispose();
}