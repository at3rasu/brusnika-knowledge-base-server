
using MediatR;

using BrusnikaKnowledgeBaseServer.Core.Models.Dtos;
using Microsoft.AspNetCore.Http;
using BrusnikaKnowledgeBaseServer.Application.Commands.KnowledgeCommands;
using BrusnikaKnowledgeBaseServer.Application.Actions.AbstactActions;
using BrusnikaKnowledgeBaseServer.Core.Models.DbModels;

namespace BrusnikaKnowledgeBaseServer.Application.Actions.KnowledgeActions
{
    public class CreateKnowledgeAction : AbstractKnowledgeAction
    {
        public CreateKnowledgeAction(IMediator mediator) : base(mediator) { }


        public async Task<ResultWrapperDto> CreateNewKnowledge(KnowledgeCreateDto knowledge)
        {
            

            return new ResultWrapperDto
            {
                ResultStatus = StatusCodes.Status200OK,
                ResultContent = await mediator.Send(new CreateKnowledgeCommand { Knowledge = knowledge })
            };
        }
    }
}
