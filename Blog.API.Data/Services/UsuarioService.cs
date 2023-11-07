using Blog.API.Data.Interfaces;
using Blog.API.Data.Models;
using Blog.API.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.API.Data.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public Usuario? Obter(string nome, string senha)
        {
            return _usuarioRepository.Obter(nome, senha);
        }
    }
}
