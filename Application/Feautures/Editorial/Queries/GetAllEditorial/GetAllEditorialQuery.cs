// Alberto Segundo Palencia Benedetty

using System.Collections.Generic;
using Application.Wrappers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;

namespace Application.Feautures.Editorial.Queries.GetAllEditorial
{
    public class GetAllEditorialQuery: IRequest<Response<List<EditorialDto>>>
    {

        public class GetAllEditorialQueryHandler : IRequestHandler<GetAllEditorialQuery, Response<List<EditorialDto>>>
        {
            private readonly IRepositoryAsync<Domain.Entities.Editorial> _repository;
            private readonly IMapper _mapper;

            public GetAllEditorialQueryHandler(IRepositoryAsync<Domain.Entities.Editorial> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<Response<List<EditorialDto>>> Handle(GetAllEditorialQuery request, CancellationToken cancellationToken)
            {
                var editorials = await _repository.ListAsync(cancellationToken);
                var editorialsDto = _mapper.Map<List<EditorialDto>>(editorials);
                return new Response<List<EditorialDto>>(editorialsDto);
            }
        }
    }
}