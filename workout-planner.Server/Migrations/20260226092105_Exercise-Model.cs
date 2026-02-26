using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workout_planner.Server.Migrations
{
    /// <inheritdoc />
    public partial class ExerciseModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    ExerciseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Exercise = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    musclegrp = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise", x => x.ExerciseId);
                });

            migrationBuilder.InsertData(
                table: "Exercise",
                columns: new[] { "ExerciseId", "Exercise", "musclegrp" },
                values: new object[,]
                {
                    { 1, "Barbell Curl", "Biceps" },
                    { 2, "Hammer Curl", "Biceps" },
                    { 3, "Skull Crushers", "Triceps" },
                    { 4, "Triceps Pushdown", "Triceps" },
                    { 5, "Plank", "Abs" },
                    { 6, "Hanging Leg Raise", "Abs" },
                    { 7, "Barbell Bench Press", "Chest" },
                    { 8, "Incline Dumbbell Fly", "Chest" },
                    { 9, "Overhead Press", "Shoulders" },
                    { 10, "Lateral Raise", "Shoulders" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exercise");
        }
    }
}
