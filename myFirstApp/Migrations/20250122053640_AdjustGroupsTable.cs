using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace myFirstApp.Migrations
{
    /// <inheritdoc />
    public partial class AdjustGroupsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                    name: "Id",
                    table: "Groups",
                    nullable: false,
                    oldClrType: typeof(int),
                    oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy",
                    Npgsql.EntityFrameworkCore.PostgreSQL.Metadata
                        .NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                    name: "Id",
                    table: "Groups",
                    nullable: false,
                    oldClrType: typeof(int),
                    oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", 
                    Npgsql.EntityFrameworkCore.PostgreSQL.Metadata.NpgsqlValueGenerationStrategy
                        .IdentityByDefaultColumn);
        }
    }
}
