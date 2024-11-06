using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ZeFiveNime.Migrations
{
    /// <inheritdoc />
    public partial class intialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Judul = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Tahun = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Sinopsis = table.Column<string>(type: "text", nullable: false),
                    PosterByte = table.Column<byte[]>(type: "bytea", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Episode",
                columns: table => new
                {
                    Id_Episode = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Judul_Episode = table.Column<string>(type: "text", nullable: false),
                    Durasi = table.Column<int>(type: "integer", nullable: false),
                    UploadTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Id_Animation = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Episode", x => x.Id_Episode);
                    table.ForeignKey(
                        name: "FK_Episode_Animation_Id_Animation",
                        column: x => x.Id_Animation,
                        principalTable: "Animation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Source",
                columns: table => new
                {
                    Id_Source = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name_Source = table.Column<string>(type: "text", nullable: false),
                    SourceOne = table.Column<string>(type: "text", nullable: true),
                    SourceTwo = table.Column<string>(type: "text", nullable: true),
                    SourceThree = table.Column<string>(type: "text", nullable: true),
                    Episode_SourceId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Source", x => x.Id_Source);
                    table.ForeignKey(
                        name: "FK_Source_Episode_Episode_SourceId",
                        column: x => x.Episode_SourceId,
                        principalTable: "Episode",
                        principalColumn: "Id_Episode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Episode_Id_Animation",
                table: "Episode",
                column: "Id_Animation");

            migrationBuilder.CreateIndex(
                name: "IX_Source_Episode_SourceId",
                table: "Source",
                column: "Episode_SourceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Source");

            migrationBuilder.DropTable(
                name: "Episode");

            migrationBuilder.DropTable(
                name: "Animation");
        }
    }
}
