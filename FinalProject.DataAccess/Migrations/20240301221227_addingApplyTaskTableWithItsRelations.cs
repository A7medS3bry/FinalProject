using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Migrations
{
    /// <inheritdoc />
    public partial class addingApplyTaskTableWithItsRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contract_AspNetUsers_ApplicationUserId",
                table: "Contract");

            migrationBuilder.DropForeignKey(
                name: "FK_Contract_AspNetUsers_ClientId",
                table: "Contract");

            migrationBuilder.DropForeignKey(
                name: "FK_Contract_AspNetUsers_FreelancerId",
                table: "Contract");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_AspNetUsers_ApplicationUserId",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_AspNetUsers_ClientId",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_AspNetUsers_FreelancerId",
                table: "Review");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Review",
                table: "Review");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contract",
                table: "Contract");

            migrationBuilder.RenameTable(
                name: "Review",
                newName: "Reviews");

            migrationBuilder.RenameTable(
                name: "Contract",
                newName: "Contracts");

            migrationBuilder.RenameIndex(
                name: "IX_Review_FreelancerId",
                table: "Reviews",
                newName: "IX_Reviews_FreelancerId");

            migrationBuilder.RenameIndex(
                name: "IX_Review_ClientId",
                table: "Reviews",
                newName: "IX_Reviews_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Review_ApplicationUserId",
                table: "Reviews",
                newName: "IX_Reviews_ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Contract_FreelancerId",
                table: "Contracts",
                newName: "IX_Contracts_FreelancerId");

            migrationBuilder.RenameIndex(
                name: "IX_Contract_ClientId",
                table: "Contracts",
                newName: "IX_Contracts_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Contract_ApplicationUserId",
                table: "Contracts",
                newName: "IX_Contracts_ApplicationUserId");

            migrationBuilder.AddColumn<int>(
                name: "ApplyTaskId",
                table: "Reviews",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Reviews",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Contracts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contracts",
                table: "Contracts",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ApplyTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    JobPostId = table.Column<int>(type: "int", nullable: false),
                    FreelancerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClientId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ReviewId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplyTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplyTasks_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApplyTasks_AspNetUsers_ClientId",
                        column: x => x.ClientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ApplyTasks_AspNetUsers_FreelancerId",
                        column: x => x.FreelancerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ApplyTasks_JobPosts_JobPostId",
                        column: x => x.JobPostId,
                        principalTable: "JobPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ApplyTaskId",
                table: "Reviews",
                column: "ApplyTaskId",
                unique: true,
                filter: "[ApplyTaskId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ApplyTasks_ApplicationUserId",
                table: "ApplyTasks",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplyTasks_ClientId",
                table: "ApplyTasks",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplyTasks_FreelancerId",
                table: "ApplyTasks",
                column: "FreelancerId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplyTasks_JobPostId",
                table: "ApplyTasks",
                column: "JobPostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_AspNetUsers_ApplicationUserId",
                table: "Contracts",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_AspNetUsers_ClientId",
                table: "Contracts",
                column: "ClientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_AspNetUsers_FreelancerId",
                table: "Contracts",
                column: "FreelancerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_ApplyTasks_ApplyTaskId",
                table: "Reviews",
                column: "ApplyTaskId",
                principalTable: "ApplyTasks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_AspNetUsers_ApplicationUserId",
                table: "Reviews",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_AspNetUsers_ClientId",
                table: "Reviews",
                column: "ClientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_AspNetUsers_FreelancerId",
                table: "Reviews",
                column: "FreelancerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_AspNetUsers_ApplicationUserId",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_AspNetUsers_ClientId",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_AspNetUsers_FreelancerId",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_ApplyTasks_ApplyTaskId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_AspNetUsers_ApplicationUserId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_AspNetUsers_ClientId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_AspNetUsers_FreelancerId",
                table: "Reviews");

            migrationBuilder.DropTable(
                name: "ApplyTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_ApplyTaskId",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contracts",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "ApplyTaskId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Contracts");

            migrationBuilder.RenameTable(
                name: "Reviews",
                newName: "Review");

            migrationBuilder.RenameTable(
                name: "Contracts",
                newName: "Contract");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_FreelancerId",
                table: "Review",
                newName: "IX_Review_FreelancerId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_ClientId",
                table: "Review",
                newName: "IX_Review_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_ApplicationUserId",
                table: "Review",
                newName: "IX_Review_ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Contracts_FreelancerId",
                table: "Contract",
                newName: "IX_Contract_FreelancerId");

            migrationBuilder.RenameIndex(
                name: "IX_Contracts_ClientId",
                table: "Contract",
                newName: "IX_Contract_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Contracts_ApplicationUserId",
                table: "Contract",
                newName: "IX_Contract_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Review",
                table: "Review",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contract",
                table: "Contract",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contract_AspNetUsers_ApplicationUserId",
                table: "Contract",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contract_AspNetUsers_ClientId",
                table: "Contract",
                column: "ClientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contract_AspNetUsers_FreelancerId",
                table: "Contract",
                column: "FreelancerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_AspNetUsers_ApplicationUserId",
                table: "Review",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_AspNetUsers_ClientId",
                table: "Review",
                column: "ClientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_AspNetUsers_FreelancerId",
                table: "Review",
                column: "FreelancerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
