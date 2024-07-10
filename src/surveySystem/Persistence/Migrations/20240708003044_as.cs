using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class @as : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Result",
                table: "ParticipationResults",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 236, 212, 126, 52, 0, 160, 230, 120, 162, 126, 1, 242, 126, 208, 193, 6, 168, 86, 130, 218, 104, 234, 122, 168, 110, 29, 136, 93, 95, 237, 9, 83, 37, 141, 206, 126, 54, 27, 40, 237, 214, 135, 126, 240, 223, 50, 129, 54, 115, 174, 174, 164, 134, 174, 103, 193, 170, 91, 70, 76, 204, 54, 87, 201 }, new byte[] { 209, 210, 161, 138, 199, 165, 191, 52, 239, 128, 124, 206, 92, 32, 202, 101, 54, 4, 39, 154, 156, 97, 30, 62, 11, 227, 155, 183, 177, 212, 216, 130, 32, 179, 147, 107, 89, 22, 140, 163, 86, 8, 94, 213, 211, 186, 100, 163, 8, 151, 49, 106, 32, 180, 126, 94, 171, 236, 128, 17, 226, 37, 128, 174, 217, 89, 247, 205, 92, 84, 142, 122, 187, 91, 15, 229, 105, 211, 35, 207, 127, 26, 197, 47, 31, 95, 152, 240, 251, 62, 237, 103, 186, 136, 120, 110, 227, 204, 11, 57, 147, 75, 104, 229, 110, 184, 102, 58, 185, 18, 161, 141, 83, 184, 65, 11, 87, 91, 193, 238, 243, 65, 209, 18, 102, 69, 112, 64 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Result",
                table: "ParticipationResults",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 98, 167, 117, 31, 217, 79, 90, 9, 14, 200, 21, 41, 175, 55, 5, 89, 19, 131, 98, 198, 102, 137, 51, 136, 139, 213, 99, 3, 47, 158, 34, 7, 74, 112, 21, 187, 184, 97, 123, 39, 93, 34, 130, 214, 238, 108, 105, 125, 62, 7, 228, 123, 27, 227, 18, 15, 187, 114, 207, 40, 23, 224, 245, 144 }, new byte[] { 142, 190, 133, 152, 24, 196, 85, 69, 153, 3, 218, 67, 107, 2, 28, 253, 117, 251, 37, 222, 97, 96, 98, 203, 250, 60, 197, 246, 141, 133, 238, 166, 221, 63, 28, 168, 103, 40, 255, 247, 128, 154, 4, 119, 133, 59, 112, 245, 186, 35, 46, 145, 143, 0, 10, 219, 215, 66, 198, 129, 223, 31, 186, 174, 64, 183, 199, 65, 37, 13, 150, 196, 208, 212, 17, 97, 25, 74, 252, 195, 190, 231, 41, 10, 141, 183, 8, 95, 62, 185, 125, 132, 186, 220, 102, 77, 88, 232, 113, 15, 143, 234, 233, 241, 78, 3, 53, 111, 154, 139, 156, 228, 46, 63, 199, 172, 129, 59, 92, 229, 50, 101, 136, 111, 193, 92, 48, 77 } });
        }
    }
}
