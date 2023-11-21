using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Livros.Data;
using Livros.Models;

namespace Livros.Controllers
{
    public class EditorasController : Controller
    {
        private readonly Context _context;

        public EditorasController(Context context)
        {
            _context = context;
        }

        // GET: Editoras
        public async Task<IActionResult> Index()
        {
            return View(await _context.Editoras.OrderBy(e => e.NomeEditora).ToListAsync());
        }

        // GET: Editoras/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var editorasModel = await _context.Editoras.SingleOrDefaultAsync(m => m.IdEditora == id);
            if (editorasModel == null)
            {
                return NotFound();
            }

            return View(editorasModel);
        }

        // GET: Editoras/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Editoras/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EditorasModel editorasModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(editorasModel);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception)
            {

                ModelState.AddModelError("Erro", "Nao foi possivel inserir os dados.");
            }

            return View(editorasModel);
        }

        // GET: Editoras/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var editorasModel = await _context.Editoras.SingleOrDefaultAsync(e => e.IdEditora == id);
            if (editorasModel == null)
            {
                return NotFound();
            }
            return View(editorasModel);
        }

        // POST: Editoras/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, EditorasModel editorasModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(editorasModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EditorasModelExists(editorasModel.IdEditora))
                    {
                        return NotFound();
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(editorasModel);
        }

        // GET: Editoras/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var editorasModel = await _context.Editoras
                .SingleOrDefaultAsync(m => m.IdEditora == id);
            if (editorasModel == null)
            {
                return NotFound();
            }

            var fkTrue = await _context.LivrosAutoresEditoras.AnyAsync(d => d.fk_EditoraID == id);

            if (fkTrue)
            {
                TempData["erro"] = $"Não podemos apaga o Editora:{editorasModel.NomeEditora.ToUpper()} porque estar relacionado a {_context.LivrosAutoresEditoras.Count(d => d.fk_EditoraID == id)} Editora(s)";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(editorasModel);

            }

        }

        // POST: Editoras/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_context.Editoras == null)
            {
                return Problem("Entity set 'Context.Editoras'  is null.");
            }
            var editorasModel = await _context.Editoras.FindAsync(id);
            if (editorasModel != null)
            {
                _context.Editoras.Remove(editorasModel);
            }
            
            await _context.SaveChangesAsync();
            TempData["Message"] = $"Editora {editorasModel?.NomeEditora.ToUpper()} foi removido";

            return RedirectToAction(nameof(Index));
        }

        private bool EditorasModelExists(int? id)
        {
          return _context.Editoras.Any(e => e.IdEditora == id);
        }
    }
}
