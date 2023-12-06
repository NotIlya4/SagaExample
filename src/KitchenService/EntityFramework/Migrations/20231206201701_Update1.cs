using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KitchenService.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class Update1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FinishTime",
                table: "Tickets",
                newName: "RequestTime");

            migrationBuilder.AlterColumn<string>(
                name: "InternalId",
                table: "Tickets",
                type: "character varying(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<DateTime>(
                name: "EstimateTime",
                table: "Tickets",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_InternalId",
                table: "Tickets",
                column: "InternalId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tickets_InternalId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "EstimateTime",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "RequestTime",
                table: "Tickets",
                newName: "FinishTime");

            migrationBuilder.AlterColumn<string>(
                name: "InternalId",
                table: "Tickets",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(128)",
                oldMaxLength: 128);
        }
    }
}
