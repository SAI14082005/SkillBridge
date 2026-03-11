using SkillBridge.Core.Entities;

namespace SkillBridge.Core.Interfaces;

public interface IProjectRepository
{
    Task<Project?> GetByIdAsync(int projectId);
    Task<IEnumerable<Project>> GetAllAsync();
    Task<IEnumerable<Project>> GetByOwnerIdAsync(int ownerId);
    Task AddAsync(Project project);
    void Update(Project project);
    void Delete(Project project);
}