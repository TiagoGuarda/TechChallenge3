using System.ComponentModel.DataAnnotations;

namespace Blog.API.Data.Models
{
    public class Noticia
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O valor do campo Título não pode ser nulo")]
        [StringLength(255, ErrorMessage = "O valor máximo permitido para o campo Título é de 255 caracteres")]
        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O valor do campo Descrição não pode ser nulo")]
        [StringLength(500, ErrorMessage = "O valor máximo permitido para o campo Descrição é de 500 caracteres")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O valor do campo Conteúdo não pode ser nulo")]
        [Display(Name = "Conteúdo")]
        public string Conteudo { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O valor do campo Autor não pode ser nulo")]
        [StringLength(255, ErrorMessage = "O valor máximo permitido para o campo Autor é de 255 caracteres")]
        public string Autor { get; set; }

        [Display(Name = "Data da Publicação")]
        public DateTime DataPublicacao { get; set; }

        [Display(Name = "Data da Atualização")]
        public DateTime DataAtualizacao { get; set; }
    }
}