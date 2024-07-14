using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccessLayer.EntityFramework
{
	public class EfHeadingDal : GenericRepository<Heading>, IHeadingDal
    {
        public List<Heading> GetAllHeadingsWithCategoryWriters()
        {
            return _object.Include(h => h.Writer)
                .Include(h => h.Category).ToList();
        }
		public List<Heading> GetAllHeadingsOfWriters(int id)
		{
			return _object.Include(h => h.Category).
				Include(h => h.Writer).
				Where(h => h.WriterID == id).ToList();
		}

	}
}
