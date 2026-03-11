using SkillBridge.Core.Entities;

namespace SkillBridge.Core.Interfaces;

public interface ISkillRepository
{
    Task<Skill?> GetByIdAsync(int skillId);
    Task<Skill?> GetByNameAsync(string name);
    Task<IEnumerable<Skill>> GetAllAsync();
    Task AddAsync(Skill skill);
}