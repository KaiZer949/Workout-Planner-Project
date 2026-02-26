namespace workout_planner.Server.Models
{

    public enum MuscleGrp {
    
        Abs=1,
        Chest,
        Biceps,
        Triceps,
        Shoulders,
        Legs
    
    }


    public class Exercise
    {

        public int ExerciseId {  get; set; }

        public string ExerciseName { get; set; }

        public MuscleGrp musclegrp{  get; set; }
    }
}
