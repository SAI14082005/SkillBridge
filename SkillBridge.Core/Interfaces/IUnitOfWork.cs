namespace SkillBridge.Core.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IUserRepository Users { get; }
    IProjectRepository Projects { get; }
    ISkillRepository Skills { get; }
    ITeamRequestRepository TeamRequests { get; }
    Task<int> SaveChangesAsync();
}