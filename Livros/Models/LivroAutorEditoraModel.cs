using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Livros.Models
{
    public class LivroAutorEditoraModel
    {
        [Key]
        public int IdLivroAutorEditora { get; set; }
        [Required(ErrorMessage = "Obrigatório")]
        [ForeignKey("Livros")]
        public int? fk_LivrosID { get; set; }
        public LivrosModel? Livros { get; set; }

        [Required(ErrorMessage = "Obrigatório")]
        [ForeignKey("Autores")]
        public int? fk_AutorID { get; set; }
        public AutoresModel? Autores { get; set; }

        [Required(ErrorMessage = "Obrigatório")]
        [ForeignKey("Editoras")]
        public int? fk_EditoraID { get; set; }
        public  EditorasModel? Editoras { get; set; }
    }
}
