using CursoOnline.Entidades;
using CursoOnline.Entidades.Enuns;
using System;
using System.Collections.Generic;
using System.Text;

namespace CursoOnline.DominioTest._builder
{
    public class CursoBuilder
    {
        private string _nome = "Matemática";
        private double _cargaHoraria = 90;
        private byte _publicoAlvo = (byte)PublicoAlvo.Estudante;
        private double _valor = 190;
        private string _descricao = "Easy";

        public static CursoBuilder New()
        {
            return new CursoBuilder();
        }

        public CursoBuilder WithName(string value)
        {
            _nome = value;
            return this;
        }

        public CursoBuilder WithCargaHoraria(double value)
        {
            _cargaHoraria = value;
            return this;
        }

        public CursoBuilder WithPublicoAlvo(byte value)
        {
            _publicoAlvo = value;
            return this;
        }

        public CursoBuilder WithValor(double value)
        {
            _valor = value;
            return this;
        }

        public CursoBuilder WithDescricao(string value)
        {
            _descricao = value;
            return this;
        }

        public Curso Build()
        {
            return new Curso(_nome, _descricao, _cargaHoraria, _publicoAlvo, _valor);
        }
    }
}
