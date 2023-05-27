using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task.Shared.Migrations
{
    /// <inheritdoc />
    public partial class AddOtpIntoApplicatoinUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Otp",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Otp",
                table: "AspNetUsers");
        }
    }
}
