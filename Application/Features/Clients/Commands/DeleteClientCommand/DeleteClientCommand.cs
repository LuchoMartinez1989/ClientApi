using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Clients.Commands.DeleteClientCommand
{
    public class DeleteClientCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }

        public class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand, Response<int>>
        {
            private readonly IRepositoryAsync<Client> _repositoryAsync;

            private readonly IMapper _mapper;

            public DeleteClientCommandHandler(IRepositoryAsync<Client> repositoryAsync, IMapper mapper)
            {
                _repositoryAsync = repositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<int>> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
            {

                var record = await _repositoryAsync.GetByIdAsync(request.Id);
                if (record == null) { throw new KeyNotFoundException($"Record not found with Id: {request.Id}"); }
                else
                {
                    await _repositoryAsync.DeleteAsync(record);
                }
                return new Response<int>(record.Id);
            }
        }
    }
}
