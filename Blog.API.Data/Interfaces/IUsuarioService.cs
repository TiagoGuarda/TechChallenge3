using Blog.API.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.API.Data.Interfaces
{
    public interface IUsuarioService
    {
        Usuario? Obter(string nome, string senha);
    }
}
