using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Kahla.Server.Migrations
{
    public partial class CreateGroupName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ConversationCreateTime",
                table: "Conversation",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GroupImage",
                table: "Conversation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GroupName",
                table: "Conversation",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GroupImage",
                table: "Conversation");

            migrationBuilder.DropColumn(
                name: "GroupName",
                table: "Conversation");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ConversationCreateTime",
                table: "Conversation",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
