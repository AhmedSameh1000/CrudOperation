using Blog.Data;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stor.Models;

namespace Stor.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly Context _context;

        public CategoriesController(Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.categories.OrderByDescending(x => x.Id).ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            var category = await _context.categories
                .FirstOrDefaultAsync(m => m.Id == id);
            return View(category);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] Category category)
        {
            _context.Add(category);
            await _context.SaveChangesAsync();
            return View(category);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            var categorys = await _context.categories.FindAsync(id);
            if (categorys == null)
            {
                return NotFound();
            }
            return View(categorys);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([Bind("Id,Name,Description")] Category category)
        {
            _context.Update(category);
            await _context.SaveChangesAsync();
            return View(category);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var categorys = await _context.categories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categorys == null)
            {
                return NotFound();
            }
            return View(categorys);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _context.categories.FindAsync(id);
            _context.categories.Remove(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}