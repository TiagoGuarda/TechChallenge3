using Blog.API.Tests.Fixtures;

namespace Blog.API.Tests.Models
{
    [Collection(nameof(NoticiaTestFixtureCollection))]
    public class NoticiaTests
    {
        private readonly NoticiaTestFixture _fixture;

        public NoticiaTests(NoticiaTestFixture fixture) 
        { 
            _fixture = fixture;
        }

        [Fact(DisplayName = "1 - Validando exceção quando o campo título está nulo")]
        [Trait("Categoria", "Validando Noticia Model - Título")]
        public void ValidateModel_ShouldReturnException_WhenTituloIsNull()
        {
            // Arrange
            var noticia = _fixture.GerarNoticiaTituloNulo();

            // Act
            var result = _fixture.ValidarModelo(noticia);

            // Assert
            Assert.Contains(result, x => x.ErrorMessage == "O valor do campo Título não pode ser nulo");
        }

        [Fact(DisplayName = "2 - Validando exceção quando o campo título for maior que 255 caracteres")]
        [Trait("Categoria", "Validando Noticia Model - Título")]
        public void ValidateModel_ShouldReturnException_WhenTituloLengthIsHigherThan255Chars()
        {
            // Arrange
            var noticia = _fixture.GerarNoticiaTituloMaior255Caracteres();

            // Act
            var result = _fixture.ValidarModelo(noticia);

            // Assert
            Assert.Contains(result, x => x.ErrorMessage == "O valor máximo permitido para o campo Título é de 255 caracteres");
        }

        [Fact(DisplayName = "1 - Validando exceção quando o campo descrição está nulo")]
        [Trait("Categoria", "Validando Noticia Model - Descrição")]
        public void ValidateModel_ShouldReturnException_WhenDescricaoIsNull()
        {
            // Arrange
            var noticia = _fixture.GerarNoticiaDescricaoNula();

            // Act
            var result = _fixture.ValidarModelo(noticia);

            // Assert
            Assert.Contains(result, x => x.ErrorMessage == "O valor do campo Descrição não pode ser nulo");
        }

        [Fact(DisplayName = "2 - Validando exceção quando o campo descrição for maior que 500 caracteres")]
        [Trait("Categoria", "Validando Noticia Model - Descrição")]
        public void ValidateModel_ShouldReturnException_WhenDescricaoLengthIsHigherThan500Chars()
        {
            // Arrange
            var noticia = _fixture.GerarNoticiaDescricaoMaior500Caracteres();

            // Act
            var result = _fixture.ValidarModelo(noticia);

            // Assert
            Assert.Contains(result, x => x.ErrorMessage == "O valor máximo permitido para o campo Descrição é de 500 caracteres");
        }

        [Fact(DisplayName = "1 - Validando exceção quando o campo conteúdo está nulo")]
        [Trait("Categoria", "Validando Noticia Model - Conteúdo")]
        public void ValidateModel_ShouldReturnException_WhenConteudoIsNull()
        {
            // Arrange
            var noticia = _fixture.GerarNoticiaConteudoNulo();

            // Act
            var result = _fixture.ValidarModelo(noticia);

            // Assert
            Assert.Contains(result, x => x.ErrorMessage == "O valor do campo Conteúdo não pode ser nulo");
        }

        [Fact(DisplayName = "1 - Validando exceção quando o campo autor está nulo")]
        [Trait("Categoria", "Validando Noticia Model - Autor")]
        public void ValidateModel_ShouldReturnException_WhenAutorIsNull()
        {
            // Arrange
            var noticia = _fixture.GerarNoticiaAutorNulo();

            // Act
            var result = _fixture.ValidarModelo(noticia);

            // Assert
            Assert.Contains(result, x => x.ErrorMessage == "O valor do campo Autor não pode ser nulo");
        }

        [Fact(DisplayName = "2 - Validando exceção quando o campo autor for maior que 255 caracteres")]
        [Trait("Categoria", "Validando Noticia Model - Autor")]
        public void ValidateModel_ShouldReturnException_WhenAutorLengthIsHigherThan255Chars()
        {
            // Arrange
            var noticia = _fixture.GerarNoticiaAutorMaior255Caracteres();

            // Act
            var result = _fixture.ValidarModelo(noticia);

            // Assert
            Assert.Contains(result, x => x.ErrorMessage == "O valor máximo permitido para o campo Autor é de 255 caracteres");
        }
    }
}
