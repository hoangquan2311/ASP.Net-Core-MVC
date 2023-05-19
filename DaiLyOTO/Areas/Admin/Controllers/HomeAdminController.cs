using DaiLyOTO.Models;
using DaiLyOTO.Models.Authentication;
using DaiLyOTO.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace DaiLyOTO.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]
    public class HomeAdminController : Controller
    {
        QlotoContext db = new QlotoContext();

        [Route("")]
        [Route("index")]
        [Authentication]
        public IActionResult Index()
        {
            ViewBag.countDrive = db.DangKyLaiThus.AsNoTracking().Select(x => x.MaDk).Distinct().Count();
            ViewBag.countProduct = db.Xes.AsNoTracking().Select(x => x.MaXe).Distinct().Count();
            ViewBag.countContact = db.YeuCauTuVans.AsNoTracking().Select(x => x.MaYc).Distinct().Count();

            var drive = db.DangKyLaiThus.OrderByDescending(o => o.NgayGui)
                .Take(4)
                .Join(db.Xes, o => o.MaXe, u => u.MaXe, (o, u) => new { Drive = o, Product = u })
                .ToList();
            var contact = db.YeuCauTuVans.OrderByDescending(u => u.NgayGui)
                .Take(4)
                .Join(db.NhanViens, o => o.MaNv, u => u.MaNv, (o, u) => new { Contact = o, NV = u })
                .ToList();

            ViewBag.Drive = drive;
            ViewBag.Contact = contact;
            return View();
        }
    }
}
