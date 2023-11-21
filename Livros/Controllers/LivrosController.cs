using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Livros.Data;
using Livros.Models;

namespace Livros.Controllers
{
    public class LivrosController : Controller
    {
        private readonly Context _context;

        public LivrosController(Context context)
        {
            _context = context;
        }

        // GET: Livros
        public async Task<IActionResult> Index()
        {
            return View(await _context.Livros.OrderBy(c => c.TituloLivro).ToListAsync());
                         
        }

        // GET: Livros/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livrosModel = await _context.Livros.SingleOrDefaultAsync(m => m.IdLivro == id);

            if (livrosModel == null)
            {
                return NotFound();
            }

            return View(livrosModel);
        }

        // GET: Livros/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Livros/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LivrosModel livrosModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(livrosModel);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {

                ModelState.AddModelError("Erro", "Nao foi possivel inserir os dados.");
            }

            return View(livrosModel);
        }

        // GET: Livros/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livrosModel = await _context.Livros.SingleOrDefaultAsync(m => m.IdLivro == id);
            if (livrosModel == null)
            {
                return NotFound();
            }
            return View(livrosModel);
        }

        // POST: Livros/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, LivrosModel livrosModel)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(livrosModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LivrosModelExists(livrosModel.IdLivro))
                    {
                        return NotFound();
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(livrosModel);
        }

        // GET: Livros/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livrosModel = await _context.Livros
                .SingleOrDefaultAsync(m => m.IdLivro == id);
            if (livrosModel == null)
            {
                return NotFound();
            }

            //com o id da instuicao pesquina no departamento se tem alguma fk carrega
            var fkTrue = await _context.LivrosAutoresEditoras.AnyAsync(d => d.fk_LivrosID == id);

            if (fkTrue)
            {
                TempData["erro"] = $"Não podemos apaga o Livro:{livrosModel.TituloLivro.ToUpper()} porque estar relacionado a {_context.LivrosAutoresEditoras.Count(d => d.fk_LivrosID == id)} Autores(s)";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(livrosModel);

            }

        }

        // POST: Livros/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var livrosModel = await _context.Livros.SingleOrDefaultAsync(m => m.IdLivro == id);
            if (livrosModel != null)
            {
                _context.Livros.Remove(livrosModel);
            }
            await _context.SaveChangesAsync();

            TempData["Message"] = $"Livro {livrosModel?.TituloLivro.ToUpper()} foi removido";

            return RedirectToAction(nameof(Index));
        }

        private bool LivrosModelExists(int? id)
        {
          return _context.Livros.Any(e => e.IdLivro == id);
        }
    }
}
