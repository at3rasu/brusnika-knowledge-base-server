using BrusnikaKnowledgeBaseServer.Core.Interfaces;
using BrusnikaKnowledgeBaseServer.Core.Models.DbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BrusnikaKnowledgeBaseServer.Infrastructure.EfDbContexts
{
    public class KnowledgeContext : DbContext, IKnowledgeDbContext
    {
        public KnowledgeContext()
        {
        }

        public KnowledgeContext(DbContextOptions<KnowledgeContext> options)
            : base(options)
        {
        }

        public DbSet<Knowledge> Knowledges { get; set; }
    }
}
