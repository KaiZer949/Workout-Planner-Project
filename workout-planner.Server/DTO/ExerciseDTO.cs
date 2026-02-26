using workout_planner.Server.Models;

namespace workout_planner.Server.DTO
{
    public class ExerciseDTO
    {
        public string ExerciseName { get; set; }
        public MuscleGrp musclegrp { get; set; }
    }
}
