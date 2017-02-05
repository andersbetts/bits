using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BITS.Data.Migrations
{
    public partial class issuedescriptionitems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IssueDescriptionItem",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Enabled = table.Column<bool>(nullable: false),
                    IssueDescriptionItemID = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueDescriptionItem", x => x.ID);
                    table.ForeignKey(
                        name: "FK_IssueDescriptionItem_IssueDescriptionItem_IssueDescriptionItemID",
                        column: x => x.IssueDescriptionItemID,
                        principalTable: "IssueDescriptionItem",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IssueDescriptionItem_IssueDescriptionItemID",
                table: "IssueDescriptionItem",
                column: "IssueDescriptionItemID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IssueDescriptionItem");
        }
    }
}
