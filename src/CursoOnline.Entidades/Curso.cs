using CursoOnline.Entidades.Base;
using CursoOnline.Entidades.Enuns;
using System;
using System.Linq;

namespace CursoOnline.Entidades
{
    public class Curso : Entidade
    {
        public string Nome { get; private set; }
        public double CargaHoraria { get; private set; }
        public byte PublicoAlvo { get; private set; }
        public double Valor { get; private set; }
        public string Descricao { get; private set; }

        public Curso(string _nome, string _descricao, double _cargaHoraria, byte _publicoAlvo, double _valor)
        {
            if (String.IsNullOrEmpty(_nome) || String.IsNullOrWhiteSpace(_nome))
                throw new ArgumentException("Nome Inválido.");

            if (_cargaHoraria < 1)
                throw new ArgumentException("Carga horária inválida.");

            if (_valor < 1)
                throw new ArgumentException("Valor inválido.");

            if (!(Enum.GetValues(typeof(PublicoAlvo)).Cast<PublicoAlvo>().Where(x => (byte)x == _publicoAlvo).Any()))
                throw new ArgumentException("Publico alvo inválido.");

            this.Nome = _nome;
            this.Descricao = _descricao;
            this.CargaHoraria = _cargaHoraria;
            this.PublicoAlvo = _publicoAlvo;
            this.Valor = _valor;
        }
    }
}
