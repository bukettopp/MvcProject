using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete
{


    public class Context : DbContext
    {
        public Context(){}
        public Context(DbContextOptions options) : base(options) { }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Heading> Headings { get; set; }
        public DbSet<Writer> Writers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-S8B6OPM\\SQLEXPRESS;Initial Catalog=MVCProjectDB;Integrated Security=True;TrustServerCertificate=True;");
        }
    }

}

//Nesne dediğimiz yapılanma canlı bir organizma içerisinde birden fazla anlamlı birbirleriyle ilişkisel veriler tutan ve sadece bunları tutmakla yetinmeyen birazda böyle entellektüel bir alışkanlığını yanı olan bu veriler üzerinde işlemler yapıp sonuçlar üretebilen fonksiyonellikler barındıran bir yapılanma/organizmadır.