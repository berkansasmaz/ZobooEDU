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
    public class TestController : Controller
    {
        private readonly ZBDBContext _context;

        public TestController(ZBDBContext context)
        {
            _context = context;
        }

        // GET: Test
        public async Task<IActionResult> Index()
        {
            return View(await _context.Testler.ToListAsync());
        }

        // GET: Test/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var test = await _context.Testler
                .FirstOrDefaultAsync(m => m.TestId == id);
            if (test == null)
            {
                return NotFound();
            }

            return View(test);
        }

        // GET: Test/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Test/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TestId,UserId,SonQuizTarihi,DogruSayisi,YanlisSayisi,Zaman,BasariOrani")] Test test)
        {
            if (ModelState.IsValid)
            {
                test.TestId = Guid.NewGuid();
                _context.Add(test);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(test);
        }

        // GET: Test/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var test = await _context.Testler.FindAsync(id);
            if (test == null)
            {
                return NotFound();
            }
            return View(test);
        }

        // POST: Test/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("TestId,UserId,SonQuizTarihi,DogruSayisi,YanlisSayisi,Zaman,BasariOrani")] Test test)
        {
            if (id != test.TestId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(test);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestExists(test.TestId))
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
            return View(test);
        }

        // GET: Test/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var test = await _context.Testler
                .FirstOrDefaultAsync(m => m.TestId == id);
            if (test == null)
            {
                return NotFound();
            }

            return View(test);
        }

        // POST: Test/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var test = await _context.Testler.FindAsync(id);
            _context.Testler.Remove(test);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TestExists(Guid id)
        {
            return _context.Testler.Any(e => e.TestId == id);
        }
    }
}
