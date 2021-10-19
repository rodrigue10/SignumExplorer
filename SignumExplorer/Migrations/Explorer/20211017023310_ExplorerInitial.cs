using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignumExplorer.Migrations.Explorer
{
    public partial class ExplorerInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "multi_out_transaction",
                columns: table => new
                {
                    db_id = table.Column<long>(type: "bigint(20)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    id = table.Column<long>(type: "bigint(20)", nullable: false),
                    amount = table.Column<long>(type: "bigint(20)", nullable: false),
                    total_amount = table.Column<long>(type: "bigint(20)", nullable: false),
                    Fee = table.Column<long>(type: "bigint", nullable: false),
                    height = table.Column<int>(type: "int(11)", nullable: false),
                    timestamp = table.Column<int>(type: "int(11)", nullable: false),
                    type = table.Column<sbyte>(type: "tinyint(4)", nullable: false),
                    subtype = table.Column<sbyte>(type: "tinyint(4)", nullable: false),
                    sender_id = table.Column<long>(type: "bigint(20)", nullable: false),
                    recipient_id = table.Column<long>(type: "bigint(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.db_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateIndex(
                name: "transaction_height_timestamp",
                table: "multi_out_transaction",
                columns: new[] { "height", "timestamp" });

            migrationBuilder.CreateIndex(
                name: "transaction_id_idx",
                table: "multi_out_transaction",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "transaction_recipient_id_amount_height_idx",
                table: "multi_out_transaction",
                columns: new[] { "recipient_id", "amount", "height" });

            migrationBuilder.CreateIndex(
                name: "transaction_recipient_id_idx",
                table: "multi_out_transaction",
                column: "recipient_id");

            migrationBuilder.CreateIndex(
                name: "transaction_sender_id_idx",
                table: "multi_out_transaction",
                column: "sender_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "multi_out_transaction");
        }
    }
}
