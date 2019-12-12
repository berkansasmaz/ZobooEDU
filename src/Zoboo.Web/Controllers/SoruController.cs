using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Zoboo.Entity;

namespace Zoboo.Web.Controllers
{
    public class SoruController : Controller
    {
        private readonly ZBDBContext _context;

        public SoruController(ZBDBContext context)
        {
            _context = context;
        }

        // GET: Soru
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sorular.ToListAsync());
        }

        // GET: Soru/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var soru = await _context.Sorular
                .FirstOrDefaultAsync(m => m.SoruId == id);
            if (soru == null)
            {
                return NotFound();
            }

            return View(soru);
        }

        // GET: Soru/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Soru/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SoruId,Konu,SoruResimYolu,SoruMetni,isDogruMu")] Soru soru)
        {
            if (ModelState.IsValid)
            {
                soru.SoruId = Guid.NewGuid();
                _context.Add(soru);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(soru);
        }

        // GET: Soru/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var soru = await _context.Sorular.FindAsync(id);
            if (soru == null)
            {
                return NotFound();
            }
            return View(soru);
        }

        // POST: Soru/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("SoruId,Konu,SoruResimYolu,SoruMetni,isDogruMu")] Soru soru)
        {
            if (id != soru.SoruId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(soru);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SoruExists(soru.SoruId))
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
            return View(soru);
        }

        // GET: Soru/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var soru = await _context.Sorular
                .FirstOrDefaultAsync(m => m.SoruId == id);
            if (soru == null)
            {
                return NotFound();
            }

            return View(soru);
        }

        // POST: Soru/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var soru = await _context.Sorular.FindAsync(id);
            _context.Sorular.Remove(soru);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SoruExists(Guid id)
        {
            return _context.Sorular.Any(e => e.SoruId == id);
        }
    }
}
