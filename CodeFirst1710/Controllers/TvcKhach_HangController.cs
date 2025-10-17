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
    public class TvcKhach_HangController : Controller
    {
        private readonly TvcDay09LabCFContext _context;

        public TvcKhach_HangController(TvcDay09LabCFContext context)
        {
            _context = context;
        }

        // GET: TvcKhach_Hang
        public async Task<IActionResult> Index()
        {
            return View(await _context.TvcKhach_Hang.ToListAsync());
        }

        // GET: TvcKhach_Hang/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tvcKhach_Hang = await _context.TvcKhach_Hang
                .FirstOrDefaultAsync(m => m.tvcId == id);
            if (tvcKhach_Hang == null)
            {
                return NotFound();
            }

            return View(tvcKhach_Hang);
        }

        // GET: TvcKhach_Hang/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TvcKhach_Hang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("tvcId,tvcMaKhachHang,tvcHoTenKhachHang,tvcEmail,tvcMatKhau,tvcDienThoai,tvcDiaChi,tvcNgayDangKy,tvcTrangThai")] TvcKhach_Hang tvcKhach_Hang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tvcKhach_Hang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tvcKhach_Hang);
        }

        // GET: TvcKhach_Hang/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tvcKhach_Hang = await _context.TvcKhach_Hang.FindAsync(id);
            if (tvcKhach_Hang == null)
            {
                return NotFound();
            }
            return View(tvcKhach_Hang);
        }

        // POST: TvcKhach_Hang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("tvcId,tvcMaKhachHang,tvcHoTenKhachHang,tvcEmail,tvcMatKhau,tvcDienThoai,tvcDiaChi,tvcNgayDangKy,tvcTrangThai")] TvcKhach_Hang tvcKhach_Hang)
        {
            if (id != tvcKhach_Hang.tvcId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tvcKhach_Hang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TvcKhach_HangExists(tvcKhach_Hang.tvcId))
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
            return View(tvcKhach_Hang);
        }

        // GET: TvcKhach_Hang/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tvcKhach_Hang = await _context.TvcKhach_Hang
                .FirstOrDefaultAsync(m => m.tvcId == id);
            if (tvcKhach_Hang == null)
            {
                return NotFound();
            }

            return View(tvcKhach_Hang);
        }

        // POST: TvcKhach_Hang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tvcKhach_Hang = await _context.TvcKhach_Hang.FindAsync(id);
            if (tvcKhach_Hang != null)
            {
                _context.TvcKhach_Hang.Remove(tvcKhach_Hang);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TvcKhach_HangExists(int id)
        {
            return _context.TvcKhach_Hang.Any(e => e.tvcId == id);
        }
    }
}
