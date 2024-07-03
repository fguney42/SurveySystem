using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class first4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Member_Users_UserId",
                table: "Member");

            migrationBuilder.DropForeignKey(
                name: "FK_Participations_Member_MemberId",
                table: "Participations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Member",
                table: "Member");

            migrationBuilder.RenameTable(
                name: "Member",
                newName: "Members");

            migrationBuilder.RenameIndex(
                name: "IX_Member_UserId",
                table: "Members",
                newName: "IX_Members_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Members",
                table: "Members",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 45,
                column: "Name",
                value: "Members.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 46,
                column: "Name",
                value: "Members.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 47,
                column: "Name",
                value: "Members.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 48,
                column: "Name",
                value: "Members.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 49,
                column: "Name",
                value: "Members.Update");

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 50, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Members.Delete", null },
                    { 51, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Member", null },
                    { 52, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Auth.Admin", null },
                    { 53, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Auth.Write", null },
                    { 54, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Auth.Read", null },
                    { 55, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Auth.RevokeToken", null },
                    { 56, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Member", null }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 90, 42, 147, 135, 188, 54, 76, 87, 146, 142, 154, 25, 212, 67, 138, 80, 42, 127, 167, 223, 167, 174, 44, 202, 39, 222, 25, 42, 49, 226, 104, 229, 110, 87, 239, 166, 0, 179, 15, 157, 169, 94, 22, 106, 178, 210, 167, 149, 143, 178, 10, 142, 153, 52, 10, 163, 60, 160, 5, 8, 75, 171, 238, 51 }, new byte[] { 206, 202, 176, 138, 156, 11, 130, 60, 252, 229, 255, 245, 228, 234, 156, 108, 22, 102, 153, 204, 5, 252, 126, 195, 127, 218, 9, 97, 147, 4, 244, 166, 31, 116, 86, 98, 166, 31, 133, 38, 24, 179, 208, 75, 183, 228, 72, 3, 0, 98, 240, 40, 215, 46, 197, 90, 169, 232, 131, 242, 172, 72, 142, 159, 3, 178, 75, 46, 60, 80, 136, 214, 233, 205, 115, 159, 207, 175, 77, 98, 195, 254, 82, 167, 143, 31, 114, 135, 11, 74, 144, 113, 187, 22, 81, 134, 96, 155, 160, 225, 196, 48, 115, 211, 237, 125, 77, 234, 195, 202, 36, 43, 140, 161, 99, 120, 15, 215, 236, 99, 86, 133, 126, 113, 246, 231, 188, 140 } });

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Users_UserId",
                table: "Members",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Participations_Members_MemberId",
                table: "Participations",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Users_UserId",
                table: "Members");

            migrationBuilder.DropForeignKey(
                name: "FK_Participations_Members_MemberId",
                table: "Participations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Members",
                table: "Members");

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.RenameTable(
                name: "Members",
                newName: "Member");

            migrationBuilder.RenameIndex(
                name: "IX_Members_UserId",
                table: "Member",
                newName: "IX_Member_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Member",
                table: "Member",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 45,
                column: "Name",
                value: "Auth.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 46,
                column: "Name",
                value: "Auth.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 47,
                column: "Name",
                value: "Auth.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 48,
                column: "Name",
                value: "Auth.RevokeToken");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 49,
                column: "Name",
                value: "Member");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 95, 160, 62, 56, 20, 60, 224, 155, 53, 169, 95, 208, 33, 4, 144, 11, 92, 45, 184, 185, 242, 2, 103, 190, 167, 189, 239, 248, 49, 212, 160, 233, 41, 205, 80, 16, 107, 78, 137, 18, 195, 63, 101, 206, 100, 122, 199, 128, 237, 152, 112, 111, 130, 57, 123, 238, 149, 57, 118, 205, 86, 255, 134, 216 }, new byte[] { 148, 132, 51, 41, 68, 203, 142, 197, 229, 86, 21, 140, 95, 46, 132, 68, 7, 237, 33, 191, 47, 254, 40, 70, 55, 213, 69, 51, 38, 82, 247, 209, 217, 148, 202, 6, 102, 55, 224, 227, 126, 26, 254, 225, 17, 41, 179, 237, 203, 155, 208, 73, 158, 43, 155, 92, 203, 82, 48, 111, 89, 6, 199, 210, 141, 38, 24, 194, 222, 181, 19, 218, 88, 43, 212, 22, 170, 153, 185, 205, 200, 210, 16, 242, 123, 21, 86, 39, 251, 230, 116, 116, 184, 3, 63, 230, 151, 38, 142, 74, 154, 165, 44, 94, 199, 13, 57, 252, 68, 217, 234, 31, 41, 88, 115, 121, 48, 213, 34, 51, 106, 173, 41, 169, 2, 109, 92, 92 } });

            migrationBuilder.AddForeignKey(
                name: "FK_Member_Users_UserId",
                table: "Member",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Participations_Member_MemberId",
                table: "Participations",
                column: "MemberId",
                principalTable: "Member",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
