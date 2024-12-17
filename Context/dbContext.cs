using haditApi.Models;

using Microsoft.EntityFrameworkCore;

using System;
using System.ComponentModel.DataAnnotations;


namespace haditApi
{
    public class dbContext : DbContext
    {
        public dbContext(DbContextOptions<dbContext> options):base(options)
        {
        }

        public override int SaveChanges()
        {
            ExecuteEntityValidation();
            return base.SaveChanges();
        }
        public void ExecuteEntityValidation()
        {
            var entities = ChangeTracker.Entries<Hadit>()
                .Where(e=>e.State==EntityState.Added || e.State == EntityState.Modified);
            foreach (var entity in entities)
            {
                var _invalid = !System.Text.RegularExpressions.Regex.IsMatch(entity.Entity.Content, @"^[\u0600-\u06FF\s]+$");
                //if (_invalid)

                    //throw new ValidationException("Support only Arabic langue");
            }
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ExecuteEntityValidation();
            return base.SaveChangesAsync(cancellationToken);
        }
        public DbSet<Hadit> Hadites { get; set; }
        public DbSet<Category> Categories { get; set; }
        
    }
}
