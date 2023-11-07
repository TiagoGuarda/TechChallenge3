using Blog.API.Tests.Fixtures;

namespace Blog.API.Tests.Services
{
    [Collection(nameof(NoticiaTestFixtureCollection))]
    public class NoticiaServiceTests
    {
        private readonly NoticiaTestFixture _fixture;

        public NoticiaServiceTests(NoticiaTestFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact(DisplayName = "1 - Validando se esta adicionando corretamente")]
        [Trait("Categoria", "Validando Noticia Services")]
        public void ValidateService_ShouldReturnTrue_WhenAddingNoticia()
        {
            // Arrange
            var noticia = _fixture.GerarNoticia();

            // Act
            var result = _fixture.NoticiaService.Adicionar(noticia).Result;

            // Assert
            Assert.Equal(1, result);
        }

        [Fact(DisplayName = "2 - Validando se esta retornando todos os registros")]
        [Trait("Categoria", "Validando Noticia Services")]
        public void ValidateService_ShouldReturnTrue_WhenRetrievingAllNoticias()
        {
            // Arrange
            // Considerando que a noticia foi adicionada no teste anterior

            // Act
            var result = _fixture.NoticiaService.ObterTodas().Result;

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact(DisplayName = "3 - Validando se esta retornando o registro informado")]
        [Trait("Categoria", "Validando Noticia Services")]
        public void ValidateService_ShouldReturnTrue_WhenRetrievingNoticia()
        {
            // Arrange
            // Considerando que a noticia foi adicionada no teste anterior

            // Act
            var result = _fixture.NoticiaService.ObterPorId(1).Result;

            // Assert
            Assert.NotNull(result);
        }

        [Fact(DisplayName = "4 - Validando se esta atualizando corretamente")]
        [Trait("Categoria", "Validando Noticia Services")]
        public void ValidateService_ShouldReturnTrue_WhenUpdatingNoticia()
        {
            // Arrange
            var noticia = _fixture.NoticiaService.ObterPorId(1).Result;
            noticia.Titulo = "Testando novo título";

            // Act
            var result = _fixture.NoticiaService.Atualizar(noticia).Result;

            // Assert
            Assert.Equal(1, result);
        }

        [Fact(DisplayName = "5 - Validando se esta removendo corretamente")]
        [Trait("Categoria", "Validando Noticia Services")]
        public void ValidateService_ShouldReturnTrue_WhenRemovingNoticia()
        {
            // Arrange
            // Considerando que a noticia foi adicionada no teste anterior

            // Act
            var result = _fixture.NoticiaService.Remover(1).Result;

            // Assert
            Assert.Equal(1, result);
        }
    }
}