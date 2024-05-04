using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using BrusnikaKnowledgeBaseServer.Core.Models.DbModels;

namespace BrusnikaKnowledgeBaseServer.Core.Interfaces
{
    public interface IKnowledgeDbContext
    {
        DbSet<Knowledge> Knowledges { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        EntityEntry<TEntity> Add<TEntity>([NotNullAttribute] TEntity entity) where TEntity : class;
        ValueTask<EntityEntry<TEntity>> AddAsync<TEntity>([NotNullAttribute] TEntity entity, CancellationToken cancellationToken = default) where TEntity : class;
    }
}
