using Blog.API.Data.Context;
using Blog.API.Data.Interfaces;
using Blog.API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.API.Data.Repositories
{
    public class NoticiaRepository : INoticiaRepository
    {
        protected readonly NoticiasContext _db;
        protected readonly DbSet<Noticia> _dbSet;

        public NoticiaRepository(NoticiasContext context)
        {
            _db = context;
            _dbSet = _db.Set<Noticia>();
        }

        public async Task<IEnumerable<Noticia>> ObterTodas()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<Noticia?> ObterPorId(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<int> Adicionar(Noticia noticia)
        {
            _dbSet.Add(noticia);
            return await SaveChanges();
        }

        public async Task<int> Atualizar(Noticia noticia)
        {
            _dbSet.Update(noticia);
            return await SaveChanges();
        }

        public async Task<int> Remover(int id)
        {
            _dbSet.Remove(new Noticia { Id = id });
            return await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await _db.SaveChangesAsync();
        }

        public void Dispose()
        {
            _db?.Dispose();
        }
    }
}
