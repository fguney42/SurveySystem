using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class entityChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "PercentYes",
                table: "ParticipationResults",
                type: "float",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "PercentNo",
                table: "ParticipationResults",
                type: "float",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 27, 241, 229, 89, 112, 28, 139, 117, 246, 44, 94, 26, 235, 23, 59, 166, 79, 250, 80, 146, 41, 127, 184, 203, 125, 4, 98, 3, 28, 86, 12, 163, 170, 57, 17, 244, 252, 154, 145, 235, 17, 47, 6, 72, 229, 143, 59, 194, 124, 213, 166, 30, 181, 138, 164, 157, 133, 214, 247, 38, 17, 24, 38, 7 }, new byte[] { 206, 85, 27, 72, 208, 172, 149, 153, 122, 74, 155, 172, 127, 85, 35, 148, 88, 123, 143, 195, 11, 29, 5, 235, 45, 109, 194, 94, 77, 123, 128, 119, 249, 213, 190, 50, 4, 243, 198, 12, 244, 77, 101, 25, 242, 151, 34, 107, 89, 143, 205, 56, 211, 26, 221, 142, 104, 239, 79, 49, 214, 64, 164, 193, 194, 178, 24, 62, 145, 142, 101, 219, 118, 106, 132, 141, 205, 208, 190, 19, 245, 222, 183, 204, 192, 82, 225, 67, 207, 222, 155, 190, 86, 105, 23, 124, 46, 240, 7, 249, 78, 154, 189, 36, 226, 210, 255, 215, 181, 89, 128, 208, 174, 17, 178, 174, 154, 47, 186, 39, 217, 6, 2, 74, 237, 237, 106, 113 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PercentYes",
                table: "ParticipationResults",
                type: "int",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PercentNo",
                table: "ParticipationResults",
                type: "int",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 204, 26, 165, 111, 168, 7, 127, 151, 240, 43, 127, 19, 144, 120, 84, 51, 139, 59, 25, 31, 153, 83, 62, 98, 228, 248, 212, 133, 193, 143, 13, 23, 191, 240, 207, 227, 236, 8, 53, 136, 171, 193, 87, 231, 128, 154, 152, 154, 178, 77, 137, 15, 249, 193, 21, 74, 21, 211, 126, 228, 242, 68, 240, 148 }, new byte[] { 206, 105, 78, 58, 50, 70, 183, 228, 236, 220, 254, 158, 254, 229, 134, 180, 179, 87, 233, 144, 78, 50, 101, 23, 13, 126, 137, 160, 165, 149, 179, 234, 161, 158, 218, 229, 73, 189, 206, 198, 245, 208, 194, 20, 66, 134, 74, 75, 62, 239, 120, 237, 120, 55, 182, 59, 172, 75, 118, 65, 91, 231, 131, 92, 65, 55, 142, 91, 65, 222, 68, 24, 149, 72, 99, 197, 45, 220, 122, 48, 13, 207, 149, 100, 128, 231, 196, 225, 223, 144, 161, 54, 201, 59, 72, 56, 188, 117, 102, 126, 215, 184, 173, 65, 139, 228, 146, 200, 77, 84, 23, 220, 81, 91, 47, 30, 119, 32, 204, 106, 171, 210, 187, 68, 140, 74, 165, 126 } });
        }
    }
}
