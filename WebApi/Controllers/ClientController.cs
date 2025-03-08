using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Clients.Commands.CreateClientCommand;

namespace WebApi.Controllers
{
      
    public class ClientController : BaseApiController
    {
        [HttpPost]
        public async Task<ActionResult> Post(CreateClientCommand command) => Ok(await Mediator.Send(command));

    }
}
