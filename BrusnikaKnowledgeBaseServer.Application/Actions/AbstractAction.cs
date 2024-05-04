using MediatR;

namespace BrusnikaKnowledgeBaseServer.Application.Services.Actions
{
    public abstract class AbstractAction
    {
        protected readonly IMediator mediator;

        public AbstractAction(IMediator mediator)
        {
            this.mediator = mediator;
        }
    }
}
