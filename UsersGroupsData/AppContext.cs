using Microsoft.EntityFrameworkCore;
using UsersGroupsData.DBModels;

namespace UsersGroupsData
{
   public class AppContext : DbContext
   {
      public AppContext(DbContextOptions<AppContext> options) : base(options)
      {    
      }

      public DbSet<User> Users { get; set; }
      public DbSet<Group> Groups { get; set; }
      public DbSet<GroupMember> GroupMembers { get; set; }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         modelBuilder.Entity<User>().ToTable("Users");
         modelBuilder.Entity<Group>().ToTable("Groups");
         modelBuilder.Entity<GroupMember>().ToTable("GroupMembers");
      }
   }
}
