using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class first3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participations_Users_UserId",
                table: "Participations");

            migrationBuilder.DropIndex(
                name: "IX_Participations_UserId",
                table: "Participations");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Participations");

            migrationBuilder.AddColumn<Guid>(
                name: "MemberId",
                table: "Participations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Member_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 95, 160, 62, 56, 20, 60, 224, 155, 53, 169, 95, 208, 33, 4, 144, 11, 92, 45, 184, 185, 242, 2, 103, 190, 167, 189, 239, 248, 49, 212, 160, 233, 41, 205, 80, 16, 107, 78, 137, 18, 195, 63, 101, 206, 100, 122, 199, 128, 237, 152, 112, 111, 130, 57, 123, 238, 149, 57, 118, 205, 86, 255, 134, 216 }, new byte[] { 148, 132, 51, 41, 68, 203, 142, 197, 229, 86, 21, 140, 95, 46, 132, 68, 7, 237, 33, 191, 47, 254, 40, 70, 55, 213, 69, 51, 38, 82, 247, 209, 217, 148, 202, 6, 102, 55, 224, 227, 126, 26, 254, 225, 17, 41, 179, 237, 203, 155, 208, 73, 158, 43, 155, 92, 203, 82, 48, 111, 89, 6, 199, 210, 141, 38, 24, 194, 222, 181, 19, 218, 88, 43, 212, 22, 170, 153, 185, 205, 200, 210, 16, 242, 123, 21, 86, 39, 251, 230, 116, 116, 184, 3, 63, 230, 151, 38, 142, 74, 154, 165, 44, 94, 199, 13, 57, 252, 68, 217, 234, 31, 41, 88, 115, 121, 48, 213, 34, 51, 106, 173, 41, 169, 2, 109, 92, 92 } });

            migrationBuilder.CreateIndex(
                name: "IX_Participations_MemberId",
                table: "Participations",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Member_UserId",
                table: "Member",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Participations_Member_MemberId",
                table: "Participations",
                column: "MemberId",
                principalTable: "Member",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participations_Member_MemberId",
                table: "Participations");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropIndex(
                name: "IX_Participations_MemberId",
                table: "Participations");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "Participations");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Participations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 147, 226, 145, 218, 252, 144, 191, 60, 90, 36, 195, 233, 87, 33, 9, 53, 92, 185, 57, 94, 48, 165, 77, 240, 241, 137, 136, 250, 221, 228, 96, 143, 225, 96, 100, 251, 222, 71, 150, 212, 64, 8, 247, 101, 40, 9, 188, 166, 140, 165, 168, 213, 119, 246, 165, 43, 198, 22, 84, 156, 198, 250, 234, 174 }, new byte[] { 254, 15, 201, 226, 212, 221, 47, 141, 27, 70, 143, 29, 85, 162, 52, 120, 254, 23, 226, 196, 203, 118, 69, 108, 14, 111, 249, 164, 48, 111, 191, 114, 43, 254, 6, 132, 219, 22, 222, 120, 117, 21, 237, 159, 137, 25, 63, 208, 30, 197, 36, 187, 118, 199, 157, 79, 154, 71, 141, 198, 230, 79, 73, 218, 149, 16, 91, 137, 163, 3, 121, 117, 126, 221, 157, 93, 30, 90, 142, 250, 123, 77, 92, 94, 57, 70, 170, 136, 41, 226, 135, 163, 253, 26, 7, 83, 117, 73, 49, 174, 11, 140, 216, 164, 197, 26, 139, 176, 125, 98, 206, 35, 171, 115, 52, 67, 78, 76, 87, 179, 121, 75, 138, 178, 124, 179, 52, 36 } });

            migrationBuilder.CreateIndex(
                name: "IX_Participations_UserId",
                table: "Participations",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Participations_Users_UserId",
                table: "Participations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
