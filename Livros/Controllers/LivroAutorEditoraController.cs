using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Livros.Data;
using Livros.Models;

namespace Livros.Controllers
{
    public class LivroAutorEditoraController : Controller
    {
        private readonly Context _context;

        public LivroAutorEditoraController(Context context)
        {
            _context = context;
        }

        // GET: LivroAutorEditora
        public async Task<IActionResult> Index()
        {
            return View(await _context.LivrosAutoresEditoras
                                      .Include(l => l.Livros)
                                      .Include(a => a.Autores)
                                      .Include(e => e.Editoras)
                                      .OrderBy(t => t.Livros.TituloLivro)
                                      .ToListAsync());
        }

        // GET: LivroAutorEditora/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livroAutorEditoraModel = await _context.LivrosAutoresEditoras
                                                       .Include(l => l.Livros)
                                                       .Include(a => a.Autores)
                                                       .Include(e => e.Editoras)
                                                       .SingleOrDefaultAsync(m => m.IdLivroAutorEditora == id);
            if (livroAutorEditoraModel == null)
            {
                return NotFound();
            }

            return View(livroAutorEditoraModel);
        }

        // GET: LivroAutorEditora/Create
        public IActionResult Create()
        {

            var livros = _context.Livros.OrderBy(l => l.TituloLivro).ToList();
            livros.Insert(0, new LivrosModel()
            {
                IdLivro = null,
                TituloLivro = "Selecione o livro"
            });
            ViewBag.Livros = livros;

            var autores = _context.Autores.OrderBy(a => a.NomeAutor).ToList();
            autores.Insert(0, new AutoresModel()
            {
                IdAutor = null,
                NomeAutor = "Selecione o Autor"
            });
            ViewBag.Autores = autores;

            var editoras = _context.Editoras.OrderBy(a => a.NomeEditora).ToList();
            editoras.Insert(0, new EditorasModel()
            {
                IdEditora = null,
                NomeEditora = "Selecione o Editora"
            });
            ViewBag.Editoras = editoras;

            return View();
        }
        // POST: LivroAutorEditora/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LivroAutorEditoraModel livroautoreditoramodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(livroautoreditoramodel);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {

                ModelState.AddModelError("Erro", "Nao foi possivel inserir os dados.");
            }

            //var livros = _context.Livros.OrderBy(l => l.TituloLivro).ToList();
            //livros.Insert(0, new LivrosModel()
            //{
            //    IdLivro = null,
            //    TituloLivro = "Selecione o livro"
            //});
            //ViewBag.Livros = livros;

            //var autores = _context.Autores.OrderBy(a => a.NomeAutor).ToList();
            //autores.Insert(0, new AutoresModel()
            //{
            //    IdAutor = null,
            //    NomeAutor = "Selecione o Autor"
            //});
            //ViewBag.Autores = autores;

            return View(livroautoreditoramodel);
        }
        // GET: LivroAutorEditora/Edit
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livroautoreditora = await _context.LivrosAutoresEditoras.SingleOrDefaultAsync(m => m.IdLivroAutorEditora == id);

            if (livroautoreditora == null)
            {
                return NotFound();
            }

            ViewBag.Livros = new SelectList(_context.Livros.OrderBy(b => b.TituloLivro),"IdLivro", "TituloLivro", livroautoreditora.fk_LivrosID);

            ViewBag.Autores = new SelectList(_context.Autores.OrderBy(b => b.NomeAutor),"IdAutor", "NomeAutor", livroautoreditora.fk_AutorID);

            ViewBag.Editoras = new SelectList(_context.Editoras.OrderBy(b => b.NomeEditora), "IdEditora", "NomeEditora", livroautoreditora.fk_AutorID);


            return View(livroautoreditora);
        }

        // POST: LivroAutorEditora/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, LivroAutorEditoraModel livroAutorEditora)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(livroAutorEditora);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    if (!LivrosAutorEditoraModelExists(livroAutorEditora.IdLivroAutorEditora))
                    {
                        return NotFound();
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(livroAutorEditora);
        }

        // GET: Livros/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livroAutorEditora = await _context.LivrosAutoresEditoras
                                                  .Include(l => l.Livros)
                                                  .Include(a => a.Autores)
                                                  .Include(e => e.Editoras)
                                                  .SingleOrDefaultAsync(m => m.IdLivroAutorEditora == id);
            if (livroAutorEditora == null)
            {
                return NotFound();
            }

            return View(livroAutorEditora);

        }

        // POST: Livros/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var livroAutorEditora = await _context.LivrosAutoresEditoras.SingleOrDefaultAsync(m => m.IdLivroAutorEditora == id);
            if (livroAutorEditora != null)
            {
                _context.LivrosAutoresEditoras.Remove(livroAutorEditora);
            }
            await _context.SaveChangesAsync();

            TempData["Message"] = $"Registro {livroAutorEditora?.IdLivroAutorEditora} foi removido";

            return RedirectToAction(nameof(Index));
        }

        private bool LivrosAutorEditoraModelExists(int? id)
        {
            return _context.LivrosAutoresEditoras.Any(e => e.IdLivroAutorEditora == id);
        }

    }
}
