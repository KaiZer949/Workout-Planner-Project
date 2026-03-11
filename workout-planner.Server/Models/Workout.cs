namespace workout_planner.Server.Models
{
    public class Workout
    {
        public Guid id { get; set; }

        public string WorkoutName { get; set; }

        public string WorkoutDescription { get; set; }

        public ICollection<Exercise> Exercises { get; set; }
    }
}
