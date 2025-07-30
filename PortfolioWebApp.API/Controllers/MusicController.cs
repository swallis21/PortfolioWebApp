using MediatR;
using Microsoft.AspNetCore.Mvc;
using PortfolioWebApp.Application.Features.MusicAPI.Queries;
using System.Threading.Tasks;

namespace PortfolioWebApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MusicController : ControllerBase
    {

        private readonly ILogger<MusicController> _logger;
        private readonly IMediator _mediator;

        public MusicController(ILogger<MusicController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("NextSong")]
        public async Task<ActionResult> GetNextSong()
        {
            var result = await _mediator.Send(new GetNextSongQuery());
            if (result == null)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        [HttpGet("RandomSong")]
        public async Task<ActionResult> GetRandomSong()
        {
            var result = await _mediator.Send(new GetRandomSongQuery());
            if (result == null)
            {
                return NotFound(result);
            }
            return Ok(result);
        }
    }
}
