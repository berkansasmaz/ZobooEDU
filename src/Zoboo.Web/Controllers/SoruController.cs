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

        // GET: Sorus
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sorular.ToListAsync());
        }

        // GET: Sorus/Create
        public IActionResult Ekle()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Ekle(Soru soru)
        {
            if (ModelState.IsValid)
            {
                soru.isDogruMu = false;
                soru.Cevap.CevapId = Guid.NewGuid();
                soru.SoruId = Guid.NewGuid();
                _context.Add(soru);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(soru);
        }

    }
}
