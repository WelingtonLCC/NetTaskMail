using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Sender.InfraData.Migrations
{
    /// <inheritdoc />
    public partial class InitialSender : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SenderConfigDomain",
                columns: table => new
                {
                    Sender_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Sender_user = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Sender_smtp = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Sender_password = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Sender_port = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SenderConfigDomain", x => x.Sender_id);
                });

            migrationBuilder.CreateTable(
                name: "SenderMailDomain",
                columns: table => new
                {
                    Sender_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Sender_title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Sender_email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Sender_message = table.Column<string>(type: "character varying(999)", maxLength: 999, nullable: false),
                    senderConfigDomainSender_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SenderMailDomain", x => x.Sender_id);
                    table.ForeignKey(
                        name: "FK_SenderMailDomain_SenderConfigDomain_senderConfigDomainSende~",
                        column: x => x.senderConfigDomainSender_id,
                        principalTable: "SenderConfigDomain",
                        principalColumn: "Sender_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "SenderConfigDomain",
                columns: new[] { "Sender_id", "Sender_password", "Sender_port", "Sender_smtp", "Sender_user" },
                values: new object[] { 1, "We@172839", "587", "smtp.futurasistemas.com.br", "welington.campos@futurasistemas.com.br" });

            migrationBuilder.CreateIndex(
                name: "IX_SenderMailDomain_senderConfigDomainSender_id",
                table: "SenderMailDomain",
                column: "senderConfigDomainSender_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SenderMailDomain");

            migrationBuilder.DropTable(
                name: "SenderConfigDomain");
        }
    }
}
