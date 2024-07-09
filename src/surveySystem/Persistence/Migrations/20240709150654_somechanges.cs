using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class somechanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "PercentNo",
                table: "ParticipationResults",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PercentYes",
                table: "ParticipationResults",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TotalNoAnswer",
                table: "ParticipationResults",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalYesAnswer",
                table: "ParticipationResults",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 168, 185, 6, 106, 179, 241, 219, 111, 96, 94, 194, 142, 250, 55, 9, 107, 9, 198, 165, 241, 167, 85, 29, 142, 75, 102, 216, 203, 36, 80, 125, 213, 113, 199, 7, 18, 248, 75, 63, 104, 218, 246, 70, 3, 88, 55, 80, 92, 176, 17, 156, 73, 242, 108, 161, 239, 162, 72, 171, 140, 253, 79, 178, 11 }, new byte[] { 46, 138, 248, 116, 52, 70, 44, 238, 76, 70, 96, 73, 175, 115, 133, 125, 106, 133, 176, 33, 223, 48, 159, 121, 92, 190, 168, 14, 88, 164, 202, 147, 0, 246, 157, 246, 112, 152, 190, 28, 41, 107, 93, 141, 2, 102, 184, 98, 203, 216, 42, 68, 202, 247, 12, 235, 92, 152, 255, 142, 166, 84, 126, 107, 95, 177, 213, 90, 164, 51, 241, 150, 244, 214, 182, 119, 25, 4, 186, 210, 190, 22, 29, 72, 31, 98, 82, 25, 243, 176, 64, 199, 165, 7, 79, 225, 214, 108, 34, 140, 195, 191, 194, 90, 164, 6, 236, 133, 6, 67, 171, 151, 158, 218, 98, 133, 119, 78, 95, 34, 21, 168, 161, 17, 27, 255, 164, 108 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PercentNo",
                table: "ParticipationResults");

            migrationBuilder.DropColumn(
                name: "PercentYes",
                table: "ParticipationResults");

            migrationBuilder.DropColumn(
                name: "TotalNoAnswer",
                table: "ParticipationResults");

            migrationBuilder.DropColumn(
                name: "TotalYesAnswer",
                table: "ParticipationResults");

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
    }
}
