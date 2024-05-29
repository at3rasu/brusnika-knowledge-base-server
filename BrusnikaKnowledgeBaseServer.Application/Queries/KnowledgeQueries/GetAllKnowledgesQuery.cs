using AutoMapper;
using AutoMapper.QueryableExtensions;
using BrusnikaKnowledgeBaseServer.Application.Commands.AbstractHandlers;
using BrusnikaKnowledgeBaseServer.Core.Interfaces;
using BrusnikaKnowledgeBaseServer.Core.Models.DbModels;
using BrusnikaKnowledgeBaseServer.Core.Models.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrusnikaKnowledgeBaseServer.Application.Queries.KnowledgeQueries
{
    public class GetAllKnowledgesQuery : IRequest<KnowledgeDto[]>
    {
    }

    internal class GetAllKnowledgesQueryHandler : AbstractKnowledgeHandler, IRequestHandler<GetAllKnowledgesQuery, KnowledgeDto[]>
    {
        private readonly IMapper mapper;

        public GetAllKnowledgesQueryHandler(IKnowledgeDbContext context, IMapper mapper) : base(context)
        {
            this.mapper = mapper;
        }

        public async Task<KnowledgeDto[]> Handle(GetAllKnowledgesQuery request, CancellationToken cancellationToken)
        {
            return await db.Knowledges
                .ProjectTo<KnowledgeDto>(mapper.ConfigurationProvider)
                .ToArrayAsync();
        }
    }
}
