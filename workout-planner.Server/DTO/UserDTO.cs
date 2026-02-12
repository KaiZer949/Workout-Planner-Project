using System.ComponentModel.DataAnnotations;
using workout_planner.Server.Models;

namespace workout_planner.Server.DTO
{
    public class UserDTO
    {
        [Required]
        public string Name {  get; set; }

        [Required]
        public string UserName { get; set; }
        
        [Required]
        public string Password{ get; set; }
        
        [Required]
        public Roles Role { get; set; }
    }
}
