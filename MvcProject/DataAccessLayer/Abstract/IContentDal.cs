using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IContentDal:IRepository<Content>
    {
        List<Content> GetAllContentWithWriterHeadings(Expression<Func<Content, bool>> filter);
    }
}
