using SkillBridge.Application.DTOs.Skill;
using SkillBridge.Core.Interfaces;

namespace SkillBridge.Application.Services;

public class SkillService
{
    private readonly IUnitOfWork _uow;

    public SkillService(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<List<SkillDto>> GetAllSkillsAsync()
    {
        var skills = await _uow.Skills.GetAllAsync();
        return skills.Select(s => new SkillDto
        {
            SkillId = s.SkillId,
            Name = s.Name,
            Category = s.Category
        }).ToList();
    }
}