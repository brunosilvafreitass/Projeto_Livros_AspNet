using Livros.Models;

namespace Livros.Data
{
    public class AppDBInicializer
    {
        public static void Seed(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<Context>();
                context.Database.EnsureCreated();

                //Criar Livros se estiver vazias
                if(!context.Livros.Any())
                {
                    context.Livros.AddRange(new List<LivrosModel>()
                    {
                        new LivrosModel()
                        {
                            TituloLivro = "Harry Potter e a Pedra Filosofal",
                            AnoPublicacaoLivro = new DateTime(1997,07,26)
                            
                        },
                        new LivrosModel()
                        {
                            TituloLivro = "The Hobbit",
                            AnoPublicacaoLivro = new DateTime(1937,09,21)

                        },
                        new LivrosModel()
                        {
                            TituloLivro = "The Chronicles of Narnia",
                            AnoPublicacaoLivro = new DateTime(1950,01,01)

                        },
                        new LivrosModel()
                        {
                            TituloLivro = "Livro 1",
                            AnoPublicacaoLivro = new DateTime(2000,01,01)

                        },

                        new LivrosModel()
                        {
                            TituloLivro = "Livro 2",
                            AnoPublicacaoLivro = new DateTime(2002,01,01)

                        }


                    });
                    context.SaveChanges();
                }
                //Criar Autor se estiver vazias
                if (!context.Autores.Any())
                {
                    context.Autores.AddRange(new List<AutoresModel>()
                    {
                        new AutoresModel()
                        {
                            NomeAutor = "J. K. Rowling",
                            NacionalidadeAutor = "Britânica"
                        },
                        new AutoresModel()
                        {
                            NomeAutor = "J. R. R. Tolkien",
                            NacionalidadeAutor = "Britânica"
                        },
                        new AutoresModel()
                        {
                            NomeAutor = "C. S. Lewis",
                            NacionalidadeAutor = "Britânica"
                        },
                        new AutoresModel()
                        {
                            NomeAutor = "Fernando",
                            NacionalidadeAutor = "Japonês"
                        },
                        new AutoresModel()
                        {
                            NomeAutor = "Japa",
                            NacionalidadeAutor = "Tailandês"
                        }

                    });
                    context.SaveChanges();
                }
                //Criar Editora se estiver vazias
                if (!context.Editoras.Any())
                {
                    context.Editoras.AddRange(new List<EditorasModel>()
                    {
                        new EditorasModel()
                        {
                            NomeEditora = "Bloomsbury Publishing Plc",
                            LocalizacaoEditora = "Londres, Inglaterra"
                        },
                        new EditorasModel()
                        {
                            NomeEditora = "George Allen & Unwin",
                            LocalizacaoEditora = "Crows Nest, Austrália"
                        },
                        new EditorasModel()
                        {
                            NomeEditora = "HarperCollins",
                            LocalizacaoEditora = "Nova Iorque, Nova York, EUA"
                        },
                        new EditorasModel()
                        {
                            NomeEditora = "Linux Corp",
                            LocalizacaoEditora = "Tóquio, Japão"
                        },
                        new EditorasModel()
                        {
                            NomeEditora = "Tá Voando",
                            LocalizacaoEditora = "Bangkok, Tailândia "
                        }
                    });
                    context.SaveChanges();
                }

                //Criar Livro,Editora,Autor se estiver vazias
                if (!context.LivrosAutoresEditoras.Any())
                {
                    context.LivrosAutoresEditoras.AddRange(new List<LivroAutorEditoraModel>()
                    {
                        new LivroAutorEditoraModel()
                        {
                            fk_LivrosID = 1,
                            fk_AutorID = 1,
                            fk_EditoraID = 1
                        },
                        new LivroAutorEditoraModel()
                        {
                            fk_LivrosID = 2,
                            fk_AutorID = 2,
                            fk_EditoraID = 2
                        },
                        new LivroAutorEditoraModel()
                        {
                            fk_LivrosID = 3,
                            fk_AutorID = 3,
                            fk_EditoraID = 3
                        },
                        new LivroAutorEditoraModel()
                        {
                            fk_LivrosID = 4,
                            fk_AutorID = 4,
                            fk_EditoraID = 4
                        },
                        new LivroAutorEditoraModel()
                        {
                            fk_LivrosID = 5,
                            fk_AutorID = 5,
                            fk_EditoraID = 5
                        }
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
