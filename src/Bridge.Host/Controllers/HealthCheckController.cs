using Microsoft.AspNetCore.Mvc;

namespace Bridge.Host.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthCheckController : ControllerBase
    {
        private readonly ILogger<HealthCheckController> _logger;

        public HealthCheckController(ILogger<HealthCheckController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "healthcheck")]
        public async Task<IActionResult> GetHealthCheckAsync()
        {
            return new OkResult();
        }
    }
}