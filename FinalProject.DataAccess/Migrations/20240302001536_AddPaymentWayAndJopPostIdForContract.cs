using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Migrations
{
    /// <inheritdoc />
    public partial class AddPaymentWayAndJopPostIdForContract : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "JopPostId",
                table: "Contracts",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PaymentWay",
                table: "Contracts",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_JopPostId",
                table: "Contracts",
                column: "JopPostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_JobPosts_JopPostId",
                table: "Contracts",
                column: "JopPostId",
                principalTable: "JobPosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_JobPosts_JopPostId",
                table: "Contracts");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_JopPostId",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "JopPostId",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "PaymentWay",
                table: "Contracts");
        }
    }
}
