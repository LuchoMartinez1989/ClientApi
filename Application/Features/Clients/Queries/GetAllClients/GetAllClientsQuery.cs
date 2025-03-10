using Application.DTOs;
using Application.Interfaces;
using Application.Specifications;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Clients.Queries.GetAllClients
{
    public class GetAllClientsQuery : IRequest<Response<List<ClientDTO>>>
    {
        public string? IdenticacionCode { get; set; }
        public string? Name { get; set; }
        public string? Lastnames { get; set; }
        public string? Mail { get; set; }
        public int? IdTypeIdentification { get; set; }
        public string? Address { get; set; }
        public DateTime? BornDate { get; set; }
        public string? Phone { get; set; }
        public string? Gender { get; set; }

    }

    public class GetAllClientsQueryHandler : IRequestHandler<GetAllClientsQuery, Response<List<ClientDTO>>>
    {
        private readonly IRepositoryAsync<Client> _repositoryAsync;
        private readonly IMapper _mapper;
        public GetAllClientsQueryHandler(IRepositoryAsync<Client> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }
        public async Task<Response<List<ClientDTO>>> Handle(GetAllClientsQuery request, CancellationToken cancellationToken)
        {
            var records = await _repositoryAsync.ListAsync(new ClientSpecification(request.IdenticacionCode,request.Name, request.Lastnames
                , request.Mail, request.IdTypeIdentification, request.Address, request.BornDate, request.Phone,request.Gender));
            var recorsDTO = _mapper.Map<List<ClientDTO>>(records); 
            return new Response<List<ClientDTO>>(recorsDTO);

        }
    }
}
