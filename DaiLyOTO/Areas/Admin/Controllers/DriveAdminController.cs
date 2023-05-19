using DaiLyOTO.Models;
using DaiLyOTO.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace DaiLyOTO.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("DriveAdmin")]
    public class DriveAdminController : Controller
    {
        QlotoContext db = new QlotoContext();

        [Route("")]
        [Route("index")]
        [Route("GetAllDrive")]
        public IActionResult GetAllDrive(int? page, int? pageSize, string? filter)
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
                var lstSpFilter = (from dk in db.DangKyLaiThus
                                   join xe in db.Xes on dk.MaXe equals xe.MaXe
                                   where dk.HoTen.Contains(filter)
                                   select new DriveViewModel
                                   {
                                       MaDk = dk.MaDk,
                                       NgayGui = dk.NgayGui,
                                       ThoiGianDk = dk.ThoiGianDk,
                                       HoTen = dk.HoTen,
                                       Sdt = dk.Sdt,
                                       GhiChu = dk.GhiChu,
                                       TenXe = xe.TenXe
                                   }).ToList();
                PagedList<DriveViewModel> lstFilter = new PagedList<DriveViewModel>(lstSpFilter, pageNumber, currentPageSize);
                return View(lstFilter);
            }
            var lstSp = (from dk in db.DangKyLaiThus
                         join xe in db.Xes on dk.MaXe equals xe.MaXe
                         select new DriveViewModel
                         {
                             MaDk = dk.MaDk,
                             NgayGui = dk.NgayGui,
                             ThoiGianDk = dk.ThoiGianDk,
                             HoTen = dk.HoTen,
                             Sdt = dk.Sdt,
                             GhiChu = dk.GhiChu,
                             TenXe = xe.TenXe
                         }).ToList();
            PagedList<DriveViewModel> lst = new PagedList<DriveViewModel>(lstSp, pageNumber, currentPageSize);
            return View(lst);
        }
        [Route("GetAllDriveTable")]
        public IActionResult GetAllDriveTable(int? page, int? pageSize, string? filter)
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
                var lstSpFilter = (from dk in db.DangKyLaiThus
                                   join xe in db.Xes on dk.MaXe equals xe.MaXe
                                   where dk.HoTen.Contains(filter)
                                   select new DriveViewModel
                                   {
                                       MaDk = dk.MaDk,
                                       NgayGui = dk.NgayGui,
                                       ThoiGianDk = dk.ThoiGianDk,
                                       HoTen = dk.HoTen,
                                       Sdt = dk.Sdt,
                                       GhiChu = dk.GhiChu,
                                       TenXe = xe.TenXe
                                   }).ToList(); 
                PagedList<DriveViewModel> lstFilter = new PagedList<DriveViewModel>(lstSpFilter, pageNumber, currentPageSize);
                return PartialView("GetAllDriveTable", lstFilter);
            }
            var lstSp = (from dk in db.DangKyLaiThus
                         join xe in db.Xes on dk.MaXe equals xe.MaXe
                         where dk.HoTen.Contains(filter)
                         select new DriveViewModel
                         {
                             MaDk = dk.MaDk,
                             NgayGui = dk.NgayGui,
                             ThoiGianDk = dk.ThoiGianDk,
                             HoTen = dk.HoTen,
                             Sdt = dk.Sdt,
                             GhiChu = dk.GhiChu,
                             TenXe = xe.TenXe
                         }).ToList();
            PagedList<DriveViewModel> lst = new PagedList<DriveViewModel>(lstSp, pageNumber, currentPageSize);
            return PartialView("GetAllDriveTable", lst);
        }


        [Route("DeleteDrive")]
        [HttpGet]
        public IActionResult DeleteDrive(string maSp)
        {
            TempData["Message"] = "";
            try
            {
                db.Remove(db.DangKyLaiThus.Find(maSp));
                db.SaveChanges();
                TempData["Message"] = $"Phiếu đăng ký có mã {maSp} đã được xóa";
                TempData["MessageType"] = "success";
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Xóa Phiếu đăng ký không thành công: " + ex.Message;
                TempData["MessageType"] = "error";
            }

            return RedirectToAction("GetAllDrive");
        }
    }
}
