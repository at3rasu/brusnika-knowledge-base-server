using MediatR;

namespace BrusnikaKnowledgeBaseServer.Application.Actions.AbstactActions
{
    public abstract class AbstractKnowledgeAction
    {
        protected readonly IMediator mediator;

        public AbstractKnowledgeAction(IMediator mediator)
        {
            this.mediator = mediator;
        }
    }
}
