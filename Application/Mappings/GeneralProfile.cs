// Alberto Segundo Palencia Benedetty

using Application.Feautures.Author.Commands.CreateAuthorCommand;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class GeneralProfile: Profile
    {
        public GeneralProfile()
        {
            #region Commands

            CreateMap<CreateAuthorCommand, Author>();

            #endregion
        }
    }
}