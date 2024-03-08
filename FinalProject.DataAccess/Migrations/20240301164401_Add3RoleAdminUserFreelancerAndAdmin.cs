using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Migrations
{
    /// <inheritdoc />
    public partial class Add3RoleAdminUserFreelancerAndAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
                values: new object[] { Guid.NewGuid().ToString(), "User", "USER", Guid.NewGuid().ToString() }
                );

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
                values: new object[] { Guid.NewGuid().ToString(), "Admin", "ADMIN", Guid.NewGuid().ToString() }
            );
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
                values: new object[] { Guid.NewGuid().ToString(), "Freelancer", "FREELANCER", Guid.NewGuid().ToString() }
            );

            migrationBuilder.Sql("INSERT INTO [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [ProfilePicture], [YourTitle], [Description], [Education], [Experience], [HourlyRate], [Age], [ZIP], [CodePhone], [Address], [PortfolioURl], [RegistrationDate], [LastActive], [ActiveOrNot], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [CountryId], [IsDeleted]) VALUES (N'be258344-4614-4f6c-b431-e1a161b2bd26', N'Ahmed', N'Sabry', NULL, N'Admin', N'Admin For WebSite', N'', NULL, NULL, 22, NULL, NULL, NULL, NULL, N'2024-03-01 01:57:58', N'2024-03-01 01:57:58', NULL, N'Admin', NULL, N'Admin@admin.com', N'Admin@admin.com', 1, N'AQAAAAIAAYagAAAAEKc1LMUQd/FSw5vbF0Tr0gMJ5bjJfXxeGTpOMqmzzmMN0hd9fEPkDQ9DX1QHBMTM7A==', N'IRFRI3NDMYVOP2BGVA5OGX3B3PISGJR3', N'1c10ae22-896d-4a72-ab98-837a586eaaec', N'01096536103', 0, 0, NULL, 1, 0, 1, 0)\r\n");

            migrationBuilder.Sql("INSERT INTO [AspNetUserRoles] (UserId, RoleId) SELECT 'be258344-4614-4f6c-b431-e1a161b2bd26', Id FROM [AspNetRoles]");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [AspNetRoles]");

            migrationBuilder.Sql("DELETE FROM [AspNetUsers] WHERE UserId = 'be258344-4614-4f6c-b431-e1a161b2bd26'");

            migrationBuilder.Sql("DELETE FROM [AspNetUserRoles] WHERE UserId = 'be258344-4614-4f6c-b431-e1a161b2bd26'");

        }
    }
}
