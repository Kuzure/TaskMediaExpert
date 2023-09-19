using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TaskMediaExpert.Api.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        protected readonly IMediator Mediator;

        protected BaseController(IMediator mediator)
        {
            Mediator = mediator;
        }

        protected async Task<ActionResult> ExecuteCommand(Func<Task> command)
        {
            await command.Invoke();
            return Accepted();
        }

        protected async Task<ActionResult> ExecuteQuery<TResponse>(Func<Task<TResponse>> query)
        {
            var result = await query.Invoke();
            return Ok(result);
        }

        protected async Task<ActionResult> ExecuteCommandWithResult<TResponse>(Func<Task<TResponse>> command)
        {
            var result = await command.Invoke();
            return Accepted(result);
        }

        protected async Task<ActionResult> ExecuteFileDownload(Func<Task<(byte[], string)>> command)
        {
            var result = await command.Invoke();
            return File(result.Item1, "application/octet-stream", result.Item2);
        }
    }
}
