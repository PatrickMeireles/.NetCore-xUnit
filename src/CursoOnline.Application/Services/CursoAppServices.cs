using CursoOnline.Application.Interfaces;
using CursoOnline.Application.ViewModel;
using CursoOnline.Dominio.Interface;
using CursoOnline.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace CursoOnline.Application.Services
{
    public class CursoAppServices : ICursoAppServices
    {
        private readonly ICursoRepository _curso;

        public CursoAppServices(ICursoRepository curso)
        {
            _curso = curso;
        }

        public void Add(CursoViewModel curso)
        {
            var cursoJaSalvo = _curso.GetFirstByName(curso.Nome);

            if (cursoJaSalvo != null)
                throw new ArgumentException("Nome do curso já existente");

            var newCurso = new Curso(curso.Nome, curso.Descricao, curso.CargaHoraria, curso.PublicoAlvo, curso.Valor);

            _curso.Add(newCurso);
        }
    }
}
