using DaiLyOTO.Models;
using DaiLyOTO.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;
using X.PagedList;

namespace DaiLyOTO.Controllers
{
    public class HomeController : Controller
    {
        QlotoContext db = new QlotoContext();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var topProducts = (from ctdh in db.ChiTietHdbs
                               join sp in db.Xes on ctdh.MaXe equals sp.MaXe
                               orderby ctdh.SoLuong descending
                               select new Xe
                               {
                                   MaXe = sp.MaXe,
                                   TenXe = sp.TenXe,
                                   GiaBan = sp.GiaBan,
                                   GiamGia = sp.GiamGia,
                                   FileAnh = sp.FileAnh
                               }).Take(8).ToList();
            return View(topProducts);
        }

        public IActionResult Introduce()
        {
            return View();
        }

        public IActionResult Products(int? page, string maDong = null, string searchString = null)
        {
            int pageSize = 9;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            if (searchString != null)
            {
                var productsSearch = db.Xes.Where(x=>x.TenXe.Contains(searchString)).OrderBy(x => x.TenXe).AsNoTracking();
                ViewBag.Count = productsSearch.Count();
                ViewBag.Search = searchString;
                PagedList<Xe> pagedListSearch = new PagedList<Xe>(productsSearch, pageNumber, pageSize);
                return View(pagedListSearch);
            }
            if (maDong != null)
            {
                ViewBag.MaDong = maDong;
                ViewBag.TenDong = db.DongXes.Where(x => x.MaDong == maDong).Select(x => x.TenDong).FirstOrDefault();
                var productsByType = db.Xes.Where(x => x.MaDong == maDong).OrderBy(x => x.TenXe).AsNoTracking();
                ViewBag.Count = productsByType.Count();

                PagedList<Xe> pagedListByType = new PagedList<Xe>(productsByType, pageNumber, pageSize);
                return View(pagedListByType);
            }
            var products = db.Xes.OrderBy(x => x.TenXe).AsNoTracking().ToList();
            ViewBag.Count = products.Count();

            PagedList<Xe> pagedList = new PagedList<Xe>(products, pageNumber, pageSize);
            return View(pagedList);
        }
        public JsonResult GetSuggestions(string keyword)
        {
            var products = db.Xes.Where(x=>x.TenXe.Contains(keyword)).Take(4).OrderBy(x => x.TenXe)
                .Select(x => new ProductViewModel { MaXe = x.MaXe, TenXe = x.TenXe, GiaBan = x.GiaBan, GiamGia = x.GiamGia, FileAnh = x.FileAnh }); ;
            return Json(products);
        }
        public IActionResult ProductDetail(string maXe)
        {
            var product = db.Xes.Where(x => x.MaXe == maXe).FirstOrDefault();
            var listAnh = db.AnhChiTiets.Where(x => x.MaXe == maXe).ToList();
            ViewBag.ListAnh = listAnh;
            ViewBag.TenXe = product.TenXe.ToString();
            ViewBag.TenDong = db.DongXes.Where(x => x.MaDong == product.MaDong).Select(x => x.TenDong).FirstOrDefault();
            return View(product);
        }

        public IActionResult News()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Contact(YeuCauTuVan yeuCau)
        {
            string maYC;
            if (db.YeuCauTuVans.Count() == 0)
            {
                maYC = "YC1";
            }
            else
            {
                var maxYC = db.YeuCauTuVans.Max(x => x.MaYc);
                var maxMaYCNumber = int.Parse(maxYC.Substring(2)) + 1;
                maYC = "YC" + maxMaYCNumber;
            }

            yeuCau.MaYc = maYC;
            yeuCau.TrangThai = "Đang chờ nhân viên gọi lại";
            yeuCau.NgayGui = DateTime.Now;
            yeuCau.MaNv = db.NhanViens.OrderBy(x => Guid.NewGuid()).Select(x => x.MaNv).FirstOrDefault().ToString();
            try
            {
                db.YeuCauTuVans.Add(yeuCau);
                db.SaveChanges();
                TempData["Message"] = $"Đã gửi yêu cầu";
                TempData["MessageType"] = "success";
                return RedirectToAction("Contact");
            }
            catch
            {
                TempData["Message"] = $"Vui lòng điền thông tin";
                TempData["MessageType"] = "error";
                return View(yeuCau);
            }
        }
        public IActionResult RegisterDrive(string maXe = null)
        {
            ViewBag.maXe = maXe;
            ViewBag.MaXe = new SelectList(db.Xes.ToList(), "MaXe", "TenXe");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RegisterDrive(DangKyLaiThu dk)
        {
            ViewBag.MaXe = new SelectList(db.Xes.ToList(), "MaXe", "TenXe");
            string maDK;
            if (db.DangKyLaiThus.Count() == 0)
            {
                maDK = "DK1";
            }
            else
            {
                var maxDK = db.DangKyLaiThus.Max(x => x.MaDk);
                var maxMaDKNumber = int.Parse(maxDK.Substring(2)) + 1;
                maDK = "DK" + maxMaDKNumber;
            }

            dk.MaDk = maDK;
            dk.NgayGui = DateTime.Now;
            dk.MaXe = Request.Form["MaXe"];
            try
            {
                db.DangKyLaiThus.Add(dk);
                db.SaveChanges();
                TempData["Message"] = $"Đăng ký thành công";
                TempData["MessageType"] = "success";
                return RedirectToAction("RegisterDrive");
            }
            catch
            {
                TempData["Message"] = "aa" + dk.MaXe;
                TempData["MessageType"] = "error";
                return View(dk);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}