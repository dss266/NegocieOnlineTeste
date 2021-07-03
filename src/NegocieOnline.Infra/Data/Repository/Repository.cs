using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using NegocieOnline.Business.Core.Data;
using NegocieOnline.Business.Core.Models;

namespace NegocieOnline.Infra.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity:Entity, new()
    {
        protected readonly NegocieOnlineDbContext _context;
        protected readonly DbSet<TEntity> DbSet;

        public Repository()
        {
            _context = new NegocieOnlineDbContext();
            DbSet = _context.Set<TEntity>();
        }
        
        public virtual async Task Adicionar(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task<TEntity> ObterPorId(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> ObterTodos()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task Atualizar(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await SaveChanges();
        }

        public virtual async Task Remover(Guid id)
        {
            _context.Entry(new TEntity {Id = id}).State = EntityState.Deleted;
            await SaveChanges();
        }

        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }
    }
}