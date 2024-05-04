
using MediatR;

using BrusnikaKnowledgeBaseServer.Core.Models.Dtos;
using Microsoft.AspNetCore.Http;
using BrusnikaKnowledgeBaseServer.Application.Commands.KnowledgeCommands;

namespace BrusnikaKnowledgeBaseServer.Application.Actions.KnowledgeActions
{
    /*public class CreateKnowledgeAction : AbstractAction
    {
        public CreateKnowledgeAction(IMediator mediator) : base(mediator) { }

        
        public async Task<ResultWrapperDto> CreateNewKnowledge(KnowledgeDto knowledge)
        {
            if (knowledge.Id != null || !string.IsNullOrEmpty(knowledge.Title))
            {
                return new ResultWrapperDto
                {
                    ResultStatus = StatusCodes.Status400BadRequest,
                    ResultContent = new ErrorResponseDto
                    {
                        ErrorTextForUser = "Validation error"
                    }
                };
            }

            return new ResultWrapperDto
            {
                ResultStatus = StatusCodes.Status200OK,
                ResultContent = await mediator.Send(new CreateKnowledgeCommand { Knowledge = knowledge })
            };
        }
    }*/
}
