namespace workout_planner.Server.Models
{
    public class Workout
    {
        public Guid id { get; set; }

        public string WorkoutName { get; set; }

        public Exercise exercise { get; set; }

        public string WorkoutDescription { get; set; }
    }
}
