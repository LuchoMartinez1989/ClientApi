using Application.Features.Clients.Commands.CreateClientCommand;
using Application.Features.Clients.Commands.DeleteClientCommand;
using Application.Features.Clients.Commands.UpdateClientCommand;
using Application.Features.Clients.Queries.GetAllClients;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{

    public class ClientController : BaseApiController
    {

        [HttpPost]
        public async Task<ActionResult> Post(CreateClientCommand command) => Ok(await Mediator.Send(command));

        [HttpPut]
        public async Task<ActionResult> Put(UpdateClientCommand command) => Ok(await Mediator.Send(command));

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id) => Ok(await Mediator.Send(new DeleteClientCommand() { Id = id }));

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
