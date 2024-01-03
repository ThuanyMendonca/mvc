using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using teste.Data;
using teste.Models;

namespace teste.Controllers
{
    public class TestesController : Controller
    {
        private readonly testeContext _context;

        public TestesController(testeContext context)
        {
            _context = context;
        }

        // GET: Testes
        public async Task<IActionResult> Index(string Texto, string Genero)
        {           
            // query genero
            IQueryable<string> generos = from m in _context.Teste
                                         orderby m.Genero
                                         select m.Genero;
            
            // query filme
            var filmes = from m in _context.Teste
                         select m;

            // filtro filme
            if (!String.IsNullOrWhiteSpace(Texto))
            {
                
                filmes = filmes.Where(s => s.Titulo!.Contains(Texto));
            }

            // filtro genero
            if(!string.IsNullOrWhiteSpace(Genero))
            {
                filmes = filmes.Where(s => s.Genero == Genero);
            }

            // ViewModel
            var testeViewModel = new Models.TestesViewModel
            {
                Testes = await filmes.ToListAsync(),
                Generos = new SelectList(await generos.Distinct().ToListAsync())
            };

            return _context.Teste != null ? 
                          View(testeViewModel) :
                          Problem("Entity set 'testeContext.Teste'  is null.");
        }

        // GET: Testes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Teste == null)
            {
                return NotFound();
            }

            var teste = await _context.Teste
                .FirstOrDefaultAsync(m => m.ID == id);
            if (teste == null)
            {
                return NotFound();
            }

            return View(teste);
        }

        // GET: Testes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Testes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Titulo,DataLancamento,Genero,Preco,Pontos")] Teste teste)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teste);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(teste);
        }

        // GET: Testes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Teste == null)
            {
                return NotFound();
            }

            var teste = await _context.Teste.FindAsync(id);
            if (teste == null)
            {
                return NotFound();
            }
            return View(teste);
        }

        // POST: Testes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Titulo,DataLancamento,Genero,Preco,Pontos")] Teste teste)
        {
            if (id != teste.ID)
            {
                return NotFound();
            }
            
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teste);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TesteExists(teste.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(teste);
        }

        // GET: Testes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Teste == null)
            {
                return NotFound();
            }

            var teste = await _context.Teste
                .FirstOrDefaultAsync(m => m.ID == id);
            if (teste == null)
            {
                return NotFound();
            }

            return View(teste);
        }

        // POST: Testes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Teste == null)
            {
                return Problem("Entity set 'testeContext.Teste'  is null.");
            }
            var teste = await _context.Teste.FindAsync(id);
            if (teste != null)
            {
                _context.Teste.Remove(teste);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TesteExists(int id)
        {
          return (_context.Teste?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
