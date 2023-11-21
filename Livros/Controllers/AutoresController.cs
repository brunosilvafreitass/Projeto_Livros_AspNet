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
    public class AutoresController : Controller
    {
        private readonly Context _context;

        public AutoresController(Context context)
        {
            _context = context;
        }

        // GET: Autores
        public async Task<IActionResult> Index()
        {
            return View(await _context.Autores.OrderBy(a => a.NomeAutor).ToListAsync());
        }

        // GET: Autores/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autoresModel = await _context.Autores.SingleOrDefaultAsync(m => m.IdAutor == id);
            if (autoresModel == null)
            {
                return NotFound();
            }

            return View(autoresModel);
        }

        // GET: Autores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Autores/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AutoresModel autoresModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(autoresModel);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("Erro", "Nao foi possivel inserir os dados.");
            }

            return View(autoresModel);
        }

        // GET: Autores/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autoresModel = await _context.Autores.SingleOrDefaultAsync(a => a.IdAutor == id);
            if (autoresModel == null)
            {
                return NotFound();
            }
            return View(autoresModel);
        }

        // POST: Autores/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id,  AutoresModel autoresModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(autoresModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutoresModelExists(autoresModel.IdAutor))
                    {
                        return NotFound();
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(autoresModel);
        }

        // GET: Autores/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autoresModel = await _context.Autores
                .SingleOrDefaultAsync(m => m.IdAutor == id);
            if (autoresModel == null)
            {
                return NotFound();
            }

            
            var fkTrue = await _context.LivrosAutoresEditoras.AnyAsync(d => d.fk_AutorID == id);

            if (fkTrue)
            {
                TempData["erro"] = $"Não podemos apaga o Autor:{autoresModel.NomeAutor.ToUpper()} porque estar relacionado a {_context.LivrosAutoresEditoras.Count(d => d.fk_AutorID == id)} Autores(s)";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(autoresModel);
            }

        }

        // POST: Autores/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var autoresModel = await _context.Autores.FindAsync(id);
            if (autoresModel != null)
            {
                _context.Autores.Remove(autoresModel);
            }
            
            await _context.SaveChangesAsync();
            TempData["Message"] = $"Livro {autoresModel?.NomeAutor.ToUpper()} foi removido";

            return RedirectToAction(nameof(Index));
        }

        private bool AutoresModelExists(int? id)
        {
          return _context.Autores.Any(e => e.IdAutor == id);
        }
    }
}
