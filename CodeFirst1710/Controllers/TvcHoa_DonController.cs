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
    public class TvcHoa_DonController : Controller
    {
        private readonly TvcDay09LabCFContext _context;

        public TvcHoa_DonController(TvcDay09LabCFContext context)
        {
            _context = context;
        }

        // GET: TvcHoa_Don
        public async Task<IActionResult> Index()
        {
            var tvcDay09LabCFContext = _context.TvcHoa_Don.Include(t => t.tvcKhachHang);
            return View(await tvcDay09LabCFContext.ToListAsync());
        }

        // GET: TvcHoa_Don/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tvcHoa_Don = await _context.TvcHoa_Don
                .Include(t => t.tvcKhachHang)
                .FirstOrDefaultAsync(m => m.tvcId == id);
            if (tvcHoa_Don == null)
            {
                return NotFound();
            }

            return View(tvcHoa_Don);
        }

        // GET: TvcHoa_Don/Create
        public IActionResult Create()
        {
            ViewData["tvcMaKhachHang"] = new SelectList(_context.TvcKhach_Hang, "tvcId", "tvcMaKhachHang");
            return View();
        }

        // POST: TvcHoa_Don/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("tvcId,tvcMaHoaDon,tvcMaKhachHang,tvcNgayHoaDon,tvcNgayNhan,tvcHoTenKhachHang,tvcEmail,tvcDienThoai,tvcDiaChi,tvcTongTriGia,tvcTrangThai")] TvcHoa_Don tvcHoa_Don)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tvcHoa_Don);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["tvcMaKhachHang"] = new SelectList(_context.TvcKhach_Hang, "tvcId", "tvcMaKhachHang", tvcHoa_Don.tvcMaKhachHang);
            return View(tvcHoa_Don);
        }

        // GET: TvcHoa_Don/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tvcHoa_Don = await _context.TvcHoa_Don.FindAsync(id);
            if (tvcHoa_Don == null)
            {
                return NotFound();
            }
            ViewData["tvcMaKhachHang"] = new SelectList(_context.TvcKhach_Hang, "tvcId", "tvcMaKhachHang", tvcHoa_Don.tvcMaKhachHang);
            return View(tvcHoa_Don);
        }

        // POST: TvcHoa_Don/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("tvcId,tvcMaHoaDon,tvcMaKhachHang,tvcNgayHoaDon,tvcNgayNhan,tvcHoTenKhachHang,tvcEmail,tvcDienThoai,tvcDiaChi,tvcTongTriGia,tvcTrangThai")] TvcHoa_Don tvcHoa_Don)
        {
            if (id != tvcHoa_Don.tvcId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tvcHoa_Don);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TvcHoa_DonExists(tvcHoa_Don.tvcId))
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
            ViewData["tvcMaKhachHang"] = new SelectList(_context.TvcKhach_Hang, "tvcId", "tvcMaKhachHang", tvcHoa_Don.tvcMaKhachHang);
            return View(tvcHoa_Don);
        }

        // GET: TvcHoa_Don/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tvcHoa_Don = await _context.TvcHoa_Don
                .Include(t => t.tvcKhachHang)
                .FirstOrDefaultAsync(m => m.tvcId == id);
            if (tvcHoa_Don == null)
            {
                return NotFound();
            }

            return View(tvcHoa_Don);
        }

        // POST: TvcHoa_Don/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tvcHoa_Don = await _context.TvcHoa_Don.FindAsync(id);
            if (tvcHoa_Don != null)
            {
                _context.TvcHoa_Don.Remove(tvcHoa_Don);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TvcHoa_DonExists(int id)
        {
            return _context.TvcHoa_Don.Any(e => e.tvcId == id);
        }
    }
}
