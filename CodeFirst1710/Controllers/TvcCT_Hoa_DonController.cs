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
    public class TvcCT_Hoa_DonController : Controller
    {
        private readonly TvcDay09LabCFContext _context;

        public TvcCT_Hoa_DonController(TvcDay09LabCFContext context)
        {
            _context = context;
        }

        // GET: TvcCT_Hoa_Don
        public async Task<IActionResult> Index()
        {
            var tvcDay09LabCFContext = _context.TvcCT_Hoa_Don.Include(t => t.tvcHoaDon).Include(t => t.tvcSan_Pham);
            return View(await tvcDay09LabCFContext.ToListAsync());
        }

        // GET: TvcCT_Hoa_Don/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tvcCT_Hoa_Don = await _context.TvcCT_Hoa_Don
                .Include(t => t.tvcHoaDon)
                .Include(t => t.tvcSan_Pham)
                .FirstOrDefaultAsync(m => m.tvcHoaDonID == id);
            if (tvcCT_Hoa_Don == null)
            {
                return NotFound();
            }

            return View(tvcCT_Hoa_Don);
        }

        // GET: TvcCT_Hoa_Don/Create
        public IActionResult Create()
        {
            ViewData["tvcHoaDonID"] = new SelectList(_context.TvcHoa_Don, "tvcId", "tvcId");
            ViewData["tvcSan_PhamID"] = new SelectList(_context.tvcSan_Phams, "tvcId", "tvcMaSanPham");
            return View();
        }

        // POST: TvcCT_Hoa_Don/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("tvcHoaDonID,tvcSan_PhamID,tvcSoLuongMua,tvcDonGiaMua,tvcThanhTien,tvcTrangThai")] TvcCT_Hoa_Don tvcCT_Hoa_Don)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tvcCT_Hoa_Don);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["tvcHoaDonID"] = new SelectList(_context.TvcHoa_Don, "tvcId", "tvcId", tvcCT_Hoa_Don.tvcHoaDonID);
            ViewData["tvcSan_PhamID"] = new SelectList(_context.tvcSan_Phams, "tvcId", "tvcMaSanPham", tvcCT_Hoa_Don.tvcSan_PhamID);
            return View(tvcCT_Hoa_Don);
        }

        // GET: TvcCT_Hoa_Don/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tvcCT_Hoa_Don = await _context.TvcCT_Hoa_Don.FindAsync(id);
            if (tvcCT_Hoa_Don == null)
            {
                return NotFound();
            }
            ViewData["tvcHoaDonID"] = new SelectList(_context.TvcHoa_Don, "tvcId", "tvcId", tvcCT_Hoa_Don.tvcHoaDonID);
            ViewData["tvcSan_PhamID"] = new SelectList(_context.tvcSan_Phams, "tvcId", "tvcMaSanPham", tvcCT_Hoa_Don.tvcSan_PhamID);
            return View(tvcCT_Hoa_Don);
        }

        // POST: TvcCT_Hoa_Don/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("tvcHoaDonID,tvcSan_PhamID,tvcSoLuongMua,tvcDonGiaMua,tvcThanhTien,tvcTrangThai")] TvcCT_Hoa_Don tvcCT_Hoa_Don)
        {
            if (id != tvcCT_Hoa_Don.tvcHoaDonID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tvcCT_Hoa_Don);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TvcCT_Hoa_DonExists(tvcCT_Hoa_Don.tvcHoaDonID))
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
            ViewData["tvcHoaDonID"] = new SelectList(_context.TvcHoa_Don, "tvcId", "tvcId", tvcCT_Hoa_Don.tvcHoaDonID);
            ViewData["tvcSan_PhamID"] = new SelectList(_context.tvcSan_Phams, "tvcId", "tvcMaSanPham", tvcCT_Hoa_Don.tvcSan_PhamID);
            return View(tvcCT_Hoa_Don);
        }

        // GET: TvcCT_Hoa_Don/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tvcCT_Hoa_Don = await _context.TvcCT_Hoa_Don
                .Include(t => t.tvcHoaDon)
                .Include(t => t.tvcSan_Pham)
                .FirstOrDefaultAsync(m => m.tvcHoaDonID == id);
            if (tvcCT_Hoa_Don == null)
            {
                return NotFound();
            }

            return View(tvcCT_Hoa_Don);
        }

        // POST: TvcCT_Hoa_Don/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tvcCT_Hoa_Don = await _context.TvcCT_Hoa_Don.FindAsync(id);
            if (tvcCT_Hoa_Don != null)
            {
                _context.TvcCT_Hoa_Don.Remove(tvcCT_Hoa_Don);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TvcCT_Hoa_DonExists(int id)
        {
            return _context.TvcCT_Hoa_Don.Any(e => e.tvcHoaDonID == id);
        }
    }
}
