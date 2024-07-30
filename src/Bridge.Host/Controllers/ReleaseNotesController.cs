using Bridge.Models;
using Bridge.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bridge.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReleaseNotesController : ControllerBase
    {
        private readonly IEmailService _emailService;
        private readonly IJiraService _jiraService;

        public ReleaseNotesController(IEmailService emailService, IJiraService jiraService)
        {
            _emailService = emailService;
            _jiraService = jiraService;
        }

        [HttpPost]
        [Route("send")]
        public async Task<IActionResult> SendReleaseNotesAsync([FromBody] SendReleaseNotesRequest releaseNotesRequest)
        {
            return Ok(await _jiraService.GetIssueDetailAsync(releaseNotesRequest.TicketId));
        }
    }
}