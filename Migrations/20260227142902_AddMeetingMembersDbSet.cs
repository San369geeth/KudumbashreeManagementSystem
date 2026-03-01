using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KudumbashreeManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddMeetingMembersDbSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MeetingMember_Meetings_MeetingId",
                table: "MeetingMember");

            migrationBuilder.DropForeignKey(
                name: "FK_MeetingMember_Members_MemberId",
                table: "MeetingMember");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MeetingMember",
                table: "MeetingMember");

            migrationBuilder.RenameTable(
                name: "MeetingMember",
                newName: "MeetingMembers");

            migrationBuilder.RenameIndex(
                name: "IX_MeetingMember_MemberId",
                table: "MeetingMembers",
                newName: "IX_MeetingMembers_MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_MeetingMember_MeetingId",
                table: "MeetingMembers",
                newName: "IX_MeetingMembers_MeetingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MeetingMembers",
                table: "MeetingMembers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MeetingMembers_Meetings_MeetingId",
                table: "MeetingMembers",
                column: "MeetingId",
                principalTable: "Meetings",
                principalColumn: "MeetingId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MeetingMembers_Members_MemberId",
                table: "MeetingMembers",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "MemberId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MeetingMembers_Meetings_MeetingId",
                table: "MeetingMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_MeetingMembers_Members_MemberId",
                table: "MeetingMembers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MeetingMembers",
                table: "MeetingMembers");

            migrationBuilder.RenameTable(
                name: "MeetingMembers",
                newName: "MeetingMember");

            migrationBuilder.RenameIndex(
                name: "IX_MeetingMembers_MemberId",
                table: "MeetingMember",
                newName: "IX_MeetingMember_MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_MeetingMembers_MeetingId",
                table: "MeetingMember",
                newName: "IX_MeetingMember_MeetingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MeetingMember",
                table: "MeetingMember",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MeetingMember_Meetings_MeetingId",
                table: "MeetingMember",
                column: "MeetingId",
                principalTable: "Meetings",
                principalColumn: "MeetingId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MeetingMember_Members_MemberId",
                table: "MeetingMember",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "MemberId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
