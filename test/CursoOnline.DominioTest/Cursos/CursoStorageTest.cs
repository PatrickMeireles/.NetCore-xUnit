using Bogus;
using CursoOnline.Application.Services;
using CursoOnline.Application.ViewModel;
using CursoOnline.Dominio.Interface;
using CursoOnline.DominioTest._builder;
using CursoOnline.DominioTest.Extensions;
using CursoOnline.Entidades;
using Moq;
using System;
using Xunit;

namespace CursoOnline.DominioTest.Cursos
{
    public class CursoStorageTest
    {
        private readonly CursoViewModel _cursoVM;

        private readonly CursoAppServices _cursoRepository;

        private readonly Mock<ICursoRepository> _curso;

        public CursoStorageTest()
        {
            var faker = new Faker();

            _cursoVM = new CursoViewModel()
            {
                Nome = faker.Random.Word(),
                CargaHoraria = faker.Random.Double(1, 99),
                Descricao = faker.Lorem.Paragraph(),
                PublicoAlvo = faker.Random.Byte(1,4),
                Valor = faker.Random.Double(1, 1000)
            };

            _curso = new Mock<ICursoRepository>();
            _cursoRepository = new CursoAppServices(_curso.Object);
        }

        [Fact]
        public void HaveCreateCurso()
        {
            _cursoRepository.Add(_cursoVM);

            //_curso.Verify(x => x.Add(It.IsAny<Curso>()));

            //MOCK
            _curso.Verify(x => x.Add(It.Is<Curso>(
                        c => c.Nome == _cursoVM.Nome &&
                        c.Descricao == _cursoVM.Descricao)));
        }

        [Fact]
        public void CannotCreteWithExistSameName()
        {
            var cursoJaSalvo = CursoBuilder.New().WithName(_cursoVM.Nome).Build();
            _curso.Setup(x => x.GetFirstByName(_cursoVM.Nome)).ReturnsAsync(cursoJaSalvo);

            
            Assert.Throws<ArgumentException>(() => _cursoRepository.Add(_cursoVM))
                  .WithMessage("Nome do curso já existente");
        }
    }
}
