using BrusnikaKnowledgeBaseServer.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrusnikaKnowledgeBaseServer.Application.Commands.AbstractHandlers
{
    public class AbstractKnowledgeHandler
    {
        protected readonly IKnowledgeDbContext db;


        public AbstractKnowledgeHandler(IKnowledgeDbContext context)
        {
            db = context;
        }
    }
}
