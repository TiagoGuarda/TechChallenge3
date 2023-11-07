using Blog.API.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.API.Data.Interfaces
{
    public interface INoticiaRepository
    {
        Task<IEnumerable<Noticia>> ObterTodas();

        Task<Noticia?> ObterPorId(int id);

        Task<int> Adicionar(Noticia noticia);

        Task<int> Atualizar(Noticia noticia);

        Task<int> Remover(int id);

        void Dispose();
    }
}
