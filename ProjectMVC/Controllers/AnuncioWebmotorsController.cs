using System;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectMVC.Data.Context;
using ProjectMVC.Models;
using X.PagedList;
using System.Text.RegularExpressions;

namespace ProjectMVC.Controllers
{
    public class AnuncioWebmotorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AnuncioWebmotorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AnuncioWebmotors
        public async Task<IActionResult> Index(string marca, string modelo, string versao, int pag = 1)
        {
            var db = _context.AnuncioWebmotors.AsNoTracking();

            if (!string.IsNullOrEmpty(marca))
            { db = db.Where(c => c.marca == marca); }

            if (!string.IsNullOrEmpty(modelo))
            { db = db.Where(c => c.modelo == modelo); }

            if (!string.IsNullOrEmpty(versao))
            { db = db.Where(c => c.versao == versao); }

            return View(await db?.OrderBy(am => am.ID).ToPagedListAsync(pag, 10));
        }

        // GET: AnuncioWebmotors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anuncioWebmotors = await _context.AnuncioWebmotors
                .FirstOrDefaultAsync(m => m.ID == id);
            if (anuncioWebmotors == null)
            {
                return NotFound();
            }

            return View(anuncioWebmotors);
        }

        // GET: AnuncioWebmotors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AnuncioWebmotors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,marca,modelo,versao,ano,quilometragem,observacao")] AnuncioWebmotors anuncioWebmotors)
        {
            if (ModelState.IsValid)
            {
                _context.Add(anuncioWebmotors);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(anuncioWebmotors);
        }

        // GET: AnuncioWebmotors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anuncioWebmotors = await _context.AnuncioWebmotors.FindAsync(id);
            if (anuncioWebmotors == null)
            {
                return NotFound();
            }
            return View(anuncioWebmotors);
        }

        // POST: AnuncioWebmotors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,marca,modelo,versao,ano,quilometragem,observacao")] AnuncioWebmotors anuncioWebmotors)
        {
            if (id != anuncioWebmotors.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(anuncioWebmotors);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnuncioWebmotorsExists(anuncioWebmotors.ID))
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
            return View(anuncioWebmotors);
        }

        // GET: AnuncioWebmotors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anuncioWebmotors = await _context.AnuncioWebmotors
                .FirstOrDefaultAsync(m => m.ID == id);
            if (anuncioWebmotors == null)
            {
                return NotFound();
            }

            return View(anuncioWebmotors);
        }

        // POST: AnuncioWebmotors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var anuncioWebmotors = await _context.AnuncioWebmotors.FindAsync(id);
            _context.AnuncioWebmotors.Remove(anuncioWebmotors);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnuncioWebmotorsExists(int id)
        {
            return _context.AnuncioWebmotors.Any(e => e.ID == id);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
