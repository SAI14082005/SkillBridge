using SkillBridge.Core.Entities;

namespace SkillBridge.Core.Interfaces;

public interface ITeamRequestRepository
{
    Task<TeamRequest?> GetByIdAsync(int requestId);
    Task<IEnumerable<TeamRequest>> GetSentByUserAsync(int senderId);
    Task<IEnumerable<TeamRequest>> GetReceivedByUserAsync(int receiverId);
    Task AddAsync(TeamRequest request);
    void Update(TeamRequest request);
}