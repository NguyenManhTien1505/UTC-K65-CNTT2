using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using nmt_231230923_de02.Models;

namespace nmt_231230923_de02.Controllers
{
    public class NmtCatalogsController : Controller
    {
        private readonly NguyenManhTien231230923De02Context _context;

        public NmtCatalogsController(NguyenManhTien231230923De02Context context)
        {
            _context = context;
        }

        // GET: NmtCatalogs
        public async Task<IActionResult> NmtIndex()
        {
            return View(await _context.NmtCatalogs.ToListAsync());
        }

        // GET: NmtCatalogs/Details/5
        public async Task<IActionResult> NmtDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nmtCatalog = await _context.NmtCatalogs
                .FirstOrDefaultAsync(m => m.NmtId == id);
            if (nmtCatalog == null)
            {
                return NotFound();
            }

            return View(nmtCatalog);
        }

        // GET: NmtCatalogs/Create
        public IActionResult NmtCreate()
        {
            return View();
        }

        // POST: NmtCatalogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NmtId,NmtCateName,NmtCatePrice,NmtCateQty,NmtPicture,NmtCateActive")] NmtCatalog nmtCatalog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nmtCatalog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(NmtIndex));
            }
            return View(nmtCatalog);
        }

        // GET: NmtCatalogs/Edit/5
        public async Task<IActionResult> NmtEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nmtCatalog = await _context.NmtCatalogs.FindAsync(id);
            if (nmtCatalog == null)
            {
                return NotFound();
            }
            return View(nmtCatalog);
        }

        // POST: NmtCatalogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NmtEdit(int id, [Bind("NmtId,NmtCateName,NmtCatePrice,NmtCateQty,NmtPicture,NmtCateActive")] NmtCatalog nmtCatalog)
        {
            if (id != nmtCatalog.NmtId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nmtCatalog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NmtCatalogExists(nmtCatalog.NmtId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(NmtIndex));
            }
            return View(nmtCatalog);
        }

        // GET: NmtCatalogs/Delete/5
        public async Task<IActionResult> NmtDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nmtCatalog = await _context.NmtCatalogs
                .FirstOrDefaultAsync(m => m.NmtId == id);
            if (nmtCatalog == null)
            {
                return NotFound();
            }

            return View(nmtCatalog);
        }

        // POST: NmtCatalogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nmtCatalog = await _context.NmtCatalogs.FindAsync(id);
            if (nmtCatalog != null)
            {
                _context.NmtCatalogs.Remove(nmtCatalog);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(NmtIndex));
        }

        private bool NmtCatalogExists(int id)
        {
            return _context.NmtCatalogs.Any(e => e.NmtId == id);
        }
    }
}
