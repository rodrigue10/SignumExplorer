using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignumExplorer.Migrations.Explorer
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "coin_gecko",
                columns: table => new
                {
                    DbId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    btc = table.Column<double>(type: "double", nullable: false),
                    btc_market_cap = table.Column<double>(type: "double", nullable: false),
                    btc_24h_vol = table.Column<double>(type: "double", nullable: false),
                    btc_24h_change = table.Column<double>(type: "double", nullable: false),
                    usd = table.Column<double>(type: "double", nullable: false),
                    usd_market_cap = table.Column<double>(type: "double", nullable: false),
                    usd_24h_vol = table.Column<double>(type: "double", nullable: false),
                    usd_24h_change = table.Column<double>(type: "double", nullable: false),
                    last_updated_at = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.DbId);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

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

            migrationBuilder.CreateTable(
                name: "pool_won_block",
                columns: table => new
                {
                    height = table.Column<int>(type: "int(11)", nullable: false),
                    pool_id = table.Column<long>(type: "bigint(20)", nullable: false),
                    generator_id = table.Column<long>(type: "bigint(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.height);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateIndex(
                name: "coin_gecko_id_idx",
                table: "coin_gecko",
                column: "DbId",
                unique: true);

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

            migrationBuilder.CreateIndex(
                name: "poolwonblock_id_idx",
                table: "pool_won_block",
                column: "height",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "coin_gecko");

            migrationBuilder.DropTable(
                name: "multi_out_transaction");

            migrationBuilder.DropTable(
                name: "pool_won_block");
        }
    }
}
