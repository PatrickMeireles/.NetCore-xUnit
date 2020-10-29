using CursoOnline.Dominio.Interface;
using CursoOnline.Entidades;
using CursoOnline.Infrastructure.Context;
using CursoOnline.Infrastructure.Repository.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CursoOnline.Infrastructure.Repository
{
    public class CursoRepository : Repository<Curso>,  ICursoRepository
    {
        public CursoRepository(BaseContext context): base(context) { }


        public async Task<Curso> GetFirstByName(string name)
        {
            return await _dbSet.Where(x => x.Nome == name)
                               .FirstOrDefaultAsync();
        }
    }
}
