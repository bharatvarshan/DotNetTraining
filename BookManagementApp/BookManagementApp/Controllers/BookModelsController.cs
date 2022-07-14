using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookManagementApp.Models;

namespace BookManagementApp.Controllers
{
    public class BookModelsController : Controller
    {
        private readonly BookDBContext _context;

        public BookModelsController(BookDBContext context)
        {
            _context = context;
        }

        // GET: BookModels
        public async Task<IActionResult> Index()
        {
              return _context.BookDB != null ? 
                          View(await _context.BookDB.ToListAsync()) :
                          Problem("Entity set 'BookDBContext.BookDB'  is null.");
        }

        // GET: BookModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BookDB == null)
            {
                return NotFound();
            }

            var bookModel = await _context.BookDB
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (bookModel == null)
            {
                return NotFound();
            }

            return View(bookModel);
        }

        // GET: BookModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BookModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookId,BookName,Author,Price")] BookModel bookModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookModel);
        }

        // GET: BookModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BookDB == null)
            {
                return NotFound();
            }

            var bookModel = await _context.BookDB.FindAsync(id);
            if (bookModel == null)
            {
                return NotFound();
            }
            return View(bookModel);
        }

        // POST: BookModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookId,BookName,Author,Price")] BookModel bookModel)
        {
            if (id != bookModel.BookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookModelExists(bookModel.BookId))
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
            return View(bookModel);
        }

        // GET: BookModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BookDB == null)
            {
                return NotFound();
            }

            var bookModel = await _context.BookDB
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (bookModel == null)
            {
                return NotFound();
            }

            return View(bookModel);
        }

        // POST: BookModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BookDB == null)
            {
                return Problem("Entity set 'BookDBContext.BookDB'  is null.");
            }
            var bookModel = await _context.BookDB.FindAsync(id);
            if (bookModel != null)
            {
                _context.BookDB.Remove(bookModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookModelExists(int id)
        {
          return (_context.BookDB?.Any(e => e.BookId == id)).GetValueOrDefault();
        }
    }
}
