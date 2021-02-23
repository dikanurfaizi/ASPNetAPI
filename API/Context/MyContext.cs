using API.Models;
using System.Data.Entity;

namespace API.Context
{
    public class MyContext : DbContext
    {
        public MyContext() : base("myConnection") { }

        public DbSet<Trainee> Trainees { get; set; }

        public DbSet<Account> Accounts { get; set; }
    }
}