using Microsoft.EntityFrameworkCore;
using UsersGroupsData.DBModels;

namespace UsersGroupsData
{
   public class AppContext : DbContext
   {
      public DbSet<User> Users { get; set; }
      public DbSet<Group> Groups { get; set; }
      public DbSet<GroupMember> GroupMembers { get; set; }

      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      {
         optionsBuilder.UseSqlServer($"Data Source=sako-pc;Initial Catalog=qvcDB;Integrated Security=True;TrustServerCertificate=True");
      }
      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         modelBuilder.Entity<User>().ToTable("Users");
         modelBuilder.Entity<Group>().ToTable("Groups");
         modelBuilder.Entity<GroupMember>().ToTable("GroupMembers");
      }
   }
}
