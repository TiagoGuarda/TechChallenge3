using Blog.API.Data.Interfaces;
using Blog.API.Data.Models;

namespace Blog.API.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public UsuarioRepository() { }

        public Usuario? Obter(string nome, string senha)
        {
            //Cria uma lista de usuários e adiciona um usuário Admin na lista
            var usuarios = new List<Usuario>() { new Usuario() { Id = 1, Nome = "Administrador", Senha = "Fiap@2023", Grupo = "Admin" } };
            
            //Retorna o usuário da lista caso o nome e a senha sejam válidos
            return usuarios.FirstOrDefault(u => u.Nome.ToUpper() == nome.ToUpper() && u.Senha == senha);
        }
    }
}
