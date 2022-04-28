
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SignumExplorer.Models;


namespace SignumExplorer.Context;
public partial class ExplorerContext : DbContext
{
 
    private readonly IConfiguration? _configuration;
    private string? ConnectionString { get; }
    private string? ServerVers { get; }

    public ExplorerContext(DbContextOptions<ExplorerContext> options, IConfiguration configuration)
        : base(options)
    {
        this._configuration = configuration;
        ConnectionString = this._configuration.GetConnectionString("ExplorerConnection");
        ServerVers = this._configuration.GetSection("MariaDBSettings")["Version"];

    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {

            optionsBuilder.UseMySql(ConnectionString, ServerVersion.Parse(ServerVers));
        }
    }

    public virtual DbSet<MultiOutTransaction> MultiOutTransactions { get; set; } = null!;
    public virtual DbSet<PoolWonBlock> PoolWonBlocks { get; set; } = null!;
    public virtual DbSet<CoinGecko> CoinGeckos { get; set; } = null!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<MultiOutTransaction>(entity =>
        {
            entity.HasKey(e => e.DbId)
                .HasName("PRIMARY");

            entity.ToTable("multi_out_transaction");

            entity.UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => new { e.Height, e.Timestamp }, "transaction_height_timestamp");

            entity.HasIndex(e => e.Id, "transaction_id_idx")
                .IsUnique();

            entity.HasIndex(e => new { e.RecipientId, e.Amount, e.Height }, "transaction_recipient_id_amount_height_idx");

            entity.HasIndex(e => e.RecipientId, "transaction_recipient_id_idx");

            entity.HasIndex(e => e.SenderId, "transaction_sender_id_idx");

            entity.Property(e => e.DbId)
                .HasColumnType("bigint(20)")
                .HasColumnName("db_id");

            entity.Property(e => e.Amount)
                .HasColumnType("bigint(20)")
                .HasColumnName("amount");

            entity.Property(e => e.TotalAmount)
                .HasColumnType("bigint(20)")
                .HasColumnName("total_amount");

            entity.Property(e => e.Height)
                .HasColumnType("int(11)")
                .HasColumnName("height");

            entity.Property(e => e.Id)
                .HasColumnType("bigint(20)")
                .HasColumnName("id");

            entity.Property(e => e.RecipientId)
                .HasColumnType("bigint(20)")
                .HasColumnName("recipient_id");


            entity.Property(e => e.SenderId)
                .HasColumnType("bigint(20)")
                .HasColumnName("sender_id");

            entity.Property(e => e.Subtype)
                .HasColumnType("tinyint(4)")
                .HasColumnName("subtype");

            entity.Property(e => e.Timestamp)
                .HasColumnType("int(11)")
                .HasColumnName("timestamp");

            entity.Property(e => e.Type)
                .HasColumnType("tinyint(4)")
                .HasColumnName("type");

        });
        modelBuilder.Entity<PoolWonBlock>(entity =>
        {
            entity.HasKey(e => e.Height)
                .HasName("PRIMARY");

            entity.ToTable("pool_won_block");

            entity.UseCollation("utf8mb4_unicode_ci");
              
            entity.HasIndex(e => e.Height, "poolwonblock_id_idx")
                .IsUnique();

            entity.Property(e => e.Height)
                .HasColumnType("int(11)")
                .HasColumnName("height")
                .ValueGeneratedNever(); 

            entity.Property(e => e.GeneratorId)
                .HasColumnType("bigint(20)")
                .HasColumnName("generator_id");

            entity.Property(e => e.PoolId)
                .HasColumnType("bigint(20)")
                .HasColumnName("pool_id");
              

        });
        modelBuilder.Entity<CoinGecko>(entity =>
        {
            entity.HasKey(e => e.DbId)
                .HasName("PRIMARY");

            entity.ToTable("coin_gecko");

            entity.UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.DbId, "coin_gecko_id_idx")
                .IsUnique();

        entity.Property(e => e.Btc).HasColumnType("double").HasColumnName("btc");
        entity.Property(e => e.BtcMarketCap).HasColumnType("double").HasColumnName("btc_market_cap");
        entity.Property(e => e.Btc24hChange).HasColumnType("double").HasColumnName("btc_24h_change");
        entity.Property(e => e.Usd).HasColumnType("double").HasColumnName("usd");
        entity.Property(e => e.UsdMarketCap).HasColumnType("double").HasColumnName("usd_market_cap");
        entity.Property(e => e.Usd24hChange).HasColumnType("double").HasColumnName("usd_24h_change");
        entity.Property(e => e.Btc24hVol).HasColumnType("double").HasColumnName("btc_24h_vol");
        entity.Property(e => e.Usd24hVol).HasColumnType("double").HasColumnName("usd_24h_vol");
        entity.Property(e => e.LastUpdatedAt).HasColumnType("int(11)").HasColumnName("last_updated_at");

        });



        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


}
