using DaiLyOTO.Models;
namespace DaiLyOTO.Repository
{
	public interface ITypeMenuRepository
	{
		DongXe Add(DongXe dongXe);
		DongXe Update(DongXe dongXe);	
		DongXe Delete(string maDong);
		DongXe GetDongXe(string maDong);
		IEnumerable<DongXe> GetAllDongXe();
	}
}
