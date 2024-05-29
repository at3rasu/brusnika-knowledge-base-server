using BrusnikaKnowledgeBaseServer.Core.Interfaces;
using BrusnikaKnowledgeBaseServer.Core.Models.DbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrusnikaKnowledgeBaseServer.Infrastructure.EfDbContexts
{
    public class FormuleContext : DbContext, IFormuleDbContext
    {
        public FormuleContext()
        {
        }

        public FormuleContext(DbContextOptions<FormuleContext> options)
            : base(options)
        {
        }

        public DbSet<Formule> Formules { get; set; }

    }
}
