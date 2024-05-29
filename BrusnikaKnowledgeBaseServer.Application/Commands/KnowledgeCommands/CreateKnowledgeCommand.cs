using MediatR;
using AutoMapper;
using BrusnikaKnowledgeBaseServer.Core.Interfaces;
using BrusnikaKnowledgeBaseServer.Core.Models.DbModels;
using BrusnikaKnowledgeBaseServer.Core.Models.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.JsonPatch;
using BrusnikaKnowledgeBaseServer.Application.Commands.AbstractHandlers;
using Microsoft.AspNetCore.Http;

namespace BrusnikaKnowledgeBaseServer.Application.Commands.KnowledgeCommands
{
    internal class CreateKnowledgeCommand : IRequest<Knowledge>
    {
        public KnowledgeCreateDto Knowledge { get; set; }
        public JsonPatchDocument<Knowledge> PatchModel { get; set; }
    }
    internal class CreateKnowledgeCommandHandler : AbstractKnowledgeHandler, IRequestHandler<CreateKnowledgeCommand, Knowledge>
    {
        private readonly IMapper mapper;

        public CreateKnowledgeCommandHandler(IKnowledgeDbContext context, IMapper mapper) : base(context)
        {
            this.mapper = mapper;
        }

        public async Task<Knowledge> Handle(CreateKnowledgeCommand request, CancellationToken cancellationToken)
        {
            var toAdd = mapper.Map<Knowledge>(request.Knowledge);
            await db.AddAsync(toAdd);
            await db.SaveChangesAsync();

            if (toAdd.Content != null)
            {
                var defaultPath = $"MyStaticFiles";
                var subDirPath = $"Knowledge{toAdd.Id}";

                var directoryInfo = new DirectoryInfo(defaultPath + "/Knowledges");
                if (!directoryInfo.Exists)
                {
                    directoryInfo.Create();
                }


                string fileName = Path.GetFileNameWithoutExtension(request.Knowledge.Content.FileName);
                var fileExtension = Path.GetExtension(request.Knowledge.Content.FileName);
                var title = fileName + toAdd.Id + fileExtension;
                string path = Path.Combine(defaultPath + "/Knowledges/" + title);

                using (var FileStream = new FileStream(path, FileMode.Create))
                {
                    await request.Knowledge.Content.CopyToAsync(FileStream);
                }
                toAdd.Src = $"api/StaticFiles/Knowledges/{title}";
                toAdd.FileName = request.Knowledge.Content.FileName;
                db.Update(toAdd);
                await db.SaveChangesAsync();
            }
            return toAdd;
        }
    }
}
