using BrusnikaKnowledgeBaseServer.Core.Interfaces;


namespace BrusnikaKnowledgeBaseServer.Application
{
    public abstract class AbstractHandler
    {
        protected readonly IUploadFileDbContext db;


        public AbstractHandler(IUploadFileDbContext context)
        {
            db = context;
        }
    }
}
