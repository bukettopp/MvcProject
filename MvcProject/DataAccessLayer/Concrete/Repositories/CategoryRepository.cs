using DataAccessLayer.Concrete.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccessLayer.Concrete.Repositories
{
    public class CategoryRepository : ICategoryDal
    {
        Context c = new Context();
        DbSet<Category> _object;
        public void Delete(Category p)
        {
           _object.Remove(p);
          c.SaveChanges();
        }

        public void Insert(Category p)
        {
           _object.Add(p);
            c.SaveChanges();// executenonquery
        }

        public List<Category> List()
        {
          return _object.ToList();
        }

        public List<Category> List(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Category p)
        {
            c.SaveChanges();
        }
    }
}
