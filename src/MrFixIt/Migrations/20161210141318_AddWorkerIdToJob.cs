using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MrFixIt.Migrations
{
    public partial class AddWorkerIdToJob : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Workers_WorkerId",
                table: "Jobs");

            migrationBuilder.AlterColumn<int>(
                name: "WorkerId",
                table: "Jobs",
                nullable: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Workers_WorkerId",
                table: "Jobs",
                column: "WorkerId",
                principalTable: "Workers",
                principalColumn: "WorkerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Workers_WorkerId",
                table: "Jobs");

            migrationBuilder.AlterColumn<int>(
                name: "WorkerId",
                table: "Jobs",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Workers_WorkerId",
                table: "Jobs",
                column: "WorkerId",
                principalTable: "Workers",
                principalColumn: "WorkerId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
