using CursoOnline.Dominio.Interface.Generic;
using CursoOnline.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CursoOnline.Dominio.Interface
{
    public interface ICursoRepository : IRepository<Curso>
    {
        Task<Curso> GetFirstByName(string name);        
    }
}
