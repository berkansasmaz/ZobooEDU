using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
		        
		     // GET: Sorus/Create
        public async Task<IActionResult> Ol()
        {
			
            return View(await _context.Sorular.ToListAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Ol(Soru soru)
        {
            if (ModelState.IsValid)
            {
              
            }
            return View(soru);
        }
    }
}