using BrusnikaKnowledgeBaseServer.Core.Interfaces;


namespace BrusnikaKnowledgeBaseServer.Application
{
    public abstract class AbstractHandler
    {
        protected readonly IKnowledgeDbContext db;


        public AbstractHandler(IKnowledgeDbContext context)
        {
            db = context;
        }
    }
}
