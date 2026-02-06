using Microsoft.EntityFrameworkCore;
using workout_planner.Server.Entities;

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
        }
    }
}
