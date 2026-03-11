using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workout_planner.Server.Migrations
{
    /// <inheritdoc />
    public partial class DataSeedWorkout : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Workout",
                columns: new[] { "id", "WorkoutDescription", "Workout Name" },
                values: new object[,]
                {
                    { new Guid("a1b2c3d4-e5f6-47a8-b9c0-d1e2f3a4b5c6"), "Full Body", "Workout A" },
                    { new Guid("b2c3d4e5-f6a7-48b9-c0d1-e2f3a4b5c6d7"), "DummyData", "Dummy Workout" },
                    { new Guid("c3d4e5f6-a7b8-49c9-d0e1-f2a3b4c5d6e7"), "Dummy", "Dummy Workout A" }
                });

            migrationBuilder.InsertData(
                table: "ExerciseWorkout",
                columns: new[] { "ExercisesExerciseId", "Workoutsid" },
                values: new object[,]
                {
                    { 1, new Guid("a1b2c3d4-e5f6-47a8-b9c0-d1e2f3a4b5c6") },
                    { 7, new Guid("a1b2c3d4-e5f6-47a8-b9c0-d1e2f3a4b5c6") },
                    { 9, new Guid("a1b2c3d4-e5f6-47a8-b9c0-d1e2f3a4b5c6") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ExerciseWorkout",
                keyColumns: new[] { "ExercisesExerciseId", "Workoutsid" },
                keyValues: new object[] { 1, new Guid("a1b2c3d4-e5f6-47a8-b9c0-d1e2f3a4b5c6") });

            migrationBuilder.DeleteData(
                table: "ExerciseWorkout",
                keyColumns: new[] { "ExercisesExerciseId", "Workoutsid" },
                keyValues: new object[] { 7, new Guid("a1b2c3d4-e5f6-47a8-b9c0-d1e2f3a4b5c6") });

            migrationBuilder.DeleteData(
                table: "ExerciseWorkout",
                keyColumns: new[] { "ExercisesExerciseId", "Workoutsid" },
                keyValues: new object[] { 9, new Guid("a1b2c3d4-e5f6-47a8-b9c0-d1e2f3a4b5c6") });

            migrationBuilder.DeleteData(
                table: "Workout",
                keyColumn: "id",
                keyValue: new Guid("b2c3d4e5-f6a7-48b9-c0d1-e2f3a4b5c6d7"));

            migrationBuilder.DeleteData(
                table: "Workout",
                keyColumn: "id",
                keyValue: new Guid("c3d4e5f6-a7b8-49c9-d0e1-f2a3b4c5d6e7"));

            migrationBuilder.DeleteData(
                table: "Workout",
                keyColumn: "id",
                keyValue: new Guid("a1b2c3d4-e5f6-47a8-b9c0-d1e2f3a4b5c6"));
        }
    }
}
