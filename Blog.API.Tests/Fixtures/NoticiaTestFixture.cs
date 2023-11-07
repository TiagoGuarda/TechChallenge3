using Blog.API.Data.Interfaces;
using Blog.API.Data.Models;
using Blog.API.Data.Services;
using Bogus;
using Moq;
using System.ComponentModel.DataAnnotations;


namespace Blog.API.Tests.Fixtures
{
    public class NoticiaTestFixture
    {
        private IList<Noticia> _noticias;
        private readonly INoticiaService _service;
        private readonly Faker _faker;
        private const string CULTURE_CODE = "pt_BR";

        public INoticiaService NoticiaService { get { return _service; } }

        public NoticiaTestFixture()
        {
            _noticias = new List<Noticia>();
            _service = GetNoticiaService();
            _faker = new Faker(CULTURE_CODE);
        }

        #region Public Methods

        public IEnumerable<Noticia> GerarNoticias(int numeroDeNoticias = 5)
        {
            //Gerando noticias aleatorias
            var noticiaFaker = new Faker<Noticia>(CULTURE_CODE)
                .RuleFor(n => n.Id, f => f.IndexFaker)
                .RuleFor(n => n.Titulo, f => f.Lorem.Sentence(1, 4))
                .RuleFor(n => n.Descricao, f => f.Lorem.Sentence(10, 5))
                .RuleFor(n => n.Conteudo, f => f.Lorem.Sentence(20, 10))
                .RuleFor(n => n.DataPublicacao, f => f.Date.Recent(1000, new DateTime(2021, 01, 01)))
                .RuleFor(n => n.Autor, f => f.Name.FullName())
                .RuleFor(n => n.DataAtualizacao, f => f.Date.Recent(100));

            return noticiaFaker.Generate(numeroDeNoticias);
        }

        public Noticia GerarNoticia()
        {
            return GerarNoticias(1).First();
        }

        public Noticia GerarNoticiaTituloNulo()
        {
            var noticia = GerarNoticia();
            noticia.Titulo = null;
            return noticia;
        }

        public Noticia GerarNoticiaTituloMaior255Caracteres()
        {
            var noticia = GerarNoticia();
            noticia.Titulo = _faker.Random.String2(256);
            return noticia;
        }

        public Noticia GerarNoticiaDescricaoNula()
        {
            var noticia = GerarNoticia();
            noticia.Descricao = null;
            return noticia;
        }

        public Noticia GerarNoticiaDescricaoMaior500Caracteres()
        {
            var noticia = GerarNoticia();
            noticia.Descricao = _faker.Random.String2(501);
            return noticia;
        }

        public Noticia GerarNoticiaConteudoNulo()
        {
            var noticia = GerarNoticia();
            noticia.Conteudo = null;
            return noticia;
        }

        public Noticia GerarNoticiaAutorNulo()
        {
            var noticia = GerarNoticia();
            noticia.Autor = null;
            return noticia;
        }

        public Noticia GerarNoticiaAutorMaior255Caracteres()
        {
            var noticia = GerarNoticia();
            noticia.Autor = _faker.Random.String2(256);
            return noticia;
        }

        public IList<System.ComponentModel.DataAnnotations.ValidationResult> ValidarModelo(object modelo)
        {
            var result = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
            var context = new ValidationContext(modelo, null, null);
            Validator.TryValidateObject(modelo, context, result, true);
            return result;
        }

        #endregion

        private INoticiaService GetNoticiaService()
        {
            //Mock NoticiaRepository
            Mock<INoticiaRepository> mock = new Mock<INoticiaRepository>();

            //ObterTodas
            mock.Setup(x => x.ObterTodas()).ReturnsAsync(_noticias);

            //ObterPorId
            mock.Setup(x => x.ObterPorId(It.IsAny<int>())).ReturnsAsync((int id) => _noticias.FirstOrDefault(x => x.Id == id));

            //Adicionar
            mock.Setup(x => x.Adicionar(It.IsAny<Noticia>())).ReturnsAsync((Noticia noticia) => {
                noticia.Id = _noticias.Count > 0 ? _noticias.Max(n => n.Id) + 1 : 1;
                _noticias.Add(noticia);
                return 1;
            });

            //Atualizar
            mock.Setup(x => x.Atualizar(It.IsAny<Noticia>())).ReturnsAsync((Noticia noticia) => {
                var item = _noticias.FirstOrDefault(n => n.Id == noticia.Id);

                if (item != null)
                {
                    item = noticia;
                    return 1;
                }

                return 0;
            });

            //Remover
            mock.Setup(x => x.Remover(It.IsAny<int>())).ReturnsAsync((int id) => {
                var noticia = _noticias.FirstOrDefault(n => n.Id == id);
                
                if (noticia != null)
                {
                    if (_noticias.Remove(noticia))
                        return 1;
                }

                return 0;
            });

            return new NoticiaService(mock.Object);
        }

        
    }
}
