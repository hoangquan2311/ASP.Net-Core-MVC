using DaiLyOTO.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace DaiLyOTO.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("ProductAdmin")]
    public class ProductAdminController : Controller
    {
        QlotoContext db = new QlotoContext();

        [Route("")]
        [Route("index")]
        [Route("GetAllProduct")]
        public IActionResult GetAllProduct(int? page, int? pageSize, string? filter)
        {
            int defaultPageSize = 5;
            if (page != null)
            {
                ViewBag.pageSize = pageSize;
            }
            if (filter != null)
            {
                ViewBag.filter = filter;
            }
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            int currentPageSize = pageSize == null || pageSize < 1 ? defaultPageSize : pageSize.Value;
            if (filter != null)
            {
                var lstSpFilter = db.Xes.AsNoTracking().Where(x => x.TenXe.Contains(filter)).ToList();
                PagedList<Xe> lstFilter = new PagedList<Xe>(lstSpFilter, pageNumber, currentPageSize);
                return View(lstFilter);
            }
            var lstSp = db.Xes.AsNoTracking().ToList();
            PagedList<Xe> lst = new PagedList<Xe>(lstSp, pageNumber, currentPageSize);
            return View(lst);
        }
        [Route("GetAllProductTable")]
        public IActionResult GetAllProductTable(int? page, int? pageSize, string? filter)
        {
            int defaultPageSize = 5;
            if (page != null)
            {
                ViewBag.pageSize = pageSize;
            }
            if (filter != null)
            {
                ViewBag.filter = filter;
            }
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            int currentPageSize = pageSize == null || pageSize < 1 ? defaultPageSize : pageSize.Value;
            if (filter != null)
            {
                var lstSpFilter = db.Xes.AsNoTracking().Where(x => x.TenXe.Contains(filter)).ToList();
                PagedList<Xe> lstFilter = new PagedList<Xe>(lstSpFilter, pageNumber, currentPageSize);
                return PartialView("GetAllProductTable", lstFilter);
            }
            var lstSp = db.Xes.AsNoTracking().ToList();
            PagedList<Xe> lst = new PagedList<Xe>(lstSp, pageNumber, currentPageSize);
            return PartialView("GetAllProductTable", lst);
        }

        [Route("AddProduct")]
        public IActionResult AddProduct()
        {
            ViewBag.MaDong = new SelectList(db.DongXes.ToList(), "MaDong", "TenDong");
            var maxMaXe = db.Xes.Max(x => x.MaXe);
            var maxMaXeNumber = int.Parse(maxMaXe.Substring(2)) + 1;
            ViewBag.maxMaXeNumber = "XE" + maxMaXeNumber;
            return View();
        }

        [Route("AddProduct")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddProduct(Xe sp, IFormFile imageFile)
        {
            ViewBag.MaDong = new SelectList(db.DongXes.ToList(), "MaDong", "TenDong");
            string maXe;
            if (db.Xes.Count() == 0)
            {
                maXe = "XE1";
            }
            else
            {
                var maxMaXe = db.Xes.Max(x => x.MaXe);
                var maxMaXeNumber = int.Parse(maxMaXe.Substring(2)) + 1;
                maXe = "XE" + maxMaXeNumber;
            }
            ViewBag.maxMaXeNumber = maXe;
            if (imageFile != null && imageFile.Length > 0)
            {
                // Lưu tệp tin ảnh vào thư mục Images
                var fileName = Path.GetFileName(imageFile.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "assets", "img", "sanpham", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    imageFile.CopyTo(stream);
                }
            }
            try
            {
                db.Xes.Add(sp);
                db.SaveChanges();
                return RedirectToAction("GetAllProduct");
            }
            catch
            {
                TempData["Message"] = $"Thất bại";
                TempData["MessageType"] = "error";
                return View(sp);
            }
        }

        [Route("AddImageDetails")]
        public IActionResult AddImageDetails(IFormFile imageFile)
        {
            ViewBag.MaXe = new SelectList(db.Xes.ToList(), "MaXe", "TenXe");
            string maACT;
            if (db.AnhChiTiets.Count() == 0)
            {
                maACT = "ACT1";
            }
            else
            {
                var maxMaACT = db.AnhChiTiets.Max(x => x.MaAct);
                var maxMaACTNumber = int.Parse(maxMaACT.Substring(3)) + 1;
                maACT = "ACT" + maxMaACTNumber;
            }
            ViewBag.maxMaACTNumber = maACT;
            return View();
        }

        /// <summary>
        ///     Create 1 sp
        /// </summary>
        [Route("AddImageDetails")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddImageDetails(AnhChiTiet chitietanh, IFormFile imageFile)
        {
            ViewBag.MaXe = new SelectList(db.Xes.ToList(), "MaXe", "TenXe");
            string maACT;
            if (db.AnhChiTiets.Count() == 0)
            {
                maACT = "ACT1";
            }
            else
            {
                var maxMaACT = db.AnhChiTiets.Max(x => x.MaAct);
                var maxMaACTNumber = int.Parse(maxMaACT.Substring(3)) + 1;
                maACT = "ACT" + maxMaACTNumber;
            }
            ViewBag.maxMaACTNumber = maACT;
            if (imageFile != null && imageFile.Length > 0)
            {
                // Lưu tệp tin ảnh vào thư mục Images
                var fileName = Path.GetFileName(imageFile.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "assets", "img", "sanpham", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    imageFile.CopyTo(stream);
                }
            }
            try
            {
                db.AnhChiTiets.Add(chitietanh);
                db.SaveChanges();
                TempData["Message"] = $"Thêm thành công";
                TempData["MessageType"] = "success";
                return View(chitietanh);
            }
            catch
            {
                TempData["Message"] = $"Thất bại";
                TempData["MessageType"] = "error";
                return View(chitietanh);
            }
        }


        /// <summary>
        ///     Sửa điện thoại
        /// </summary>
        [Route("EditProduct")]
        [HttpGet]
        public IActionResult EditProduct(string maSp, IFormFile imageFile)
        {
            ViewBag.MaDong = new SelectList(db.DongXes.ToList(), "MaDong", "TenDong");
            var sp = db.Xes.Find(maSp);
            return View(sp);
        }


        /// <summary>
        ///     Sửa điện thoại
        /// </summary>
        /// <param name="userinfo"></param>
        /// <returns></returns>
        [Route("EditProduct")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditProduct(Xe sp, IFormFile imageFile)
        {
            ViewBag.MaDong = new SelectList(db.DongXes.ToList(), "MaDong", "TenDong");
            if (imageFile != null && imageFile.Length > 0)
            {
                // Lưu tệp tin ảnh vào thư mục Images
                var fileName = Path.GetFileName(imageFile.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "assets", "img", "sanpham", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    imageFile.CopyTo(stream);
                }
            }
            try
            {
                db.Entry(sp).State = EntityState.Modified;
                db.SaveChanges();
                TempData["Message"] = $"Sửa thành công";
                TempData["MessageType"] = "success";
                return View(sp);
            }
            catch
            {
                TempData["Message"] = $"Thất bại";
                TempData["MessageType"] = "error";
                return View(sp);
            }
        }

        [Route("DeleteProduct")]
        [HttpGet]
        public IActionResult DeleteProduct(string maSp)
        {
            TempData["Message"] = "";
            var dangkylaithu = db.DangKyLaiThus.Where(x => x.MaXe == maSp).ToList();
            if (dangkylaithu.Count() > 0)
            {
                TempData["Message"] = $"Sản phẩm có mã {maSp} không được xóa";
                TempData["MessageType"] = "error";
                return RedirectToAction("GetAllProduct");
            }
            var hoadonhaps = db.ChiTietHdns.Where(x => x.MaXe == maSp).ToList();
            if (hoadonhaps.Count() > 0)
            {
                TempData["Message"] = $"Sản phẩm có mã {maSp} không được xóa";
                TempData["MessageType"] = "error";
                return RedirectToAction("GetAllProduct");
            }
            var hoadonbans = db.ChiTietHdbs.Where(x => x.MaXe == maSp).ToList();
            if (hoadonbans.Count() > 0)
            {
                TempData["Message"] = $"Sản phẩm có mã {maSp} không được xóa";
                TempData["MessageType"] = "error";
                return RedirectToAction("GetAllProduct");
            }
            try
            {
                var listAnh = db.AnhChiTiets.Where(x => x.MaXe == maSp).ToList();
                if (listAnh.Any()) db.RemoveRange(listAnh);
                db.Remove(db.Xes.Find(maSp));
                db.SaveChanges();
                TempData["Message"] = $"Sản phẩm có mã {maSp} đã được xóa";
                TempData["MessageType"] = "success";
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Xóa Sản phẩm không thành công: " + ex.Message;
                TempData["MessageType"] = "error";
            }

            return RedirectToAction("GetAllProduct");
        }
    }
}
