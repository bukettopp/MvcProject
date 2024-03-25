using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework
{
	public class EfHeadingDal : GenericRepository<Heading>, IHeadingDal
    {
        public List<Heading> GetAllHeadingsWithCategoryWriters()
        {
            return _object.Include(h => h.Writer)
                .Include(h => h.Category).ToList();
        }
    }
}
