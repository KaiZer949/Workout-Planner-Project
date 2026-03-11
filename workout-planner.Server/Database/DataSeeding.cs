using Microsoft.EntityFrameworkCore;
using workout_planner.Server.Models;

namespace workout_planner.Server.Database
{
    public static class DataSeeding
    {


        public static  void Seeding(ModelBuilder model)
        {
            model.Entity<Users>().HasData(

                new Users { Id = 1, Name = "Admin", Username = "Admin", Password = "admin", Roles = Roles.Admin },
                new Users { Id = 2, Name = "User", Username = "User1", Password = "user", Roles = Roles.User }

            );

            model.Entity<Exercise>().HasData(

                new Exercise { ExerciseId = 1, ExerciseName = "Barbell Curl", musclegrp = MuscleGrp.Biceps },

                new Exercise { ExerciseId = 2, ExerciseName = "Hammer Curl", musclegrp = MuscleGrp.Biceps },

                new Exercise { ExerciseId = 3, ExerciseName = "Skull Crushers", musclegrp = MuscleGrp.Triceps },

                new Exercise { ExerciseId = 4, ExerciseName = "Triceps Pushdown", musclegrp = MuscleGrp.Triceps },

                new Exercise { ExerciseId = 5, ExerciseName = "Plank", musclegrp = MuscleGrp.Abs },

                new Exercise { ExerciseId = 6, ExerciseName = "Hanging Leg Raise", musclegrp = MuscleGrp.Abs },

                new Exercise { ExerciseId = 7, ExerciseName = "Barbell Bench Press", musclegrp = MuscleGrp.Chest },

                new Exercise { ExerciseId = 8, ExerciseName = "Incline Dumbbell Fly", musclegrp = MuscleGrp.Chest },

                new Exercise { ExerciseId = 9, ExerciseName = "Overhead Press", musclegrp = MuscleGrp.Shoulders },

                new Exercise { ExerciseId = 10, ExerciseName = "Lateral Raise", musclegrp = MuscleGrp.Shoulders }

            );

            model.Entity<Workout>().HasData(

                new Workout
                {
                    id = GuidIds.WorkoutAId,
                    WorkoutName = "Workout A",
                    WorkoutDescription = "Full Body"
                },
                new Workout
                {
                    id = GuidIds.DummyWorkoutId,
                    WorkoutName = "Dummy Workout",
                    WorkoutDescription = "DummyData"
                },
                new Workout
                {
                    id = GuidIds.DummyWorkoutAId,
                    WorkoutName = "Dummy Workout A",
                    WorkoutDescription = "Dummy"
                }

            );
        }
    }
}
