using MediatR;
using AutoMapper;
using BrusnikaKnowledgeBaseServer.Core.Interfaces;
using BrusnikaKnowledgeBaseServer.Core.Models.DbModels;
using BrusnikaKnowledgeBaseServer.Core.Models.Dtos;

namespace BrusnikaKnowledgeBaseServer.Application.Commands.KnowledgeCommands
{
    /*internal class CreateKnowledgeCommand : IRequest<int>
    {
        public KnowledgeDto Knowledge { get; set; }
    }
    internal class CreateKnowledgeCommandHandler : AbstractHandler, IRequestHandler<CreateKnowledgeCommand, int>
    {
        private readonly IMapper mapper;

        public CreateKnowledgeCommandHandler(IKnowledgeDbContext context, IMapper mapper) : base(context)
        {
            this.mapper = mapper;
        }

        public async Task<int> Handle(CreateKnowledgeCommand request, CancellationToken cancellationToken)
        {
            var toAdd = mapper.Map<Knowledge>(request.Knowledge);

            await db.AddAsync(toAdd);
            await db.SaveChangesAsync();
            return toAdd.Id;
        }
    }*/
}
