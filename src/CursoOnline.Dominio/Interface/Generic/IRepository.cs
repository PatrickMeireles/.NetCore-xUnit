using CursoOnline.Entidades.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CursoOnline.Dominio.Interface.Generic
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entidade
    {
        Task<TEntity> Add(TEntity entity);

        Task<IEnumerable<TEntity>> GetAll();

        Task<TEntity> GetById(int id);
    }
}
