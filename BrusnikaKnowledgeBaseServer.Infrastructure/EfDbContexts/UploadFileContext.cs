using BrusnikaKnowledgeBaseServer.Core.Interfaces;
using BrusnikaKnowledgeBaseServer.Core.Models.DbModels;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BrusnikaKnowledgeBaseServer.Infrastructure.EfDbContexts
{
    public partial class UploadFileContext : DbContext, IUploadFileDbContext
    {
        public UploadFileContext()
        {
        }

        public UploadFileContext(DbContextOptions<UploadFileContext> options)
            : base(options)
        {
        }

        public virtual DbSet<UploadFile> UploadFiles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            { }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
