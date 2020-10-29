using Bogus;
using CursoOnline.DominioTest._builder;
using CursoOnline.DominioTest.Extensions;
using CursoOnline.Entidades;
using CursoOnline.Entidades.Enuns;
using ExpectedObjects;
using System;
using Xunit;

namespace CursoOnline.DominioTest.Cursos
{
    public class CursoTest : IDisposable
    {
        private readonly string _nome;
        private readonly double _cargaHoraria;
        private readonly byte _publicoAlvo;
        private readonly double _valor;
        private readonly string _descricao;
        public CursoTest()
        {
            var faker = new Faker();

            _nome = faker.Random.Word();
            _cargaHoraria = faker.Random.Double(1, 99);
            _publicoAlvo = (byte)PublicoAlvo.Estudante;
            _valor = faker.Random.Double(1, 1000);
            _descricao = faker.Lorem.Paragraph();
        }

        public void Dispose()
        {
            
        }

        [Fact]
        public void DeveCriarCurso()
        {
            //Arrange
            var cursoEsperado = new
            {
                Nome = _nome,
                CargaHoraria = _cargaHoraria,
                PublicoAlvo = _publicoAlvo,
                Valor = _valor,
                Descricao = _descricao
            };

            //Action
            var curso = new Curso(cursoEsperado.Nome, cursoEsperado.Descricao, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.Valor);

            //Assert
            cursoEsperado.ToExpectedObject().ShouldMatch(curso);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void NaoDeveTerCursoComNomeVazio(string nomeInvalido)
        {            
            Assert.Throws<ArgumentException>(() => CursoBuilder.New().WithName(nomeInvalido).Build()).WithMessage("Nome Inválido.");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        public void NaoDeveTerCargaHorariaMelhorQueUm(double cargaHoraria)
        {
            Assert.Throws<ArgumentException>(() => CursoBuilder.New().WithCargaHoraria(cargaHoraria).Build()).WithMessage("Carga horária inválida.");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-5)]
        public void NaoDeveTerCursoComValorMenorQueUm(double valor)
        {
            Assert.Throws<ArgumentException>(() => CursoBuilder.New().WithValor(valor).Build()).WithMessage("Valor inválido.");
        }

        [Theory]
        [InlineData(5)]
        [InlineData(99)]
        public void NaoDeveTerPublicoAlvoInvalido(byte value)
        {
            Assert.Throws<ArgumentException>(() => CursoBuilder.New().WithPublicoAlvo(value).Build()).WithMessage("Publico alvo inválido.");
        }
    }
}
