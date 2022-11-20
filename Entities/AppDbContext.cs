using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Mi_Granjita_Paraiso.Entities
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public interface IAuditedEntity
        {
            string CreatedByUserId { get; set; }
            DateTime? CreatedDate { get; set; }
            string NewValue { get; set; }
            string OldValue { get; set; }
            EntityState Type { get; set; }
            string Colum { get; set; }
            string Table { get; set; }
        }
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public override int SaveChanges()
        {
            List<EntityState> states = new()
            {
                EntityState.Added,
                EntityState.Added
            };

            var addedEntities = ChangeTracker.Entries().Where(x => states.Contains(x.State));

            foreach(var entity in addedEntities)
            {
                entity.Metadata.GetContainerColumnName();
                entity.Metadata.GetTableName();
            }

            return base.SaveChanges();
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
        public DbSet<File> Files { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryType> CategoryTypes { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<MetaTag> MetaTag { get; set; }
        public DbSet<ItemFile> ItemFiles { get; set; }
    }
}
