using Blog.API.Data.Context;
using Blog.API.Data.Interfaces;
using Blog.API.Data.Repositories;
using Blog.API.Data.Services;
using Blog.API.Gerenciamento.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;

namespace Blog.API.Tests.Fixtures
{
    public class GerenciamentoControllerTestFixture
    {
        private GerenciamentoController _controller;
        private Mock<ILogger<GerenciamentoController>> _logger;
        private INoticiaService _service;
        private INoticiaRepository _repository;
        private NoticiasContext _context;

        public GerenciamentoController GerenciamentoController { get { return _controller; } }

        public GerenciamentoControllerTestFixture()
        {
            //Server=localhost,1433;Initial Catalog=MyDb;Integrated Security=True;User Id=sa;Password=MyPass@word;
            var connectionString = @"Server=DELL\SQLEXPRESS;Initial Catalog=test;Integrated Security=True;";
            var options = new DbContextOptionsBuilder<NoticiasContext>().UseSqlServer(connectionString).Options;

            _context = new NoticiasContext(options);
            _repository = new NoticiaRepository(_context);
            _service = new NoticiaService(_repository);

            _logger = new Mock<ILogger<GerenciamentoController>>();
            _controller = new GerenciamentoController(_logger.Object, _service);

            _context.Database.ExecuteSqlRaw("IF OBJECT_ID(N'dbo.Noticia', N'U') IS NOT NULL DROP TABLE [dbo].[Noticia] \r\nCREATE TABLE [dbo].[Noticia] (\r\n\tId INT PRIMARY KEY IDENTITY, \r\n\tTitulo NVARCHAR(255) NOT NULL,\r\n\tDescricao NVARCHAR(500) NOT NULL,\r\n\tConteudo NVARCHAR(MAX) NOT NULL,\r\n\tDataPublicacao DATETIME NOT NULL,\r\n\tAutor NVARCHAR(255) NOT NULL,\r\n\tDataAtualizacao DATETIME NOT NULL\r\n);");
        }
    }
}
