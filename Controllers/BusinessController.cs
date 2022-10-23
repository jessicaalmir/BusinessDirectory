using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GroupB_A2.Data;
using GroupB_A2.Models;

namespace GroupB_A2.Controllers
{
    public class BusinessController : Controller
    {
        private readonly BusinessContext _context;

        public BusinessController(BusinessContext context)
        {
            _context = context;
        }

        // GET: Business
        public async Task<IActionResult> Index()
        {
              //return _context.Business != null ? 
                          //View(await _context.Business.ToListAsync()) :
                          
                          //Problem("Entity set 'BusinessContext.Business'  is null.");
                         var businesses = _context.Business.Include(b => b.Category);
                              return View(businesses.ToList());
                          
        }

        // GET: Business/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Business == null)
            {
                return NotFound();
            }

            var business = await _context.Business
                .FirstOrDefaultAsync(m => m.ID == id);
            if (business == null)
            {
                return NotFound();
            }
            Category BusinessCategory =
                _context.Category.Where(c => c.ID == business.CategoryID).FirstOrDefault<Category>();
            business.Category = BusinessCategory;
            return View(business);
        }

        // GET: Business/Create
        public IActionResult Create()
        {
           ViewBag.Category = new SelectList(_context.Category.AsEnumerable(), "ID", "Name");
            return View();
        }

        // POST: Business/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,CategoryID,NumberPhone,Website")] Business business)
        {
            Category BusinessCategory =
                _context.Category.Where(c => c.ID == business.CategoryID).FirstOrDefault<Category>();
            business.Category = BusinessCategory;
            ModelState.Remove("Category");
            if (ModelState.IsValid)
            {
                //Find Category with CategoryID
                
                _context.Add(business);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }else{
                ViewBag.Category = new SelectList(_context.Category.AsEnumerable(), "ID", "Name");
            }
            return View(business);
        }

        // GET: Business/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Business == null)
            {
                return NotFound();
            }

            var business = await _context.Business.FindAsync(id);
            if (business == null)
            {
                return NotFound();
            }
            ViewBag.Category = new SelectList(_context.Category.AsEnumerable(), "ID", "Name");
            ViewBag.CategoryId = business.CategoryID;
            return View(business);
        }

        // POST: Business/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,CategoryID,NumberPhone,Website")] Business business)
        {
            if (id != business.ID)
            {
                return NotFound();
            }
            Category BusinessCategory =
                _context.Category.Where(c => c.ID == business.CategoryID).FirstOrDefault<Category>();
            business.Category = BusinessCategory;
            ModelState.Remove("Category");
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(business);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BusinessExists(business.ID))
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
            ViewBag.Category = new SelectList(_context.Category.AsEnumerable(), "ID", "Name");
            ViewBag.CategoryId = business.CategoryID;
            return View(business);
        }

        // GET: Business/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Business == null)
            {
                return NotFound();
            }

            var business = await _context.Business
                .FirstOrDefaultAsync(m => m.ID == id);
            if (business == null)
            {
                return NotFound();
            }
            Category BusinessCategory =
                _context.Category.Where(c => c.ID == business.CategoryID).FirstOrDefault<Category>();
            business.Category = BusinessCategory;

            return View(business);
        }

        // POST: Business/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Business == null)
            {
                return Problem("Entity set 'BusinessContext.Business'  is null.");
            }
            var business = await _context.Business.FindAsync(id);
            if (business != null)
            {
                _context.Business.Remove(business);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BusinessExists(int id)
        {
          return (_context.Business?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
