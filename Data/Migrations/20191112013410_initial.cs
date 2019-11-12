using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_CONTACT",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    NAME = table.Column<string>(nullable: true),
                    PHONE_NUMBER = table.Column<string>(nullable: true),
                    EMAIL = table.Column<string>(nullable: true),
                    SUBJECT = table.Column<string>(nullable: true),
                    MESSAGE = table.Column<string>(nullable: true),
                    AddedIn = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CONTACT", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_LANGUAGE",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CODE = table.Column<string>(nullable: true),
                    NAME = table.Column<string>(nullable: true),
                    IMAGE = table.Column<string>(nullable: true),
                    ACTIVE = table.Column<bool>(nullable: false),
                    DEFAULT = table.Column<bool>(nullable: false),
                    LOADED = table.Column<bool>(nullable: false),
                    AddedIn = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_LANGUAGE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_PERSON",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    NOME = table.Column<string>(nullable: true),
                    CPF = table.Column<string>(nullable: true),
                    EMAIL = table.Column<string>(nullable: true),
                    TELEFONE = table.Column<string>(nullable: true),
                    DATA_NASCIMENTO = table.Column<DateTime>(nullable: false),
                    AddedIn = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PERSON", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_CONTACT");

            migrationBuilder.DropTable(
                name: "TB_LANGUAGE");

            migrationBuilder.DropTable(
                name: "TB_PERSON");
        }
    }
}
