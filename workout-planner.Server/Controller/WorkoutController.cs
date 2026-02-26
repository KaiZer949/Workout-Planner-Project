using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using workout_planner.Server.Models;

namespace workout_planner.Server.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutController : ControllerBase
    {
        public WorkoutController()
        {
            
        }

        [HttpGet]
        public void getWorkouts()
        {

        }

        [HttpPost]
        public void createWorkout()
        {
                
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
