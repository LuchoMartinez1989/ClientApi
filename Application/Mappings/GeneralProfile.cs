using Application.DTOs;
using Application.Features.Clients.Commands.CreateClientCommand;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class GeneralProfile:Profile
    {

        public GeneralProfile()
        {
            #region Commmands
            CreateMap<CreateClientCommand, Client>();
            #endregion

            #region DTOs
            CreateMap<Client, ClientDTO>();

            #endregion
        }
    }
}
