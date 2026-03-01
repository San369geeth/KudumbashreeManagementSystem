using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KudumbashreeManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddMeetingMember : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contributions");

            migrationBuilder.CreateTable(
                name: "MeetingMember",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeetingId = table.Column<int>(type: "int", nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    IsPresent = table.Column<bool>(type: "bit", nullable: false),
                    ContributionAmount = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeetingMember_Meetings_MeetingId",
                        column: x => x.MeetingId,
                        principalTable: "Meetings",
                        principalColumn: "MeetingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MeetingMember_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MeetingMember_MeetingId",
                table: "MeetingMember",
                column: "MeetingId");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingMember_MemberId",
                table: "MeetingMember",
                column: "MemberId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MeetingMember");

            migrationBuilder.CreateTable(
                name: "Contributions",
                columns: table => new
                {
                    ContributionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeetingId = table.Column<int>(type: "int", nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contributions", x => x.ContributionId);
                    table.ForeignKey(
                        name: "FK_Contributions_Meetings_MeetingId",
                        column: x => x.MeetingId,
                        principalTable: "Meetings",
                        principalColumn: "MeetingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contributions_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contributions_MeetingId",
                table: "Contributions",
                column: "MeetingId");

            migrationBuilder.CreateIndex(
                name: "IX_Contributions_MemberId",
                table: "Contributions",
                column: "MemberId");
        }
    }
}
