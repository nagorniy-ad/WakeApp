using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WakeApp.Core;

namespace WakeApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WolController : ControllerBase
    {
        private readonly IWolService _wolService;

        public WolController(IWolService wolService)
        {
            _wolService = wolService ?? throw new ArgumentNullException(nameof(wolService));
        }

        [HttpPost]
        public async Task<IActionResult> WakeUpAsync(WolData data)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            var endpoint = data.ToRemoteEndPoint();
            try
            {
                await _wolService.WakeUpAsync(remoteEndPoint: endpoint);
                return Ok();
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message);
            }
        }
    }
}