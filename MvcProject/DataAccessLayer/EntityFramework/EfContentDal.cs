using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfContentDal : GenericRepository<Content>, IContentDal
    {
        //public List<Content> GetAllContentWithWriterHeadings()
        //{
        //    return _object.Include(c => c.Writer)
        //        .Include(c => c.Heading).ToList();
        //}

        public List<Content> GetAllContentWithWriterHeadings(Expression<Func<Content, bool>> filter)
        {
            return _object.Include(c => c.Writer)
                 .Include(c => c.Heading).Where(filter)
                 .ToList();
        }
    }
}
