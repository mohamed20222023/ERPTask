using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskERP.DAL.Migrations
{
    public partial class UpdateOnDataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "0d8278a1-0447-474d-a7a6-0c726c6aa95e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7211",
                column: "ConcurrencyStamp",
                value: "ff0f3614-b53d-4ca6-b847-48da89e91f36");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { "80236f9c-6c1c-4547-b9e3-5f0b62ed6664", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEDbIQzLiMWvhDlCNIQLrhUp8aQtExZv/5k0/jb+Bwe/Qcp9eTTLqnzb2vJj+PO+mIw==", "b29700ca-7ecd-4ae8-872c-30d8e25bb3ed" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c7c5c16d-9077-4e5b-9916-6361fd73a0c5", null, "AQAAAAEAACcQAAAAEAGhErQRAg8cdL9XG/BHVDOv2CqYC8KTpywvzxFeRmOs0EE7E4aCPkeGnsgilCSflg==", "49fc8eb5-83dc-476f-9e35-d8a93f80bb78" });
        }
    }
}
