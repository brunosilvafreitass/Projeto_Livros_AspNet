using System.ComponentModel.DataAnnotations;

namespace Livros.Models
{
    public class LivrosModel
    {
        [Key]
        public int? IdLivro { get; set; }
        [Required(ErrorMessage = "Obrigatorio")]
        public string TituloLivro { get; set; }
        [Required(ErrorMessage = "Obrigatorio")]
        public DateTime AnoPublicacaoLivro { get; set; }

        public IList<LivroAutorEditoraModel>? AutorEditors { get; set; }
    }
}
