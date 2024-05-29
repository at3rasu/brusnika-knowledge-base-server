using BrusnikaKnowledgeBaseServer.Application.Actions.AbstactActions;
using BrusnikaKnowledgeBaseServer.Application.Commands.FormuleCommands;
using BrusnikaKnowledgeBaseServer.Core.Models.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrusnikaKnowledgeBaseServer.Application.Actions.FormuleActions
{
    public class GetFormuleResultAction : AbstractFormuleAction
    {
        public GetFormuleResultAction(IMediator mediator) : base(mediator) { }


        public async Task<ResultWrapperDto> CreateFormule(FormuleResultDto formule)
        {
            /*if (formule.Id. != null || )
            {
                return new ResultWrapperDto
                {
                    ResultStatus = StatusCodes.Status400BadRequest,
                    ResultContent = new ErrorResponseDto
                    {
                        ErrorTextForUser = "Validation error"
                    }
                };
            }*/

            return new ResultWrapperDto
            {
                ResultStatus = StatusCodes.Status200OK,
                ResultContent = await mediator.Send(new GetFormuleResultCommand { Formule = formule })
            };
        }
    }
}
