using Livros.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Livros.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        public DbSet<LivrosModel> Livros { get; set; }
        public DbSet<EditorasModel> Editoras { get; set; }
        public DbSet<AutoresModel> Autores { get; set; }
        public DbSet<LivroAutorEditoraModel> LivrosAutoresEditoras { get; set; }
    }
}
