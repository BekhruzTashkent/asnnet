using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace myFirstApp.Migrations
{
    /// <inheritdoc />
    public partial class FixPhoneNumberAddition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "phoneNumber",
                table: "Users",
                type: "varchar(255)",  
                nullable: true);  
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "phoneNumber",
                table: "Users");
        }
    }
}
