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
    public class TvcLoai_San_PhamController : Controller
    {
        private readonly TvcDay09LabCFContext _context;

        public TvcLoai_San_PhamController(TvcDay09LabCFContext context)
        {
            _context = context;
        }

        // GET: TvcLoai_San_Pham
        public async Task<IActionResult> Index()
        {
            return View(await _context.tvcLoai_San_Phams.ToListAsync());
        }

        // GET: TvcLoai_San_Pham/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tvcLoai_San_Pham = await _context.tvcLoai_San_Phams
                .FirstOrDefaultAsync(m => m.tvcId == id);
            if (tvcLoai_San_Pham == null)
            {
                return NotFound();
            }

            return View(tvcLoai_San_Pham);
        }

        // GET: TvcLoai_San_Pham/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TvcLoai_San_Pham/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("tvcId,tvcMaLoai,tvcTrangThai")] TvcLoai_San_Pham tvcLoai_San_Pham)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(tvcLoai_San_Pham);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    // In lỗi ra Output Window
                    Console.WriteLine("Lỗi khi lưu: " + ex.Message);
                    ModelState.AddModelError("", "Lỗi lưu dữ liệu: " + ex.Message);
                }
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                Console.WriteLine("⚠️ ModelState errors: " + string.Join(" | ", errors));
            }

            return View(tvcLoai_San_Pham);
        }



        // GET: TvcLoai_San_Pham/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tvcLoai_San_Pham = await _context.tvcLoai_San_Phams.FindAsync(id);
            if (tvcLoai_San_Pham == null)
            {
                return NotFound();
            }
            return View(tvcLoai_San_Pham);
        }

        // POST: TvcLoai_San_Pham/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("tvcId,tvcMaLoai,tvcTrangThai")] TvcLoai_San_Pham tvcLoai_San_Pham)
        {
            if (id != tvcLoai_San_Pham.tvcId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tvcLoai_San_Pham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TvcLoai_San_PhamExists(tvcLoai_San_Pham.tvcId))
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
            return View(tvcLoai_San_Pham);
        }

        // GET: TvcLoai_San_Pham/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tvcLoai_San_Pham = await _context.tvcLoai_San_Phams
                .FirstOrDefaultAsync(m => m.tvcId == id);
            if (tvcLoai_San_Pham == null)
            {
                return NotFound();
            }

            return View(tvcLoai_San_Pham);
        }

        // POST: TvcLoai_San_Pham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var tvcLoai_San_Pham = await _context.tvcLoai_San_Phams.FindAsync(id);
            if (tvcLoai_San_Pham != null)
            {
                _context.tvcLoai_San_Phams.Remove(tvcLoai_San_Pham);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TvcLoai_San_PhamExists(long id)
        {
            return _context.tvcLoai_San_Phams.Any(e => e.tvcId == id);
        }
    }
}
