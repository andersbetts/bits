using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BITS.Migrations
{
    public partial class currencySymbol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Symbol",
                table: "Currency",
                maxLength: 5,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Acronym",
                table: "Currency",
                maxLength: 10,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Symbol",
                table: "Currency");

            migrationBuilder.AlterColumn<string>(
                name: "Acronym",
                table: "Currency",
                maxLength: 4,
                nullable: true);
        }
    }
}
