using Microsoft.EntityFrameworkCore;
using SkillBridge.Core.Entities;
using SkillBridge.Core.Interfaces;
using SkillBridge.Infrastructure.Data;

namespace SkillBridge.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<User?> GetByIdAsync(int userId)
        => await _context.Users
            .Include(u => u.UserSkills).ThenInclude(us => us.Skill)
            .FirstOrDefaultAsync(u => u.UserId == userId);

    public async Task<User?> GetByEmailAsync(string email)
        => await _context.Users
            .FirstOrDefaultAsync(u => u.Email == email);

    public async Task<IEnumerable<User>> GetAllAsync()
        => await _context.Users
            .Include(u => u.UserSkills).ThenInclude(us => us.Skill)
            .ToListAsync();

    public async Task AddAsync(User user)
        => await _context.Users.AddAsync(user);

    public void Update(User user)
        => _context.Users.Update(user);

    public void Delete(User user)
        => _context.Users.Remove(user);
}