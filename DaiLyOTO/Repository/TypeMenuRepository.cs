using DaiLyOTO.Repository;
using DaiLyOTO.Models;

namespace DaiLyOTO.Repository
{
	public class TypeMenuRepository : ITypeMenuRepository
	{
		private readonly QlotoContext _context;
		public TypeMenuRepository(QlotoContext context)
		{
			_context = context;
		}

		public DongXe Add(DongXe dongXe)
		{
			_context.DongXes.Add(dongXe);
			_context.SaveChanges();
			return dongXe;
		}

		public DongXe Delete(string maDong)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<DongXe> GetAllDongXe()
		{
			return _context.DongXes;
		}

		public DongXe GetDongXe(string maDong)
		{
			return _context.DongXes.Find(maDong);
		}

		public DongXe Update(DongXe dongXe)
		{
			_context.Update(dongXe);
			_context.SaveChanges();
			return dongXe;
		}
	}
}
