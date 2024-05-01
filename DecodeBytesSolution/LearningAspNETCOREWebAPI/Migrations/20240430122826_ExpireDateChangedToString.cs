using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningAspNETCOREWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class ExpireDateChangedToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ExpireDate",
                table: "Cards",
                type: "TEXT",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ExpireDate",
                table: "Cards",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 5);
        }
    }
}
