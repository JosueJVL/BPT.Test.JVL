using BPT.Test.JVL.BackEnd.DataAccess.DAOs;
using Microsoft.EntityFrameworkCore;

namespace BPT.Test.JVL.BackEnd.DataAccess
{
    public class BPTDbContext : DbContext
    {
        public BPTDbContext(DbContextOptions<BPTDbContext> options)
            : base(options)
        {
        }

        public DbSet<Students> Students { get; set; }

        public DbSet<Assignment> Assignments { get; set; }

        public DbSet<AssignmentStudent> AssignmentStudents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Students>()
                .HasKey(c => new { c.IdStudent });
            modelBuilder.Entity<Assignment>()
                .HasKey(c => new { c.IdAssignment });
        }
    }
}
