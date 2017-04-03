using System.Data.Entity;
using Tehas.Utils.DataBase.PagesDesc;
using Tehas.Utils.DataBase.Emails;
using Tehas.Utils.DataBase.Products;
using Tehas.Utils.DataBase.Security;

namespace Tehas.Utils.DataBase
{
    public class DbTehas : DbContext
    {
        public DbTehas()
        //:base("Local")
        :base("smarter")
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<PageDescription> PageDescriptions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<UserEmailMessage> Emails { get; set; }
        public DbSet<Game> Games { get; set; }
    }
}