using System.ComponentModel.DataAnnotations;

namespace Livros.Models
{
    public class EditorasModel
    {
        [Key]
        public int? IdEditora { get; set; }
        [Required(ErrorMessage = "Obrigatorio")]
        public string NomeEditora { get; set; }
        [Required(ErrorMessage = "Obrigatorio")]
        public string LocalizacaoEditora { get; set; }

        public IList<LivroAutorEditoraModel>? AutorEditors { get; set; }

    }
}
