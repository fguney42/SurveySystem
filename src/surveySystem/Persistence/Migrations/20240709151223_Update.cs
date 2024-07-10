﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 204, 26, 165, 111, 168, 7, 127, 151, 240, 43, 127, 19, 144, 120, 84, 51, 139, 59, 25, 31, 153, 83, 62, 98, 228, 248, 212, 133, 193, 143, 13, 23, 191, 240, 207, 227, 236, 8, 53, 136, 171, 193, 87, 231, 128, 154, 152, 154, 178, 77, 137, 15, 249, 193, 21, 74, 21, 211, 126, 228, 242, 68, 240, 148 }, new byte[] { 206, 105, 78, 58, 50, 70, 183, 228, 236, 220, 254, 158, 254, 229, 134, 180, 179, 87, 233, 144, 78, 50, 101, 23, 13, 126, 137, 160, 165, 149, 179, 234, 161, 158, 218, 229, 73, 189, 206, 198, 245, 208, 194, 20, 66, 134, 74, 75, 62, 239, 120, 237, 120, 55, 182, 59, 172, 75, 118, 65, 91, 231, 131, 92, 65, 55, 142, 91, 65, 222, 68, 24, 149, 72, 99, 197, 45, 220, 122, 48, 13, 207, 149, 100, 128, 231, 196, 225, 223, 144, 161, 54, 201, 59, 72, 56, 188, 117, 102, 126, 215, 184, 173, 65, 139, 228, 146, 200, 77, 84, 23, 220, 81, 91, 47, 30, 119, 32, 204, 106, 171, 210, 187, 68, 140, 74, 165, 126 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 168, 185, 6, 106, 179, 241, 219, 111, 96, 94, 194, 142, 250, 55, 9, 107, 9, 198, 165, 241, 167, 85, 29, 142, 75, 102, 216, 203, 36, 80, 125, 213, 113, 199, 7, 18, 248, 75, 63, 104, 218, 246, 70, 3, 88, 55, 80, 92, 176, 17, 156, 73, 242, 108, 161, 239, 162, 72, 171, 140, 253, 79, 178, 11 }, new byte[] { 46, 138, 248, 116, 52, 70, 44, 238, 76, 70, 96, 73, 175, 115, 133, 125, 106, 133, 176, 33, 223, 48, 159, 121, 92, 190, 168, 14, 88, 164, 202, 147, 0, 246, 157, 246, 112, 152, 190, 28, 41, 107, 93, 141, 2, 102, 184, 98, 203, 216, 42, 68, 202, 247, 12, 235, 92, 152, 255, 142, 166, 84, 126, 107, 95, 177, 213, 90, 164, 51, 241, 150, 244, 214, 182, 119, 25, 4, 186, 210, 190, 22, 29, 72, 31, 98, 82, 25, 243, 176, 64, 199, 165, 7, 79, 225, 214, 108, 34, 140, 195, 191, 194, 90, 164, 6, 236, 133, 6, 67, 171, 151, 158, 218, 98, 133, 119, 78, 95, 34, 21, 168, 161, 17, 27, 255, 164, 108 } });
        }
    }
}