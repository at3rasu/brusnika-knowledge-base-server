using BrusnikaKnowledgeBaseServer.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrusnikaKnowledgeBaseServer.Application.Commands.AbstractHandlers
{
    public class AbstractFormuleHandler
    {
        protected readonly IFormuleDbContext db;


        public AbstractFormuleHandler(IFormuleDbContext context)
        {
            db = context;
        }
    }
}
