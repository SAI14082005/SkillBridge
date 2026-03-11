using Microsoft.EntityFrameworkCore;
using SkillBridge.Core.Entities;
using SkillBridge.Core.Interfaces;
using SkillBridge.Infrastructure.Data;

namespace SkillBridge.Infrastructure.Repositories;

public class SkillRepository : ISkillRepository
{
    private readonly AppDbContext _context;

    public SkillRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Skill?> GetByIdAsync(int skillId)
        => await _context.Skills.FindAsync(skillId);

    public async Task<Skill?> GetByNameAsync(string name)
        => await _context.Skills
            .FirstOrDefaultAsync(s => s.Name.ToLower() == name.ToLower());

    public async Task<IEnumerable<Skill>> GetAllAsync()
        => await _context.Skills.ToListAsync();

    public async Task AddAsync(Skill skill)
        => await _context.Skills.AddAsync(skill);
}