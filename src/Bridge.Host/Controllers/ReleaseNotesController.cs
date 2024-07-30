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

        public ReleaseNotesController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        [Route("send")]
        public async Task<IActionResult> SendReleaseNotesAsync([FromBody] SendReleaseNotesRequest releaseNotesRequest)
        {
            return Ok();
        }
    }
}