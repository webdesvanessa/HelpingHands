using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelpingHands.Migrations
{
    /// <inheritdoc />
    public partial class CreatedtagsonWorkerProfile_CLASS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TagsString",
                table: "WorkerProfile_CLASS",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TagsString",
                table: "WorkerProfile_CLASS");
        }
    }
}
