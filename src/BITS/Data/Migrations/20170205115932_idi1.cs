using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BITS.Data.Migrations
{
    public partial class idi1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IssueDescriptionItem_IssueDescriptionItem_IssueDescriptionItemID",
                table: "IssueDescriptionItem");

            migrationBuilder.DropIndex(
                name: "IX_IssueDescriptionItem_IssueDescriptionItemID",
                table: "IssueDescriptionItem");

            migrationBuilder.DropColumn(
                name: "IssueDescriptionItemID",
                table: "IssueDescriptionItem");

            migrationBuilder.AddColumn<int>(
                name: "ParentID",
                table: "IssueDescriptionItem",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_IssueDescriptionItem_ParentID",
                table: "IssueDescriptionItem",
                column: "ParentID");

            migrationBuilder.AddForeignKey(
                name: "FK_IssueDescriptionItem_IssueDescriptionItem_ParentID",
                table: "IssueDescriptionItem",
                column: "ParentID",
                principalTable: "IssueDescriptionItem",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IssueDescriptionItem_IssueDescriptionItem_ParentID",
                table: "IssueDescriptionItem");

            migrationBuilder.DropIndex(
                name: "IX_IssueDescriptionItem_ParentID",
                table: "IssueDescriptionItem");

            migrationBuilder.DropColumn(
                name: "ParentID",
                table: "IssueDescriptionItem");

            migrationBuilder.AddColumn<int>(
                name: "IssueDescriptionItemID",
                table: "IssueDescriptionItem",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_IssueDescriptionItem_IssueDescriptionItemID",
                table: "IssueDescriptionItem",
                column: "IssueDescriptionItemID");

            migrationBuilder.AddForeignKey(
                name: "FK_IssueDescriptionItem_IssueDescriptionItem_IssueDescriptionItemID",
                table: "IssueDescriptionItem",
                column: "IssueDescriptionItemID",
                principalTable: "IssueDescriptionItem",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
