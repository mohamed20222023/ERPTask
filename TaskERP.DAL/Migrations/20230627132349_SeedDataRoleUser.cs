using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskERP.DAL.Migrations
{
    public partial class SeedDataRoleUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "b2261b72-c852-4470-ab71-57b508186228");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2c5e174e-3b0e-446f-86af-483d56fd7211", "24255944-c689-4aba-ba65-26f473be84d6", "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "82904bd3-3498-40db-af21-e26023112f69", "AQAAAAEAACcQAAAAEP+lgR34UbbK2jzC3w2AnatB2kisGbe9002f56VUAdd7dVPuPm+jLtq2nkRveodI8g==", "7e180a05-b85e-4e99-847c-c46624f612fa" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7211");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "60283d84-48eb-4dba-b8c7-f6b9922949ea");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a7cefadf-ce4d-43b1-b4d8-62398365ce91", "AQAAAAEAACcQAAAAEBU9p1TEMVp929w/kquAdE+HeeXr8049Pow4PXdVkpjQBORmqLS80u1bjuGJ0X10zw==", "d96ed36e-ffc4-4750-8e0f-489ecbbdb30c" });
        }
    }
}
