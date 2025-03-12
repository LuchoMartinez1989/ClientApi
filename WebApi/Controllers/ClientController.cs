using Application.Features.Clients.Commands.CreateClientCommand;
using Application.Features.Clients.Commands.DeleteClientCommand;
using Application.Features.Clients.Commands.UpdateClientCommand;
using Application.Features.Clients.Queries.GetAllClients;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{

    public class ClientController : BaseApiController
    {
        //[Authorize(Roles ="Administrator,Manager")]// personaliza que perfil puede realziar ejecuciones del endpoint
        [HttpPost]
        public async Task<ActionResult> Post(CreateClientCommand command) => Ok(await Mediator.Send(command));

        //[Authorize(Roles = "Administrator,Manager")]// personaliza que perfil puede realziar ejecuciones del endpoint
        [HttpPut]
        public async Task<ActionResult> Put(UpdateClientCommand command) => Ok(await Mediator.Send(command));

        //[Authorize(Roles = "Administrator,Manager")]// personaliza que perfil puede realziar ejecuciones del endpoint
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id) => Ok(await Mediator.Send(new DeleteClientCommand() { Id = id }));

        //[Authorize(Roles = "Administrator,Manager")]// personaliza que perfil puede realziar ejecuciones del endpoint
        [HttpGet]
        public async Task<ActionResult> Get([FromQuery] GelAllClientsParameters query) => Ok(await Mediator.Send
            (new GetAllClientsQuery()
                {
                    IdenticacionCode = query.IdenticacionCode,
                    Name = query.Name,
                    Lastnames = query.Lastnames,
                    Mail = query.Mail,
                    IdTypeIdentification = query.IdTypeIdentification,
                    Address = query.Address,
                    BornDate = query.BornDate,
                    Phone = query.Phone,
                    Gender = query.Gender
            }
            ));
    }
}
