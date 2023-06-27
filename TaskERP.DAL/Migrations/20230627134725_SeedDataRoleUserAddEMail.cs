using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskERP.DAL.Migrations
{
    public partial class SeedDataRoleUserAddEMail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "5a660453-3d06-4865-a526-246b6b374058");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7211",
                column: "ConcurrencyStamp",
                value: "927c1f5b-2238-4c34-a174-c2f223c0f217");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "Email", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c7c5c16d-9077-4e5b-9916-6361fd73a0c5", "Admin@admin.com", "AQAAAAEAACcQAAAAEAGhErQRAg8cdL9XG/BHVDOv2CqYC8KTpywvzxFeRmOs0EE7E4aCPkeGnsgilCSflg==", "49fc8eb5-83dc-476f-9e35-d8a93f80bb78" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "b2261b72-c852-4470-ab71-57b508186228");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7211",
                column: "ConcurrencyStamp",
                value: "24255944-c689-4aba-ba65-26f473be84d6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "Email", "PasswordHash", "SecurityStamp" },
                values: new object[] { "82904bd3-3498-40db-af21-e26023112f69", null, "AQAAAAEAACcQAAAAEP+lgR34UbbK2jzC3w2AnatB2kisGbe9002f56VUAdd7dVPuPm+jLtq2nkRveodI8g==", "7e180a05-b85e-4e99-847c-c46624f612fa" });
        }
    }
}
