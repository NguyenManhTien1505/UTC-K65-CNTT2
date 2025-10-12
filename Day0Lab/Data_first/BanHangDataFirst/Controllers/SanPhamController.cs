using Microsoft.AspNetCore.Mvc;
using BanHangDataFirst.Models;
using System.Linq;

namespace BanHangDataFirst.Controllers
{
    public class SanPhamController : Controller
    {
        private readonly QlbanHangDataFirstContext _context;

        public SanPhamController(QlbanHangDataFirstContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var ds = _context.SanPhams.ToList();
            return View(ds);
        }
    }
}
