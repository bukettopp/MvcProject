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
        public DbSet<Message> Messages { get; set; }
        public DbSet<ImageFile> ImageFiles { get; set; }
        public DbSet<Admin> Admins { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-S8B6OPM\\SQLEXPRESS;Initial Catalog=MVCProjectDB;Integrated Security=True;TrustServerCertificate=True;");
        }
    }

}

