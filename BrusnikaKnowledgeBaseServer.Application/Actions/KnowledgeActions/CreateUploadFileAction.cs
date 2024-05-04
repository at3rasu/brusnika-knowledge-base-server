using BrusnikaKnowledgeBaseServer.Application.Commands.UploadFileCommands;
using BrusnikaKnowledgeBaseServer.Application.Services.Actions;
using BrusnikaKnowledgeBaseServer.Core.Models.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace BrusnikaKnowledgeBaseServer.Application.Actions.UploadFileActions
{
    public class CreateUploadFileAction : AbstractAction
    {
        public CreateUploadFileAction(IMediator mediator) : base(mediator) { }


        public async Task<ResultWrapperDto> CreateNewFile(UploadFileDto file)
        {
            if (file.Id != null || !string.IsNullOrEmpty(file.Name))
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
                ResultContent = await mediator.Send(new CreateUploadFileCommand { UploadFile = file })
            };
        }
    }
}
