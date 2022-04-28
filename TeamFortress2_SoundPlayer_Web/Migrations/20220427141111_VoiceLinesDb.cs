using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeamFortress2_SoundPlayer_Web.Migrations
{
    public partial class VoiceLinesDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administrator_Responses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Chategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Changer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubChategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubSubChategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Line = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrator_Responses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DavyJones_Responses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Chategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Changer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubChategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubSubChategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Line = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DavyJones_Responses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Demoman_Responses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Chategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Changer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubChategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubSubChategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Line = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Demoman_Responses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Demoman_VoiceCommands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Chategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubChategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubSubChategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Line = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Demoman_VoiceCommands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Engineer_Responses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Chategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Changer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubChategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubSubChategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Line = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engineer_Responses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Engineer_VoiceCommands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Chategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubChategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubSubChategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Line = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engineer_VoiceCommands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HalloweenBosses_Responses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Chategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Changer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubChategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubSubChategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Line = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HalloweenBosses_Responses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Heavy_Responses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Chategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Changer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubChategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubSubChategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Line = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Heavy_Responses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Heavy_VoiceCommands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Chategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubChategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubSubChategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Line = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Heavy_VoiceCommands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medic_Responses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Chategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Changer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubChategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubSubChategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Line = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medic_Responses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medic_VoiceCommands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Chategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubChategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubSubChategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Line = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medic_VoiceCommands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MissPauling_Responses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Chategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Changer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubChategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubSubChategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Line = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MissPauling_Responses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pyro_Responses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Chategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Changer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubChategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubSubChategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Line = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pyro_Responses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pyro_VoiceCommands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Chategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubChategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubSubChategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Line = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pyro_VoiceCommands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Scout_Responses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Chategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Changer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubChategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubSubChategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Line = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scout_Responses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Scout_VoiceCommands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Chategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubChategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubSubChategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Line = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scout_VoiceCommands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sniper_Responses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Chategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Changer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubChategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubSubChategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Line = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sniper_Responses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sniper_VoiceCommands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Chategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubChategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubSubChategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Line = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sniper_VoiceCommands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Soldier_Responses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Chategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Changer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubChategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubSubChategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Line = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Soldier_Responses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Soldier_VoiceCommands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Chategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubChategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubSubChategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Line = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Soldier_VoiceCommands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Spy_Responses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Chategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Changer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubChategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubSubChategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Line = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spy_Responses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Spy_VoiceCommands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Chategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubChategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubSubChategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Line = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spy_VoiceCommands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wheatley_Responses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Chategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Changer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubChategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubSubChategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Line = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wheatley_Responses", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrator_Responses");

            migrationBuilder.DropTable(
                name: "DavyJones_Responses");

            migrationBuilder.DropTable(
                name: "Demoman_Responses");

            migrationBuilder.DropTable(
                name: "Demoman_VoiceCommands");

            migrationBuilder.DropTable(
                name: "Engineer_Responses");

            migrationBuilder.DropTable(
                name: "Engineer_VoiceCommands");

            migrationBuilder.DropTable(
                name: "HalloweenBosses_Responses");

            migrationBuilder.DropTable(
                name: "Heavy_Responses");

            migrationBuilder.DropTable(
                name: "Heavy_VoiceCommands");

            migrationBuilder.DropTable(
                name: "Medic_Responses");

            migrationBuilder.DropTable(
                name: "Medic_VoiceCommands");

            migrationBuilder.DropTable(
                name: "MissPauling_Responses");

            migrationBuilder.DropTable(
                name: "Pyro_Responses");

            migrationBuilder.DropTable(
                name: "Pyro_VoiceCommands");

            migrationBuilder.DropTable(
                name: "Scout_Responses");

            migrationBuilder.DropTable(
                name: "Scout_VoiceCommands");

            migrationBuilder.DropTable(
                name: "Sniper_Responses");

            migrationBuilder.DropTable(
                name: "Sniper_VoiceCommands");

            migrationBuilder.DropTable(
                name: "Soldier_Responses");

            migrationBuilder.DropTable(
                name: "Soldier_VoiceCommands");

            migrationBuilder.DropTable(
                name: "Spy_Responses");

            migrationBuilder.DropTable(
                name: "Spy_VoiceCommands");

            migrationBuilder.DropTable(
                name: "Wheatley_Responses");
        }
    }
}
