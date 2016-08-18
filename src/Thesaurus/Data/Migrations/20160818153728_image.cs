using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Thesaurus.Data.Migrations
{
    public partial class image : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "imageID",
                table: "Vocabulary",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vocabulary_imageID",
                table: "Vocabulary",
                column: "imageID");

            migrationBuilder.AddForeignKey(
                name: "FK_Vocabulary_Image_imageID",
                table: "Vocabulary",
                column: "imageID",
                principalTable: "Image",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vocabulary_Image_imageID",
                table: "Vocabulary");

            migrationBuilder.DropIndex(
                name: "IX_Vocabulary_imageID",
                table: "Vocabulary");

            migrationBuilder.DropColumn(
                name: "imageID",
                table: "Vocabulary");
        }
    }
}
