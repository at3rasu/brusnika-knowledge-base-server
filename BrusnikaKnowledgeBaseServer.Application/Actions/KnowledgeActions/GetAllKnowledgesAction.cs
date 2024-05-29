using BrusnikaKnowledgeBaseServer.Application.Actions.AbstactActions;
using BrusnikaKnowledgeBaseServer.Application.Queries.KnowledgeQueries;
using BrusnikaKnowledgeBaseServer.Core.Models.DbModels;
using BrusnikaKnowledgeBaseServer.Core.Models.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrusnikaKnowledgeBaseServer.Application.Actions.KnowledgeActions
{
    public class GetAllKnowledgesAction : AbstractKnowledgeAction
    {
        public GetAllKnowledgesAction(IMediator mediator) : base(mediator)
        { }

        public async Task<KnowledgeDto[]> GetAllKnowledges()
        {

            return await mediator.Send(new GetAllKnowledgesQuery());
        }
    }

}
