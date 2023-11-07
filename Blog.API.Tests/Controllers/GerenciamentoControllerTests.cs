using Blog.API.Data.Context;
using Blog.API.Data.Interfaces;
using Blog.API.Data.Models;
using Blog.API.Data.Repositories;
using Blog.API.Data.Services;
using Blog.API.Gerenciamento.Controllers;
using Blog.API.Tests.Fixtures;
using Bogus;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;

namespace Blog.API.Tests.Controllers
{
    [Collection(nameof(GerenciamentoControllerTestFixtureCollection))]
    public class GerenciamentoControllerTests
    {
        private const string CULTURE_CODE = "pt_BR";
        private readonly GerenciamentoControllerTestFixture _fixture;

        public GerenciamentoControllerTests(GerenciamentoControllerTestFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact(DisplayName = "1 - Validando se é possível adicionar 5 notícias")]
        [Trait("Categoria", "Teste de Integração")]
        public void ValidateController_ShouldReturnTrue_WhenAddingNoticias()
        {
            // Arrange
            //Gerando noticias aleatorias
            var noticiaFaker = new Faker<Noticia>(CULTURE_CODE)
                .RuleFor(n => n.Titulo, f => f.Lorem.Sentence(1, 4))
                .RuleFor(n => n.Descricao, f => f.Lorem.Sentence(10, 5))
                .RuleFor(n => n.Conteudo, f => f.Lorem.Sentence(20, 10))
                .RuleFor(n => n.DataPublicacao, f => f.Date.Recent(1000, new DateTime(2021, 01, 01)))
                .RuleFor(n => n.Autor, f => f.Name.FullName())
                .RuleFor(n => n.DataAtualizacao, f => f.Date.Recent(100));

            var noticias = noticiaFaker.Generate(5);

            // Act
            var result = new List<IActionResult>();

            noticias.ForEach(noticia =>
            {
                var requestResult = _fixture.GerenciamentoController.Adicionar(noticia).Result;
                if (requestResult is OkObjectResult)
                    result.Add(requestResult);
            });

            // Assert
            Assert.NotEmpty(result);
            Assert.Equal(5, result.Count);
        }

        [Fact(DisplayName = "2 - Validando se é possível consultar as 5 notícias")]
        [Trait("Categoria", "Teste de Integração")]
        public void ValidateController_ShouldReturnTrue_WhenRetrievingAllNoticias()
        {
            // Arrange
            var result = _fixture.GerenciamentoController.ObterTodas().Result;

            // Act
            
            // Assert
            Assert.NotEmpty(result);
            Assert.Equal(5, result.Count());
        }
    }
}
