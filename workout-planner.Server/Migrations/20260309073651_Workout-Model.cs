using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace workout_planner.Server.Migrations
{
    /// <inheritdoc />
    public partial class WorkoutModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Workout",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkoutName = table.Column<string>(name: "Workout Name", type: "nvarchar(30)", maxLength: 30, nullable: false),
                    WorkoutDescription = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workout", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseWorkout",
                columns: table => new
                {
                    ExercisesExerciseId = table.Column<int>(type: "int", nullable: false),
                    Workoutsid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseWorkout", x => new { x.ExercisesExerciseId, x.Workoutsid });
                    table.ForeignKey(
                        name: "FK_ExerciseWorkout_Exercise_ExercisesExerciseId",
                        column: x => x.ExercisesExerciseId,
                        principalTable: "Exercise",
                        principalColumn: "ExerciseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseWorkout_Workout_Workoutsid",
                        column: x => x.Workoutsid,
                        principalTable: "Workout",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseWorkout_Workoutsid",
                table: "ExerciseWorkout",
                column: "Workoutsid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExerciseWorkout");

            migrationBuilder.DropTable(
                name: "Workout");
        }
    }
}
