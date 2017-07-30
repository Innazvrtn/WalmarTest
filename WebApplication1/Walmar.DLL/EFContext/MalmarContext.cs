using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Walmar.DLL.EFContext
{
    public  class MalmarContext: DbContext
    {
        public DbSet<Goods> Goodss { get; set; }
        public DbSet<GoodsReview> GoodsReviews { get; set; }

        public MalmarContext()
    : base( "DefaultConnection")
{
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<MalmarContext, Walmar.DLL.Migrations.Configuration>());
        }

        public MalmarContext(string connectionString)
            : base(connectionString)
        {
            Database.SetInitializer<MalmarContext>(new CreateDatabaseIfNotExists<MalmarContext>());
        }
    }
}
