using Microsoft.EntityFrameworkCore;
using SkillBridge.Core.Entities;
using SkillBridge.Core.Interfaces;
using SkillBridge.Infrastructure.Data;

namespace SkillBridge.Infrastructure.Repositories;

public class TeamRequestRepository : ITeamRequestRepository
{
    private readonly AppDbContext _context;

    public TeamRequestRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<TeamRequest?> GetByIdAsync(int requestId)
        => await _context.TeamRequests
            .Include(r => r.Sender)
            .Include(r => r.Receiver)
            .Include(r => r.Project)
            .FirstOrDefaultAsync(r => r.RequestId == requestId);

    public async Task<IEnumerable<TeamRequest>> GetSentByUserAsync(int senderId)
        => await _context.TeamRequests
            .Where(r => r.SenderId == senderId)
            .Include(r => r.Receiver)
            .Include(r => r.Project)
            .ToListAsync();

    public async Task<IEnumerable<TeamRequest>> GetReceivedByUserAsync(int receiverId)
        => await _context.TeamRequests
            .Where(r => r.ReceiverId == receiverId)
            .Include(r => r.Sender)
            .Include(r => r.Project)
            .ToListAsync();

    public async Task AddAsync(TeamRequest request)
        => await _context.TeamRequests.AddAsync(request);

    public void Update(TeamRequest request)
        => _context.TeamRequests.Update(request);
}