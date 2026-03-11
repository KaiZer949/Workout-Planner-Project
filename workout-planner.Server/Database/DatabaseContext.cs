using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using workout_planner.Server.Models;

namespace workout_planner.Server.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Users> Users { get; set; }

        //Forgot to write dbset<exercise> while applying migration but still db table is created bcz even without Dbset,
        //applyconfig(blueprint) is telling EF Core how to build the table is enough for it to realize that the table needs to exist in the database.
        //But without dbset you cannot use _db.Exercise<T>
        public DbSet<Exercise> Exercise { get; set; }     
        public DbSet<Workout> Workout { get; set; }     

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            DataSeeding.Seeding(modelBuilder);


            modelBuilder.ApplyConfiguration(new UsersConfiguration());
            modelBuilder.ApplyConfiguration(new ExerciseConfiguration());
            modelBuilder.ApplyConfiguration(new WorkoutConfiguration());

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

        public class ExerciseConfiguration : IEntityTypeConfiguration<Exercise> { 

            public void Configure(EntityTypeBuilder<Exercise> model)
            {
                model.Property(k => k.ExerciseId)
                    .IsRequired()
                    .ValueGeneratedOnAdd();

                model.Property(k => k.ExerciseName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("Exercise");


                model.Property(k => k.musclegrp)
                    .HasConversion<String>();


            }

        }
        public class WorkoutConfiguration : IEntityTypeConfiguration<Workout> { 

            public void Configure(EntityTypeBuilder<Workout> model)
            {
                model.Property(k => k.id)
                    .IsRequired()
                    .ValueGeneratedOnAdd();

                model.Property(k => k.WorkoutName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("Workout Name");


                model.Property(k => k.WorkoutDescription)
                    .IsRequired()
                    .HasMaxLength(250);

                model.HasMany(e => e.Exercises)
                     .WithMany(e => e.Workouts)
                     .UsingEntity(d => d.HasData(new { Workoutsid = GuidIds.WorkoutAId, ExercisesExerciseId = 1 }, 
                                                 new { Workoutsid = GuidIds.WorkoutAId, ExercisesExerciseId = 7 }, 
                                                 new { Workoutsid = GuidIds.WorkoutAId, ExercisesExerciseId = 9 }));
            }

        }

    }
}
