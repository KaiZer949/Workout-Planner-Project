using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using workout_planner.Server.Entities;

namespace workout_planner.Server.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            DataSeeding.Seeding(modelBuilder);

            modelBuilder.ApplyConfiguration(new UsersConfiguration());

        }

        public class UsersConfiguration : IEntityTypeConfiguration<Users>
        {

            public void Configure(EntityTypeBuilder<Users> modelBuilder)
            {
                modelBuilder.Property(k => k.Id)
                    .IsRequired()
                    .ValueGeneratedOnAdd();

                modelBuilder.Property(k => k.Name)
                    .IsRequired();

                modelBuilder.Property(k => k.Username)
                    .IsRequired()
                    .HasMaxLength(256);

                modelBuilder.Property(k => k.Password)
                    .IsRequired();

                modelBuilder.Property(k => k.Roles)
                    .HasConversion<String>();

                modelBuilder.HasIndex(k => k.Username).IsUnique();

            }

        }

    }
}
