using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CodeFirst1710.Models;

namespace CodeFirst1710.Controllers
{
    public class TvcQuan_TriController : Controller
    {
        private readonly TvcDay09LabCFContext _context;

        public TvcQuan_TriController(TvcDay09LabCFContext context)
        {
            _context = context;
        }

        // GET: TvcQuan_Tri
        public async Task<IActionResult> Index()
        {
            return View(await _context.TvcQuan_Tri.ToListAsync());
        }

        // GET: TvcQuan_Tri/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tvcQuan_Tri = await _context.TvcQuan_Tri
                .FirstOrDefaultAsync(m => m.tvcId == id);
            if (tvcQuan_Tri == null)
            {
                return NotFound();
            }

            return View(tvcQuan_Tri);
        }

        // GET: TvcQuan_Tri/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TvcQuan_Tri/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("tvcId,tvcTaiKhoan,tvcMatKhau,tvcTrangThai")] TvcQuan_Tri tvcQuan_Tri)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tvcQuan_Tri);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tvcQuan_Tri);
        }

        // GET: TvcQuan_Tri/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tvcQuan_Tri = await _context.TvcQuan_Tri.FindAsync(id);
            if (tvcQuan_Tri == null)
            {
                return NotFound();
            }
            return View(tvcQuan_Tri);
        }

        // POST: TvcQuan_Tri/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("tvcId,tvcTaiKhoan,tvcMatKhau,tvcTrangThai")] TvcQuan_Tri tvcQuan_Tri)
        {
            if (id != tvcQuan_Tri.tvcId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tvcQuan_Tri);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TvcQuan_TriExists(tvcQuan_Tri.tvcId))
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
            return View(tvcQuan_Tri);
        }

        // GET: TvcQuan_Tri/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tvcQuan_Tri = await _context.TvcQuan_Tri
                .FirstOrDefaultAsync(m => m.tvcId == id);
            if (tvcQuan_Tri == null)
            {
                return NotFound();
            }

            return View(tvcQuan_Tri);
        }

        // POST: TvcQuan_Tri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tvcQuan_Tri = await _context.TvcQuan_Tri.FindAsync(id);
            if (tvcQuan_Tri != null)
            {
                _context.TvcQuan_Tri.Remove(tvcQuan_Tri);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TvcQuan_TriExists(int id)
        {
            return _context.TvcQuan_Tri.Any(e => e.tvcId == id);
        }
    }
}
