using Microsoft.AspNetCore.Mvc;
using SkillBridge.Application.DTOs.Request;
using SkillBridge.Application.Services;

namespace SkillBridge.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RequestsController : ControllerBase
{
    private readonly TeamRequestService _requestService;

    public RequestsController(TeamRequestService requestService)
    {
        _requestService = requestService;
    }

    // POST api/requests — Send Request
    [HttpPost]
    public async Task<IActionResult> Send([FromBody] SendRequestDto dto, [FromQuery] int senderId)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var result = await _requestService.SendRequestAsync(senderId, dto);
        return Ok(result);
    }

    // PUT api/requests/{id}/respond — Accept or Reject
    [HttpPut("{id}/respond")]
    public async Task<IActionResult> Respond(int id, [FromQuery] int userId, [FromQuery] string status)
    {
        if (status != "Accepted" && status != "Rejected")
            return BadRequest(new { message = "Status must be 'Accepted' or 'Rejected'." });

        var result = await _requestService.RespondToRequestAsync(id, userId, status);
        if (result == null) return NotFound(new { message = "Request not found or unauthorized." });
        return Ok(result);
    }

    // GET api/requests/sent/{userId} — Sent requests dashboard
    [HttpGet("sent/{userId}")]
    public async Task<IActionResult> GetSent(int userId)
    {
        var requests = await _requestService.GetSentRequestsAsync(userId);
        return Ok(requests);
    }

    // GET api/requests/received/{userId} — Received requests dashboard
    [HttpGet("received/{userId}")]
    public async Task<IActionResult> GetReceived(int userId)
    {
        var requests = await _requestService.GetReceivedRequestsAsync(userId);
        return Ok(requests);
    }
}