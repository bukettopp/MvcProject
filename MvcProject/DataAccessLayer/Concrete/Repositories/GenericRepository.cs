using DataAccessLayer.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccessLayer.Concrete.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        Context c= new Context();
        DbSet<T> _object;
        public GenericRepository()
        {
           _object=c.Set<T>();
        }
        public void Delete(T p)
        {
           _object.Remove(p);
            c.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter);
        }

        public void Insert(T p)
        {
            _object.Add(p);
            c.SaveChanges();
        }

        public List<T> List()
        {
          return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
          return _object.Where(filter).ToList();
        }

        public void Update(T p)
        {
            c.SaveChanges();
        }
    }
}


//Biliyorum bazıları böyle kanı kaynıyor böyle teoriden kaçan bir tarzda arkadaşlarımız var ama yazılım da hani ben de hiperaktifim ben de yerimde duramam teoriden sevmem böyle sıkılırım falan ama yani yazılım öğreneceksek önce teori... neyin ne olduğunu bileceksin neyi bildiğini ya neyi öğrendiğini bileceksin ya kim bu? niye?niçin kullanıyoruz? Belirli soruları soracan cevaplarını alacaksın ki hani tekniğin bir anlamı olsun.