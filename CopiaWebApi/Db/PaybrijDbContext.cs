using CopiaWebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace CopiaWebApi.Db
{
    public class PaybrijDbContext: DbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite(@"Data Source=Reference.db;Mode=ReadWriteCreate");
        //}

        public PaybrijDbContext(DbContextOptions<PaybrijDbContext> options) : base(options)
        {
        }

        public DbSet<InputFile> InputFiles { get; set; }
        public DbSet<OutputFile> OutputFiles { get; set; }
    }
}
