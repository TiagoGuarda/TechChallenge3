using Blog.API.Data.Interfaces;
using Blog.API.Data.Models;
using Blog.API.Data.Repositories;

namespace Blog.API.Data.Services
{
    public class NoticiaService : INoticiaService
    {
        protected readonly INoticiaRepository _repository;

        public NoticiaService(INoticiaRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Noticia>> ObterTodas()
        {
            return _repository.ObterTodas();
        }

        public Task<Noticia?> ObterPorId(int id)
        {
            return _repository.ObterPorId(id);
        }

        public Task<int> Adicionar(Noticia noticia) 
        {
            return _repository.Adicionar(noticia);
        }

        public Task<int> Atualizar(Noticia noticia) 
        { 
            return _repository.Atualizar(noticia);
        }

        public Task<int> Remover(int id) 
        { 
            return _repository.Remover(id);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
