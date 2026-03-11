using SkillBridge.Application.DTOs.Request;
using SkillBridge.Core.Entities;
using SkillBridge.Core.Interfaces;

namespace SkillBridge.Application.Services;

public class TeamRequestService
{
    private readonly IUnitOfWork _uow;

    public TeamRequestService(IUnitOfWork uow)
    {
        _uow = uow;
    }

    // ── SEND REQUEST ──────────────────────────────────
    public async Task<RequestStatusDto> SendRequestAsync(int senderId, SendRequestDto dto)
    {
        var request = new TeamRequest
        {
            ProjectId = dto.ProjectId,
            SenderId = senderId,
            ReceiverId = dto.ReceiverId,
            Message = dto.Message,
            Status = "Pending"
        };

        await _uow.TeamRequests.AddAsync(request);
        await _uow.SaveChangesAsync();

        var created = await _uow.TeamRequests.GetByIdAsync(request.RequestId);
        return MapToDto(created!);
    }

    // ── RESPOND TO REQUEST ────────────────────────────
    public async Task<RequestStatusDto?> RespondToRequestAsync(int requestId, int userId, string status)
    {
        var request = await _uow.TeamRequests.GetByIdAsync(requestId);
        if (request == null || request.ReceiverId != userId)
            return null;

        request.Status = status; // "Accepted" or "Rejected"
        request.RespondedAt = DateTime.UtcNow;

        _uow.TeamRequests.Update(request);
        await _uow.SaveChangesAsync();

        return MapToDto(request);
    }

    // ── GET SENT REQUESTS ─────────────────────────────
    public async Task<List<RequestStatusDto>> GetSentRequestsAsync(int userId)
    {
        var requests = await _uow.TeamRequests.GetSentByUserAsync(userId);
        return requests.Select(MapToDto).ToList();
    }

    // ── GET RECEIVED REQUESTS ─────────────────────────
    public async Task<List<RequestStatusDto>> GetReceivedRequestsAsync(int userId)
    {
        var requests = await _uow.TeamRequests.GetReceivedByUserAsync(userId);
        return requests.Select(MapToDto).ToList();
    }

    // ── MAPPER ────────────────────────────────────────
    private static RequestStatusDto MapToDto(TeamRequest r) => new()
    {
        RequestId = r.RequestId,
        ProjectId = r.ProjectId,
        ProjectTitle = r.Project?.Title ?? "",
        SenderId = r.SenderId,
        SenderName = r.Sender?.FullName ?? "",
        ReceiverId = r.ReceiverId,
        ReceiverName = r.Receiver?.FullName ?? "",
        Status = r.Status,
        Message = r.Message,
        SentAt = r.SentAt,
        RespondedAt = r.RespondedAt
    };
}