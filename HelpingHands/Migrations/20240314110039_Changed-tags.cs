using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelpingHands.Migrations
{
    /// <inheritdoc />
    public partial class Changedtags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TagsString",
                table: "WorkerProfile_CLASS",
                newName: "Tags");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tags",
                table: "WorkerProfile_CLASS",
                newName: "TagsString");
        }
    }
}
