using DaiLyOTO.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace DaiLyOTO.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("ContactAdmin")]
    public class ContactAdminController : Controller
    {
        QlotoContext db = new QlotoContext();

        [Route("")]
        [Route("index")]
        [Route("GetAllContact")]
        public IActionResult GetAllContact(int? page, int? pageSize, string? filter)
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
                var lstSpFilter = db.YeuCauTuVans.AsNoTracking().Where(x => x.HoTen.Contains(filter)).ToList();
                PagedList<YeuCauTuVan> lstFilter = new PagedList<YeuCauTuVan>(lstSpFilter, pageNumber, currentPageSize);
                return View(lstFilter);
            }
            var lstSp = db.YeuCauTuVans.AsNoTracking().ToList();
            PagedList<YeuCauTuVan> lst = new PagedList<YeuCauTuVan>(lstSp, pageNumber, currentPageSize);
            return View(lst);
        }
        [Route("GetAllContactTable")]
        public IActionResult GetAllContactTable(int? page, int? pageSize, string? filter)
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
                var lstSpFilter = db.YeuCauTuVans.AsNoTracking().Where(x => x.HoTen.Contains(filter)).ToList();
                PagedList<YeuCauTuVan> lstFilter = new PagedList<YeuCauTuVan>(lstSpFilter, pageNumber, currentPageSize);
                return PartialView("GetAllContactTable", lstFilter);
            }
            var lstSp = db.YeuCauTuVans.AsNoTracking().ToList();
            PagedList<YeuCauTuVan> lst = new PagedList<YeuCauTuVan>(lstSp, pageNumber, currentPageSize);
            return PartialView("GetAllContactTable", lst);
        }


        [Route("DeleteContact")]
        [HttpGet]
        public IActionResult DeleteContact(string maSp)
        {
            TempData["Message"] = "";
            try
            {
                db.Remove(db.YeuCauTuVans.Find(maSp));
                db.SaveChanges();
                TempData["Message"] = $"Yêu cầu có mã {maSp} đã được xóa";
                TempData["MessageType"] = "success";
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Xóa Yêu cầu không thành công: " + ex.Message;
                TempData["MessageType"] = "error";
            }

            return RedirectToAction("GetAllContact");
        }
    }
}
