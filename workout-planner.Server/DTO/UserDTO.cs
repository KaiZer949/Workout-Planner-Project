using workout_planner.Server.Models;

namespace workout_planner.Server.DTO
{
    public class UserDTO
    {
        public string Name {  get; set; }
        public string UserName { get; set; }

        public string Password{ get; set; }

        public Roles Role { get; set; }
    }
}
