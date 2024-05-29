using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrusnikaKnowledgeBaseServer.Application.Actions.AbstactActions
{
    public abstract class AbstractFormuleAction
    {
        protected readonly IMediator mediator;

        public AbstractFormuleAction(IMediator mediator)
        {
            this.mediator = mediator;
        }
    }
}
