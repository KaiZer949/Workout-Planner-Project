using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using workout_planner.Server.Database;
using workout_planner.Server.DTO;
using workout_planner.Server.Models;

namespace workout_planner.Server.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly DatabaseContext _db;

        public ExerciseController(DatabaseContext db)
        {
            _db = db;
        }

        [HttpGet]
        public List<Exercise> GetExercises() {

            return _db.Exercise.ToList();
        }

        [HttpPost]
        //[Authorize("Admin")]
        [Route("AddExercise")]
        public async Task<ActionResult> PostExercise([FromBody] ExerciseDTO dto) {

            var newExer = new Exercise() {

                ExerciseName = dto.ExerciseName,
                musclegrp = dto.musclegrp

            };
            await _db.Exercise.AddAsync(newExer);
            await _db.SaveChangesAsync();
            return Ok(newExer);
        }

        [HttpPatch]
        [Route("updateexer/{id:int}")]
        public async Task<ActionResult> UpdateExercise(int id, [FromBody]ExerciseDTO dto) {


            var currentExercise = await _db.Exercise.Where((e) => e.ExerciseId == id).FirstOrDefaultAsync();
            if (currentExercise != null) { return NotFound("No exercise found"); }

            _db.Entry(currentExercise).CurrentValues.SetValues(dto);
            await _db.SaveChangesAsync();

            return Ok(currentExercise);
        }

        [HttpDelete]
        [Route("RemoveExercise")]
        public async Task<ActionResult> DeleteExercise(int id) {

            if (id == null || id == 0) return BadRequest("Id cannot be null");

            var IdExercise = await _db.Exercise.Where((e) => e.ExerciseId == id).FirstOrDefaultAsync();
            
            if (IdExercise == null) return NotFound($"No exercise with id:{id} found");

            _db.Exercise.Remove(IdExercise);
            await _db.SaveChangesAsync();

            return Ok($"Exercise Id:{id} removed successfully");
        }
    }
}
