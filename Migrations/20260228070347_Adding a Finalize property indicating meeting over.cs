using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KudumbashreeManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddingaFinalizepropertyindicatingmeetingover : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFinalized",
                table: "Meetings",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFinalized",
                table: "Meetings");
        }
    }
}
