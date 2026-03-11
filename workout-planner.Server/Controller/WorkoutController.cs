using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using workout_planner.Server.Database;
using workout_planner.Server.DTO;
using workout_planner.Server.Models;

namespace workout_planner.Server.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutController : ControllerBase
    {
        private readonly DatabaseContext _db;
        public WorkoutController(DatabaseContext db)
        {
            _db = db;
        }

        [HttpGet("getWorkouts")]
        public List<Workout> getWorkouts()
        {
            return _db.Workout.ToList();
            
        }

        [HttpPost]
        public void createWorkout([FromBody] WorkoutDTO dto)
        {
            var newWorkout = new Workout()
            {
                WorkoutName = dto.WorkoutName,
                WorkoutDescription = dto.WorkoutDescription,
            };
        }

        [HttpPut]
        public void updateWorkout()
        {

        }

        [HttpDelete]
        public void deleteWorkout()
        {

        }

    
    }
}
