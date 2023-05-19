using DaiLyOTO.Repository;
using DaiLyOTO.Models;
using Microsoft.AspNetCore.Mvc;
namespace DaiLyOTO.ViewComponents
{
	public class TypeMenuViewComponent : ViewComponent
	{
		private readonly ITypeMenuRepository _dongXe;
		public TypeMenuViewComponent (ITypeMenuRepository TypeMenuRepository)
		{
            _dongXe = TypeMenuRepository;
		}

		public IViewComponentResult Invoke()
		{
			var dongXe = _dongXe.GetAllDongXe().OrderBy(x => x.TenDong);
			return View(dongXe);
		}
	}
}
