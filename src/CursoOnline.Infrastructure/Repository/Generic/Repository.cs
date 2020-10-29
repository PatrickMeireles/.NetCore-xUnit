using CursoOnline.Dominio.Interface.Generic;
using CursoOnline.Entidades.Base;
using CursoOnline.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CursoOnline.Infrastructure.Repository.Generic
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entidade
    {
        protected readonly BaseContext _db;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(BaseContext db)
        {
            _db = db;
            _dbSet = _db.Set<TEntity>();
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await _db.SaveChangesAsync();

            return entity;
        }

        public async Task<IEnumerable<TEntity>> GetAll() => await _dbSet.ToListAsync();

        public async Task<TEntity> GetById(int id) => await _dbSet.FindAsync(id);


        public void Dispose()
        {
            _db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
