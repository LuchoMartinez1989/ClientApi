using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Clients.Commands.UpdateClientCommand
{
    public class UpdateClientCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string IdenticacionCode { get; set; }
        public string Name { get; set; }
        public string Lastnames { get; set; }
        public string Mail { get; set; }
        public int IdTypeIdentification { get; set; }
        public string Address { get; set; }
        public DateTime BornDate { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
    }
    public class UpdateClientCommandHandler
    {

        private readonly IRepositoryAsync<Client> _repositoryAsync;

        private readonly IMapper _mapper;
        public UpdateClientCommandHandler(IRepositoryAsync<Client> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {

            var record = await _repositoryAsync.GetByIdAsync(request.Id);
            if (record == null) { throw new KeyNotFoundException($"Record not found with Id: {request.Id}"); }
            else
            {
                record.Name = request.Name;
                record.Lastnames = request.Lastnames;
                record.Mail = request.Mail;
                await _repositoryAsync.UpdateAsync(record);
            }

            var data = await _repositoryAsync.AddAsync(record);
            return new Response<int>(record.Id);
        }
    }

}
