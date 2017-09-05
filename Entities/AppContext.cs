using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore_Stack.Entities
{
    public class AppContext: DbContext
    {
        
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserToken> UserTokens { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder
                .UseMySql(@"Server=localhost;database=aspnetcore-stack;uid=root;pwd=1;");
        }
        
        public override int SaveChanges()
        {
            AddTimestamps();
            return base.SaveChanges();
        }

        private void AddTimestamps()
        {
            var entities = ChangeTracker
                .Entries()
                .Where(
                    x => 
                        x.Entity is BaseEntity && 
                        (x.State == EntityState.Added || x.State == EntityState.Modified)
                );

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    ((BaseEntity)entity.Entity).DateCreated = DateTime.UtcNow;
                }

                ((BaseEntity)entity.Entity).DateModified = DateTime.UtcNow;
            }
        }
    }
}