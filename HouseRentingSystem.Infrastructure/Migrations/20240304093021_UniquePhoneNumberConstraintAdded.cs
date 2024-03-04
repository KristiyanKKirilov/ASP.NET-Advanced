using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Infrastructure.Migrations
{
    public partial class UniquePhoneNumberConstraintAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "481cec1b-c3e0-45bc-8bca-c57371f91e9e", "AQAAAAEAACcQAAAAEO8xQcMQu/qHQruybTVjnRS0P40QpNYnWSz1zlNy94atlM8+7gAe8c6gZquKPt0JwA==", "440f41d4-6367-49b9-a0f7-fb86b5f1c482" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a9243b04-fd53-4799-a8f5-3cffe6ac5c69", "AQAAAAEAACcQAAAAEK7mI/MuNxpCQkcWkx0kDWI8ADa63KaxxK8Ewdv6346eNoQJGL+yofCHLx/lIk296A==", "91207c66-c4f7-436e-a6fe-6e3f6ad9b268" });

            migrationBuilder.CreateIndex(
                name: "IX_Agents_PhoneNumber",
                table: "Agents",
                column: "PhoneNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Agents_PhoneNumber",
                table: "Agents");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e750e0b5-6712-4c23-b7ec-a2465cbb2017", "AQAAAAEAACcQAAAAEJ84kbm70tW+hr+0n4Hi5SEQNz+m5s09KXjOnSk7umn3StQ9veGSjYaXKfWdnNWMug==", "163c7947-4509-46ee-9cd8-3a44c8e5f02c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e83b89ae-564e-466f-9dd0-d880b58905bf", "AQAAAAEAACcQAAAAEJqcWnJEAdfe0jbdsYd6tyt3t4UtO3zfjIZnV9/icGF4K+E7eeMhwAWufZPjjku1ig==", "56217228-1d2f-46bd-865f-363018b8faf5" });
        }
    }
}
