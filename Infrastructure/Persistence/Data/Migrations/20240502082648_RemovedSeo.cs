using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemovedSeo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Seos_SeoId",
                table: "Tags");

            migrationBuilder.DropTable(
                name: "Seos");

            migrationBuilder.DropIndex(
                name: "IX_Tags_SeoId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "SeoId",
                table: "Tags");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SeoId",
                table: "Tags",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Seos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DescAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tags_SeoId",
                table: "Tags",
                column: "SeoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Seos_SeoId",
                table: "Tags",
                column: "SeoId",
                principalTable: "Seos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
