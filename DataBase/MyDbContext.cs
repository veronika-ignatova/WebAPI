using DataBase.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBase
{
    public class MyDbContext : DbContext
    {
        internal DbSet<User> Users { get; set; }
        internal DbSet<Address> Addresses { get; set; }
        public MyDbContext(DbContextOptions<MyDbContext> options)
           : base(options)
        {
        }
    }
}