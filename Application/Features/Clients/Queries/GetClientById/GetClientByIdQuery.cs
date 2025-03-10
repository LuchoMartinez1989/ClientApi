using Application.DTOs;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Clients.Queries.GetClientById
{
    public class GetClientByIdQuery : IRequest<Response<ClientDTO>>
    {
        public int Id{ get; set; }
    }
    public class GetClientByIdQueryHandler : IRequestHandler<GetClientByIdQuery, Response<ClientDTO>>
    {
        private readonly IRepositoryAsync<Client> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetClientByIdQueryHandler(IRepositoryAsync<Client> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<ClientDTO>> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
        {
            var record = await _repositoryAsync.GetByIdAsync(request.Id);
            if (record == null) { throw new KeyNotFoundException($"Record not found with Id: {request.Id}"); }
            else
            {
                var recordDTO = _mapper.Map<ClientDTO>(record);

                return new Response<ClientDTO>(recordDTO);
            }
           
        }
    }
}
