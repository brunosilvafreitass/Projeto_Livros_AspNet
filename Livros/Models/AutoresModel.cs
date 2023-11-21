using System.ComponentModel.DataAnnotations;

namespace Livros.Models
{
    public class AutoresModel
    {
        [Key]
        public int? IdAutor { get; set; }
        [Required(ErrorMessage = "Obrigatorio")]
        public string NomeAutor { get; set; }
        [Required(ErrorMessage = "Obrigatorio")]
        public string NacionalidadeAutor { get; set; }

        public IList<LivroAutorEditoraModel>? AutorEditors { get; set; }

    }
}
