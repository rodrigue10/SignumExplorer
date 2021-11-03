using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using SignumExplorer.Models;

namespace SignumExplorer.Context
{
    public partial class signumContext : DbContext
    {
        //public signumContext()
        //{
        //}

        //public signumContext(DbContextOptions<signumContext> options)
        //    : base(options)
        //{
        //}

        private readonly IConfiguration? _configuration;
        private string? ConnectionString { get; }
        private string? ServerVers { get; }

        public signumContext(DbContextOptions<signumContext> options, IConfiguration configuration)
            : base(options)
        {
            this._configuration = configuration;
            ConnectionString = this._configuration.GetConnectionString("SRSConnection");
            ServerVers = this._configuration.GetSection("MariaDBSettings")["Version"];

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseMySql(ConnectionString, ServerVersion.Parse(ServerVers));
            }
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<AccountAsset> AccountAssets { get; set; } = null!;
        public virtual DbSet<AccountAssetAssetDetail> AccountAssetAssetDetails { get; set; } = null!;
        public virtual DbSet<Alias> Aliases { get; set; } = null!;
        public virtual DbSet<AliasOffer> AliasOffers { get; set; } = null!;
        public virtual DbSet<AskOrder> AskOrders { get; set; } = null!;
        public virtual DbSet<Asset> Assets { get; set; } = null!;
        public virtual DbSet<AssetTransfer> AssetTransfers { get; set; } = null!;
        public virtual DbSet<AssetTransferAssetDetail> AssetTransferAssetDetails { get; set; } = null!;
        public virtual DbSet<At> Ats { get; set; } = null!;
        public virtual DbSet<AtState> AtStates { get; set; } = null!;
        public virtual DbSet<AtsView> AtsViews { get; set; } = null!;
        public virtual DbSet<BidOrder> BidOrders { get; set; } = null!;
        public virtual DbSet<Block> Blocks { get; set; } = null!;
        public virtual DbSet<BlockRewardRecipDesc> BlockRewardRecipDescs { get; set; } = null!;
        public virtual DbSet<EfmigrationsHistory> EfmigrationsHistories { get; set; } = null!;
        public virtual DbSet<Escrow> Escrows { get; set; } = null!;
        public virtual DbSet<EscrowDecision> EscrowDecisions { get; set; } = null!;
        public virtual DbSet<FlywaySchemaHistory> FlywaySchemaHistories { get; set; } = null!;
        public virtual DbSet<Good> Goods { get; set; } = null!;
        public virtual DbSet<IndirectIncoming> IndirectIncomings { get; set; } = null!;
        public virtual DbSet<LatestAccountRewardRecip> LatestAccountRewardRecips { get; set; } = null!;
        public virtual DbSet<LatestAskOrder> LatestAskOrders { get; set; } = null!;
        public virtual DbSet<LatestBidOrder> LatestBidOrders { get; set; } = null!;
        public virtual DbSet<MultiOutTransactionAttach> MultiOutTransactionAttaches { get; set; } = null!;
        public virtual DbSet<Peer> Peers { get; set; } = null!;
        public virtual DbSet<Purchase> Purchases { get; set; } = null!;
        public virtual DbSet<PurchaseFeedback> PurchaseFeedbacks { get; set; } = null!;
        public virtual DbSet<PurchasePublicFeedback> PurchasePublicFeedbacks { get; set; } = null!;
        public virtual DbSet<RewardRecipAssign> RewardRecipAssigns { get; set; } = null!;
        public virtual DbSet<RewardRecipNameDesc> RewardRecipNameDescs { get; set; } = null!;
        public virtual DbSet<Subscription> Subscriptions { get; set; } = null!;
        public virtual DbSet<Trade> Trades { get; set; } = null!;
        public virtual DbSet<TradeAssetDetail> TradeAssetDetails { get; set; } = null!;
        public virtual DbSet<Transaction> Transactions { get; set; } = null!;
        public virtual DbSet<TransactionAccountName> TransactionAccountNames { get; set; } = null!;
        public virtual DbSet<UnconfirmedTransaction> UnconfirmedTransactions { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.DbId)
                    .HasName("PRIMARY");

                entity.ToTable("account");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => new { e.Id, e.Balance, e.Height }, "account_id_balance_height_idx");

                entity.HasIndex(e => new { e.Id, e.Height }, "account_id_height_idx")
                    .IsUnique();

                entity.HasIndex(e => new { e.Id, e.Latest }, "account_id_latest_idx");

                entity.Property(e => e.DbId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("db_id");

                entity.Property(e => e.Balance)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("balance");

                entity.Property(e => e.CreationHeight)
                    .HasColumnType("int(11)")
                    .HasColumnName("creation_height");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.ForgedBalance)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("forged_balance");

                entity.Property(e => e.Height)
                    .HasColumnType("int(11)")
                    .HasColumnName("height");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.KeyHeight)
                    .HasColumnType("int(11)")
                    .HasColumnName("key_height");

                entity.Property(e => e.Latest)
                    .IsRequired()
                    .HasColumnName("latest")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.PublicKey)
                    .HasMaxLength(32)
                    .HasColumnName("public_key");

                entity.Property(e => e.UnconfirmedBalance)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("unconfirmed_balance");
            });

            modelBuilder.Entity<AccountAsset>(entity =>
            {
                entity.HasKey(e => e.DbId)
                    .HasName("PRIMARY");

                entity.ToTable("account_asset");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => new { e.AccountId, e.AssetId, e.Height }, "account_asset_id_height_idx")
                    .IsUnique();

                entity.HasIndex(e => e.Quantity, "account_asset_quantity_idx");

                entity.Property(e => e.DbId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("db_id");

                entity.Property(e => e.AccountId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("account_id");

                entity.Property(e => e.AssetId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("asset_id");

                entity.Property(e => e.Height)
                    .HasColumnType("int(11)")
                    .HasColumnName("height");

                entity.Property(e => e.Latest)
                    .IsRequired()
                    .HasColumnName("latest")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Quantity)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("quantity");

                entity.Property(e => e.UnconfirmedQuantity)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("unconfirmed_quantity");
            });

            modelBuilder.Entity<AccountAssetAssetDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("account_asset_asset_details");

                entity.Property(e => e.AccountId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("account_id");

                entity.Property(e => e.AssetId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("asset_id");

                entity.Property(e => e.AssetName)
                    .HasMaxLength(10)
                    .HasColumnName("asset_name")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.AssetQuantity)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("asset_quantity");

                entity.Property(e => e.DbId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("db_id");

                entity.Property(e => e.Decimals)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("decimals");

                entity.Property(e => e.Height)
                    .HasColumnType("int(11)")
                    .HasColumnName("height");

                entity.Property(e => e.Latest)
                    .IsRequired()
                    .HasColumnName("latest")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Quantity)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("quantity");

                entity.Property(e => e.UnconfirmedQuantity)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("unconfirmed_quantity");
            });

            modelBuilder.Entity<Alias>(entity =>
            {
                entity.HasKey(e => e.DbId)
                    .HasName("PRIMARY");

                entity.ToTable("alias");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => new { e.AccountId, e.Height }, "alias_account_id_idx");

                entity.HasIndex(e => new { e.Id, e.Height }, "alias_id_height_idx")
                    .IsUnique();

                entity.HasIndex(e => e.AliasNameLower, "alias_name_lower_idx");

                entity.Property(e => e.DbId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("db_id");

                entity.Property(e => e.AccountId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("account_id");

                entity.Property(e => e.AliasName)
                    .HasMaxLength(100)
                    .HasColumnName("alias_name");

                entity.Property(e => e.AliasNameLower)
                    .HasMaxLength(100)
                    .HasColumnName("alias_name_lower");

                entity.Property(e => e.AliasUri)
                    .HasColumnType("text")
                    .HasColumnName("alias_uri");

                entity.Property(e => e.Height)
                    .HasColumnType("int(11)")
                    .HasColumnName("height");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.Latest)
                    .IsRequired()
                    .HasColumnName("latest")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Timestamp)
                    .HasColumnType("int(11)")
                    .HasColumnName("timestamp");
            });

            modelBuilder.Entity<AliasOffer>(entity =>
            {
                entity.HasKey(e => e.DbId)
                    .HasName("PRIMARY");

                entity.ToTable("alias_offer");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => new { e.Id, e.Height }, "alias_offer_id_height_idx")
                    .IsUnique();

                entity.Property(e => e.DbId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("db_id");

                entity.Property(e => e.BuyerId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("buyer_id");

                entity.Property(e => e.Height)
                    .HasColumnType("int(11)")
                    .HasColumnName("height");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.Latest)
                    .IsRequired()
                    .HasColumnName("latest")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Price)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("price");
            });

            modelBuilder.Entity<AskOrder>(entity =>
            {
                entity.HasKey(e => e.DbId)
                    .HasName("PRIMARY");

                entity.ToTable("ask_order");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => new { e.AccountId, e.Height }, "ask_order_account_id_idx");

                entity.HasIndex(e => new { e.AssetId, e.Price }, "ask_order_asset_id_price_idx");

                entity.HasIndex(e => e.CreationHeight, "ask_order_creation_idx");

                entity.HasIndex(e => new { e.Id, e.Height }, "ask_order_id_height_idx")
                    .IsUnique();

                entity.Property(e => e.DbId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("db_id");

                entity.Property(e => e.AccountId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("account_id");

                entity.Property(e => e.AssetId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("asset_id");

                entity.Property(e => e.CreationHeight)
                    .HasColumnType("int(11)")
                    .HasColumnName("creation_height");

                entity.Property(e => e.Height)
                    .HasColumnType("int(11)")
                    .HasColumnName("height");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.Latest)
                    .IsRequired()
                    .HasColumnName("latest")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Price)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("price");

                entity.Property(e => e.Quantity)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("quantity");
            });

            modelBuilder.Entity<Asset>(entity =>
            {
                entity.HasKey(e => e.DbId)
                    .HasName("PRIMARY");

                entity.ToTable("asset");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.AccountId, "asset_account_id_idx");

                entity.HasIndex(e => e.Height, "asset_height");

                entity.HasIndex(e => e.Id, "asset_id_idx")
                    .IsUnique();

                entity.Property(e => e.DbId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("db_id");

                entity.Property(e => e.AccountId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("account_id");

                entity.Property(e => e.Decimals)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("decimals");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.Height)
                    .HasColumnType("int(11)")
                    .HasColumnName("height");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .HasColumnName("name");

                entity.Property(e => e.Quantity)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("quantity");
            });

            modelBuilder.Entity<AssetTransfer>(entity =>
            {
                entity.HasKey(e => e.DbId)
                    .HasName("PRIMARY");

                entity.ToTable("asset_transfer");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => new { e.AssetId, e.Height }, "asset_transfer_asset_id_idx");

                entity.HasIndex(e => e.Id, "asset_transfer_id_idx")
                    .IsUnique();

                entity.HasIndex(e => new { e.RecipientId, e.Height }, "asset_transfer_recipient_id_idx");

                entity.HasIndex(e => new { e.SenderId, e.Height }, "asset_transfer_sender_id_idx");

                entity.Property(e => e.DbId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("db_id");

                entity.Property(e => e.AssetId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("asset_id");

                entity.Property(e => e.Height)
                    .HasColumnType("int(11)")
                    .HasColumnName("height");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.Quantity)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("quantity");

                entity.Property(e => e.RecipientId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("recipient_id");

                entity.Property(e => e.SenderId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("sender_id");

                entity.Property(e => e.Timestamp)
                    .HasColumnType("int(11)")
                    .HasColumnName("timestamp");
            });

            modelBuilder.Entity<AssetTransferAssetDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("asset_transfer_asset_detail");

                entity.Property(e => e.AssetId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("asset_id");

                entity.Property(e => e.AssetName)
                    .HasMaxLength(10)
                    .HasColumnName("asset_name")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.AssetQuantity)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("asset_quantity");

                entity.Property(e => e.DbId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("db_id");

                entity.Property(e => e.Decimals)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("decimals");

                entity.Property(e => e.Height)
                    .HasColumnType("int(11)")
                    .HasColumnName("height");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.Quantity)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("quantity");

                entity.Property(e => e.RecipientId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("recipient_id");

                entity.Property(e => e.SenderId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("sender_id");

                entity.Property(e => e.Timestamp)
                    .HasColumnType("int(11)")
                    .HasColumnName("timestamp");
            });

            modelBuilder.Entity<At>(entity =>
            {
                entity.HasKey(e => e.DbId)
                    .HasName("PRIMARY");

                entity.ToTable("at");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.ApCodeHashId, "at_ap_code_hash_id_index");

                entity.HasIndex(e => new { e.CreatorId, e.Height }, "at_creator_id_height_idx");

                entity.HasIndex(e => new { e.Id, e.Height }, "at_id_height_idx")
                    .IsUnique();

                entity.Property(e => e.DbId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("db_id");

                entity.Property(e => e.ApCode)
                    .HasColumnType("blob")
                    .HasColumnName("ap_code");

                entity.Property(e => e.ApCodeHashId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("ap_code_hash_id");

                entity.Property(e => e.CCallStackBytes)
                    .HasColumnType("int(11)")
                    .HasColumnName("c_call_stack_bytes");

                entity.Property(e => e.CUserStackBytes)
                    .HasColumnType("int(11)")
                    .HasColumnName("c_user_stack_bytes");

                entity.Property(e => e.CreationHeight)
                    .HasColumnType("int(11)")
                    .HasColumnName("creation_height");

                entity.Property(e => e.CreatorId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("creator_id");

                entity.Property(e => e.Csize)
                    .HasColumnType("int(11)")
                    .HasColumnName("csize");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.Dsize)
                    .HasColumnType("int(11)")
                    .HasColumnName("dsize");

                entity.Property(e => e.Height)
                    .HasColumnType("int(11)")
                    .HasColumnName("height");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.Latest)
                    .IsRequired()
                    .HasColumnName("latest")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .HasColumnName("name");

                entity.Property(e => e.Version)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("version");
            });

            modelBuilder.Entity<AtState>(entity =>
            {
                entity.HasKey(e => e.DbId)
                    .HasName("PRIMARY");

                entity.ToTable("at_state");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => new { e.AtId, e.Height }, "at_state_at_id_height_idx")
                    .IsUnique();

                entity.HasIndex(e => new { e.AtId, e.NextHeight, e.Height }, "at_state_id_next_height_height_idx");

                entity.Property(e => e.DbId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("db_id");

                entity.Property(e => e.AtId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("at_id");

                entity.Property(e => e.FreezeWhenSameBalance).HasColumnName("freeze_when_same_balance");

                entity.Property(e => e.Height)
                    .HasColumnType("int(11)")
                    .HasColumnName("height");

                entity.Property(e => e.Latest)
                    .IsRequired()
                    .HasColumnName("latest")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.MinActivateAmount)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("min_activate_amount");

                entity.Property(e => e.NextHeight)
                    .HasColumnType("int(11)")
                    .HasColumnName("next_height");

                entity.Property(e => e.PrevBalance)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("prev_balance");

                entity.Property(e => e.PrevHeight)
                    .HasColumnType("int(11)")
                    .HasColumnName("prev_height");

                entity.Property(e => e.SleepBetween)
                    .HasColumnType("int(11)")
                    .HasColumnName("sleep_between");

                entity.Property(e => e.State)
                    .HasColumnType("blob")
                    .HasColumnName("state");
            });

            modelBuilder.Entity<AtsView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ats_view");

                entity.Property(e => e.ApCode)
                    .HasColumnType("blob")
                    .HasColumnName("ap_code");

                entity.Property(e => e.ApCodeHashId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("ap_code_hash_id");

                entity.Property(e => e.CCallStackBytes)
                    .HasColumnType("int(11)")
                    .HasColumnName("c_call_stack_bytes");

                entity.Property(e => e.CUserStackBytes)
                    .HasColumnType("int(11)")
                    .HasColumnName("c_user_stack_bytes");

                entity.Property(e => e.CreationHeight)
                    .HasColumnType("int(11)")
                    .HasColumnName("creation_height");

                entity.Property(e => e.CreatorId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("creator_id");

                entity.Property(e => e.Csize)
                    .HasColumnType("int(11)")
                    .HasColumnName("csize");

                entity.Property(e => e.DbId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("db_id");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Dsize)
                    .HasColumnType("int(11)")
                    .HasColumnName("dsize");

                entity.Property(e => e.Height)
                    .HasColumnType("int(11)")
                    .HasColumnName("height");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.Latest)
                    .IsRequired()
                    .HasColumnName("latest")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .HasColumnName("name")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Version)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("version");
            });

            modelBuilder.Entity<BidOrder>(entity =>
            {
                entity.HasKey(e => e.DbId)
                    .HasName("PRIMARY");

                entity.ToTable("bid_order");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => new { e.AccountId, e.Height }, "bid_order_account_id_idx");

                entity.HasIndex(e => new { e.AssetId, e.Price }, "bid_order_asset_id_price_idx");

                entity.HasIndex(e => e.CreationHeight, "bid_order_creation_idx");

                entity.HasIndex(e => new { e.Id, e.Height }, "bid_order_id_height_idx")
                    .IsUnique();

                entity.Property(e => e.DbId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("db_id");

                entity.Property(e => e.AccountId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("account_id");

                entity.Property(e => e.AssetId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("asset_id");

                entity.Property(e => e.CreationHeight)
                    .HasColumnType("int(11)")
                    .HasColumnName("creation_height");

                entity.Property(e => e.Height)
                    .HasColumnType("int(11)")
                    .HasColumnName("height");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.Latest)
                    .IsRequired()
                    .HasColumnName("latest")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Price)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("price");

                entity.Property(e => e.Quantity)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("quantity");
            });

            modelBuilder.Entity<Block>(entity =>
            {
                entity.HasKey(e => e.DbId)
                    .HasName("PRIMARY");

                entity.ToTable("block");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.GeneratorId, "block_generator_id_idx");

                entity.HasIndex(e => e.Height, "block_height_idx")
                    .IsUnique();

                entity.HasIndex(e => e.Id, "block_id_idx")
                    .IsUnique();

                entity.HasIndex(e => e.Timestamp, "block_timestamp_idx")
                    .IsUnique();

                entity.HasIndex(e => e.PreviousBlockId, "constraint_3c");

                entity.HasIndex(e => e.NextBlockId, "constraint_3c5");

                entity.Property(e => e.DbId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("db_id");

                entity.Property(e => e.Ats)
                    .HasColumnType("blob")
                    .HasColumnName("ats");

                entity.Property(e => e.BaseTarget)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("base_target");

                entity.Property(e => e.BlockSignature)
                    .HasMaxLength(64)
                    .HasColumnName("block_signature");

                entity.Property(e => e.CumulativeDifficulty)
                    .HasColumnType("blob")
                    .HasColumnName("cumulative_difficulty");

                entity.Property(e => e.GenerationSignature)
                    .HasMaxLength(64)
                    .HasColumnName("generation_signature");

                entity.Property(e => e.GeneratorId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("generator_id");

                entity.Property(e => e.GeneratorPublicKey)
                    .HasMaxLength(32)
                    .HasColumnName("generator_public_key");

                entity.Property(e => e.Height)
                    .HasColumnType("int(11)")
                    .HasColumnName("height");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.NextBlockId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("next_block_id");

                entity.Property(e => e.Nonce)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("nonce");

                entity.Property(e => e.PayloadHash)
                    .HasMaxLength(32)
                    .HasColumnName("payload_hash");

                entity.Property(e => e.PayloadLength)
                    .HasColumnType("int(11)")
                    .HasColumnName("payload_length");

                entity.Property(e => e.PreviousBlockHash)
                    .HasMaxLength(32)
                    .HasColumnName("previous_block_hash");

                entity.Property(e => e.PreviousBlockId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("previous_block_id");

                entity.Property(e => e.Timestamp)
                    .HasColumnType("int(11)")
                    .HasColumnName("timestamp");

                entity.Property(e => e.TotalAmount)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("total_amount");

                entity.Property(e => e.TotalFee)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("total_fee");

                entity.Property(e => e.Version)
                    .HasColumnType("int(11)")
                    .HasColumnName("version");

                entity.HasOne(d => d.NextBlock)
                    .WithMany(p => p.InverseNextBlock)
                    .HasPrincipalKey(p => p.Id)
                    .HasForeignKey(d => d.NextBlockId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("constraint_3c5");

                entity.HasOne(d => d.PreviousBlock)
                    .WithMany(p => p.InversePreviousBlock)
                    .HasPrincipalKey(p => p.Id)
                    .HasForeignKey(d => d.PreviousBlockId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("constraint_3c");
            });

            modelBuilder.Entity<BlockRewardRecipDesc>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("block_reward_recip_desc");

                entity.Property(e => e.Ats)
                    .HasColumnType("blob")
                    .HasColumnName("ats");

                entity.Property(e => e.BaseTarget)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("base_target");

                entity.Property(e => e.BlockSignature)
                    .HasMaxLength(64)
                    .HasColumnName("block_signature");

                entity.Property(e => e.CumulativeDifficulty)
                    .HasColumnType("blob")
                    .HasColumnName("cumulative_difficulty");

                entity.Property(e => e.DbId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("db_id");

                entity.Property(e => e.GenerationSignature)
                    .HasMaxLength(64)
                    .HasColumnName("generation_signature");

                entity.Property(e => e.GeneratorId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("generator_id");

                entity.Property(e => e.GeneratorPublicKey)
                    .HasMaxLength(32)
                    .HasColumnName("generator_public_key");

                entity.Property(e => e.Height)
                    .HasColumnType("int(11)")
                    .HasColumnName("height");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.NextBlockId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("next_block_id");

                entity.Property(e => e.Nonce)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("nonce");

                entity.Property(e => e.PayloadHash)
                    .HasMaxLength(32)
                    .HasColumnName("payload_hash");

                entity.Property(e => e.PayloadLength)
                    .HasColumnType("int(11)")
                    .HasColumnName("payload_length");

                entity.Property(e => e.PreviousBlockHash)
                    .HasMaxLength(32)
                    .HasColumnName("previous_block_hash");

                entity.Property(e => e.PreviousBlockId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("previous_block_id");

                entity.Property(e => e.RecipId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("recip_id");

                entity.Property(e => e.RecipName)
                    .HasMaxLength(100)
                    .HasColumnName("recip_name")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Timestamp)
                    .HasColumnType("int(11)")
                    .HasColumnName("timestamp");

                entity.Property(e => e.TotalAmount)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("total_amount");

                entity.Property(e => e.TotalFee)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("total_fee");

                entity.Property(e => e.TransactionCount)
                    .HasColumnType("bigint(21)")
                    .HasColumnName("transaction_count");

                entity.Property(e => e.Version)
                    .HasColumnType("int(11)")
                    .HasColumnName("version");
            });

            modelBuilder.Entity<EfmigrationsHistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId)
                    .HasName("PRIMARY");

                entity.ToTable("__EFMigrationsHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ProductVersion).HasMaxLength(32);
            });

            modelBuilder.Entity<Escrow>(entity =>
            {
                entity.HasKey(e => e.DbId)
                    .HasName("PRIMARY");

                entity.ToTable("escrow");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => new { e.Deadline, e.Height }, "escrow_deadline_height_idx");

                entity.HasIndex(e => new { e.Id, e.Height }, "escrow_id_height_idx")
                    .IsUnique();

                entity.HasIndex(e => new { e.RecipientId, e.Height }, "escrow_recipient_id_height_idx");

                entity.HasIndex(e => new { e.SenderId, e.Height }, "escrow_sender_id_height_idx");

                entity.Property(e => e.DbId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("db_id");

                entity.Property(e => e.Amount)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("amount");

                entity.Property(e => e.Deadline)
                    .HasColumnType("int(11)")
                    .HasColumnName("deadline");

                entity.Property(e => e.DeadlineAction)
                    .HasColumnType("int(11)")
                    .HasColumnName("deadline_action");

                entity.Property(e => e.Height)
                    .HasColumnType("int(11)")
                    .HasColumnName("height");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.Latest)
                    .IsRequired()
                    .HasColumnName("latest")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.RecipientId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("recipient_id");

                entity.Property(e => e.RequiredSigners)
                    .HasColumnType("int(11)")
                    .HasColumnName("required_signers");

                entity.Property(e => e.SenderId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("sender_id");
            });

            modelBuilder.Entity<EscrowDecision>(entity =>
            {
                entity.HasKey(e => e.DbId)
                    .HasName("PRIMARY");

                entity.ToTable("escrow_decision");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => new { e.AccountId, e.Height }, "escrow_decision_account_id_height_idx");

                entity.HasIndex(e => new { e.EscrowId, e.AccountId, e.Height }, "escrow_decision_escrow_id_account_id_height_idx")
                    .IsUnique();

                entity.HasIndex(e => new { e.EscrowId, e.Height }, "escrow_decision_escrow_id_height_idx");

                entity.Property(e => e.DbId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("db_id");

                entity.Property(e => e.AccountId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("account_id");

                entity.Property(e => e.Decision)
                    .HasColumnType("int(11)")
                    .HasColumnName("decision");

                entity.Property(e => e.EscrowId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("escrow_id");

                entity.Property(e => e.Height)
                    .HasColumnType("int(11)")
                    .HasColumnName("height");

                entity.Property(e => e.Latest)
                    .IsRequired()
                    .HasColumnName("latest")
                    .HasDefaultValueSql("'1'");
            });

            modelBuilder.Entity<FlywaySchemaHistory>(entity =>
            {
                entity.HasKey(e => e.InstalledRank)
                    .HasName("PRIMARY");

                entity.ToTable("flyway_schema_history");

                entity.HasIndex(e => e.Success, "flyway_schema_history_s_idx");

                entity.Property(e => e.InstalledRank)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("installed_rank");

                entity.Property(e => e.Checksum)
                    .HasColumnType("int(11)")
                    .HasColumnName("checksum");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .HasColumnName("description");

                entity.Property(e => e.ExecutionTime)
                    .HasColumnType("int(11)")
                    .HasColumnName("execution_time");

                entity.Property(e => e.InstalledBy)
                    .HasMaxLength(100)
                    .HasColumnName("installed_by");

                entity.Property(e => e.InstalledOn)
                    .HasColumnType("timestamp")
                    .HasColumnName("installed_on")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.Script)
                    .HasMaxLength(1000)
                    .HasColumnName("script");

                entity.Property(e => e.Success).HasColumnName("success");

                entity.Property(e => e.Type)
                    .HasMaxLength(20)
                    .HasColumnName("type");

                entity.Property(e => e.Version)
                    .HasMaxLength(50)
                    .HasColumnName("version");
            });

            modelBuilder.Entity<Good>(entity =>
            {
                entity.HasKey(e => e.DbId)
                    .HasName("PRIMARY");

                entity.ToTable("goods");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => new { e.Id, e.Height }, "goods_id_height_idx")
                    .IsUnique();

                entity.HasIndex(e => new { e.SellerId, e.Name }, "goods_seller_id_name_idx");

                entity.HasIndex(e => new { e.Timestamp, e.Height }, "goods_timestamp_idx");

                entity.Property(e => e.DbId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("db_id");

                entity.Property(e => e.Delisted).HasColumnName("delisted");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.Height)
                    .HasColumnType("int(11)")
                    .HasColumnName("height");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.Latest)
                    .IsRequired()
                    .HasColumnName("latest")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Price)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("price");

                entity.Property(e => e.Quantity)
                    .HasColumnType("int(11)")
                    .HasColumnName("quantity");

                entity.Property(e => e.SellerId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("seller_id");

                entity.Property(e => e.Tags)
                    .HasMaxLength(100)
                    .HasColumnName("tags");

                entity.Property(e => e.Timestamp)
                    .HasColumnType("int(11)")
                    .HasColumnName("timestamp");
            });

            modelBuilder.Entity<IndirectIncoming>(entity =>
            {
                entity.HasKey(e => e.DbId)
                    .HasName("PRIMARY");

                entity.ToTable("indirect_incoming");

                entity.HasIndex(e => new { e.AccountId, e.TransactionId }, "indirect_incoming_db_id_uindex")
                    .IsUnique();

                entity.HasIndex(e => e.Height, "indirect_incoming_index");

                entity.Property(e => e.DbId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("db_id");

                entity.Property(e => e.AccountId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("account_id");

                entity.Property(e => e.Height)
                    .HasColumnType("int(11)")
                    .HasColumnName("height");

                entity.Property(e => e.TransactionId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("transaction_id");
            });

            modelBuilder.Entity<LatestAccountRewardRecip>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("latest_account_reward_recip");

                entity.Property(e => e.Balance)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("balance");

                entity.Property(e => e.CreationHeight)
                    .HasColumnType("int(11)")
                    .HasColumnName("creation_height");

                entity.Property(e => e.DbId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("db_id");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.ForgedBalance)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("forged_balance");

                entity.Property(e => e.FromHeight)
                    .HasColumnType("int(11)")
                    .HasColumnName("from_height");

                entity.Property(e => e.Height)
                    .HasColumnType("int(11)")
                    .HasColumnName("height");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.KeyHeight)
                    .HasColumnType("int(11)")
                    .HasColumnName("key_height");

                entity.Property(e => e.Latest)
                    .IsRequired()
                    .HasColumnName("latest")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.PublicKey)
                    .HasMaxLength(32)
                    .HasColumnName("public_key");

                entity.Property(e => e.RecipDescrip)
                    .HasColumnType("text")
                    .HasColumnName("recip_descrip")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.RecipId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("recip_id");

                entity.Property(e => e.RecipName)
                    .HasMaxLength(100)
                    .HasColumnName("recip_name")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.UnconfirmedBalance)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("unconfirmed_balance");
            });

            modelBuilder.Entity<LatestAskOrder>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("latest_ask_order");

                entity.Property(e => e.AccountId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("account_id");

                entity.Property(e => e.AssetId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("asset_id");

                entity.Property(e => e.AssetName)
                    .HasMaxLength(10)
                    .HasColumnName("asset_name")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.AssetQuantity)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("asset_quantity");

                entity.Property(e => e.CreationHeight)
                    .HasColumnType("int(11)")
                    .HasColumnName("creation_height");

                entity.Property(e => e.DbId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("db_id");

                entity.Property(e => e.Decimals)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("decimals");

                entity.Property(e => e.Height)
                    .HasColumnType("int(11)")
                    .HasColumnName("height");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.Latest)
                    .IsRequired()
                    .HasColumnName("latest")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Price)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("price");

                entity.Property(e => e.Quantity)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("quantity");
            });

            modelBuilder.Entity<LatestBidOrder>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("latest_bid_order");

                entity.Property(e => e.AccountId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("account_id");

                entity.Property(e => e.AssetId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("asset_id");

                entity.Property(e => e.AssetName)
                    .HasMaxLength(10)
                    .HasColumnName("asset_name")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.AssetQuantity)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("asset_quantity");

                entity.Property(e => e.CreationHeight)
                    .HasColumnType("int(11)")
                    .HasColumnName("creation_height");

                entity.Property(e => e.DbId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("db_id");

                entity.Property(e => e.Decimals)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("decimals");

                entity.Property(e => e.Height)
                    .HasColumnType("int(11)")
                    .HasColumnName("height");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.Latest)
                    .IsRequired()
                    .HasColumnName("latest")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Price)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("price");

                entity.Property(e => e.Quantity)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("quantity");
            });

            modelBuilder.Entity<MultiOutTransactionAttach>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("multi_out_transaction_attach");

                entity.Property(e => e.Amount)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("amount");

                entity.Property(e => e.AttachmentBytes)
                    .HasColumnType("blob")
                    .HasColumnName("attachment_bytes");

                entity.Property(e => e.DbId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("db_id");

                entity.Property(e => e.Fee)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("fee");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.SenderId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("sender_id");

                entity.Property(e => e.SenderName)
                    .HasMaxLength(100)
                    .HasColumnName("sender_name")
                    .UseCollation("utf8mb4_unicode_ci");

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

            modelBuilder.Entity<Peer>(entity =>
            {
                entity.HasKey(e => e.Address)
                    .HasName("PRIMARY");

                entity.ToTable("peer");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .HasColumnName("address");
            });

            modelBuilder.Entity<Purchase>(entity =>
            {
                entity.HasKey(e => e.DbId)
                    .HasName("PRIMARY");

                entity.ToTable("purchase");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => new { e.BuyerId, e.Height }, "purchase_buyer_id_height_idx");

                entity.HasIndex(e => new { e.Deadline, e.Height }, "purchase_deadline_idx");

                entity.HasIndex(e => new { e.Id, e.Height }, "purchase_id_height_idx")
                    .IsUnique();

                entity.HasIndex(e => new { e.SellerId, e.Height }, "purchase_seller_id_height_idx");

                entity.HasIndex(e => new { e.Timestamp, e.Id }, "purchase_timestamp_idx");

                entity.Property(e => e.DbId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("db_id");

                entity.Property(e => e.BuyerId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("buyer_id");

                entity.Property(e => e.Deadline)
                    .HasColumnType("int(11)")
                    .HasColumnName("deadline");

                entity.Property(e => e.Discount)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("discount");

                entity.Property(e => e.Goods)
                    .HasColumnType("blob")
                    .HasColumnName("goods");

                entity.Property(e => e.GoodsId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("goods_id");

                entity.Property(e => e.GoodsNonce)
                    .HasMaxLength(32)
                    .HasColumnName("goods_nonce");

                entity.Property(e => e.HasFeedbackNotes).HasColumnName("has_feedback_notes");

                entity.Property(e => e.HasPublicFeedbacks).HasColumnName("has_public_feedbacks");

                entity.Property(e => e.Height)
                    .HasColumnType("int(11)")
                    .HasColumnName("height");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.Latest)
                    .IsRequired()
                    .HasColumnName("latest")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Nonce)
                    .HasMaxLength(32)
                    .HasColumnName("nonce");

                entity.Property(e => e.Note)
                    .HasColumnType("blob")
                    .HasColumnName("note");

                entity.Property(e => e.Pending).HasColumnName("pending");

                entity.Property(e => e.Price)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("price");

                entity.Property(e => e.Quantity)
                    .HasColumnType("int(11)")
                    .HasColumnName("quantity");

                entity.Property(e => e.Refund)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("refund");

                entity.Property(e => e.RefundNonce)
                    .HasMaxLength(32)
                    .HasColumnName("refund_nonce");

                entity.Property(e => e.RefundNote)
                    .HasColumnType("blob")
                    .HasColumnName("refund_note");

                entity.Property(e => e.SellerId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("seller_id");

                entity.Property(e => e.Timestamp)
                    .HasColumnType("int(11)")
                    .HasColumnName("timestamp");
            });

            modelBuilder.Entity<PurchaseFeedback>(entity =>
            {
                entity.HasKey(e => e.DbId)
                    .HasName("PRIMARY");

                entity.ToTable("purchase_feedback");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => new { e.Id, e.Height }, "purchase_feedback_id_height_idx");

                entity.Property(e => e.DbId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("db_id");

                entity.Property(e => e.FeedbackData)
                    .HasColumnType("blob")
                    .HasColumnName("feedback_data");

                entity.Property(e => e.FeedbackNonce)
                    .HasMaxLength(32)
                    .HasColumnName("feedback_nonce");

                entity.Property(e => e.Height)
                    .HasColumnType("int(11)")
                    .HasColumnName("height");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.Latest)
                    .IsRequired()
                    .HasColumnName("latest")
                    .HasDefaultValueSql("'1'");
            });

            modelBuilder.Entity<PurchasePublicFeedback>(entity =>
            {
                entity.HasKey(e => e.DbId)
                    .HasName("PRIMARY");

                entity.ToTable("purchase_public_feedback");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => new { e.Id, e.Height }, "purchase_public_feedback_id_height_idx");

                entity.Property(e => e.DbId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("db_id");

                entity.Property(e => e.Height)
                    .HasColumnType("int(11)")
                    .HasColumnName("height");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.Latest)
                    .IsRequired()
                    .HasColumnName("latest")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.PublicFeedback)
                    .HasColumnType("text")
                    .HasColumnName("public_feedback");
            });

            modelBuilder.Entity<RewardRecipAssign>(entity =>
            {
                entity.HasKey(e => e.DbId)
                    .HasName("PRIMARY");

                entity.ToTable("reward_recip_assign");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => new { e.AccountId, e.Height }, "reward_recip_assign_account_id_height_idx")
                    .IsUnique();

                entity.HasIndex(e => new { e.RecipId, e.Height }, "reward_recip_assign_recip_id_height_idx");

                entity.Property(e => e.DbId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("db_id");

                entity.Property(e => e.AccountId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("account_id");

                entity.Property(e => e.FromHeight)
                    .HasColumnType("int(11)")
                    .HasColumnName("from_height");

                entity.Property(e => e.Height)
                    .HasColumnType("int(11)")
                    .HasColumnName("height");

                entity.Property(e => e.Latest)
                    .IsRequired()
                    .HasColumnName("latest")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.PrevRecipId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("prev_recip_id");

                entity.Property(e => e.RecipId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("recip_id");
            });

            modelBuilder.Entity<RewardRecipNameDesc>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("reward_recip_name_desc");

                entity.Property(e => e.AccountId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("account_id");

                entity.Property(e => e.DbId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("db_id");

                entity.Property(e => e.FromHeight)
                    .HasColumnType("int(11)")
                    .HasColumnName("from_height");

                entity.Property(e => e.Height)
                    .HasColumnType("int(11)")
                    .HasColumnName("height");

                entity.Property(e => e.Latest)
                    .IsRequired()
                    .HasColumnName("latest")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.PrevRecipId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("prev_recip_id");

                entity.Property(e => e.RecipDescrip)
                    .HasColumnType("text")
                    .HasColumnName("recip_descrip")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.RecipId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("recip_id");

                entity.Property(e => e.RecipName)
                    .HasMaxLength(100)
                    .HasColumnName("recip_name")
                    .UseCollation("utf8mb4_unicode_ci");
            });

            modelBuilder.Entity<Subscription>(entity =>
            {
                entity.HasKey(e => e.DbId)
                    .HasName("PRIMARY");

                entity.ToTable("subscription");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => new { e.Id, e.Height }, "subscription_id_height_idx")
                    .IsUnique();

                entity.HasIndex(e => new { e.RecipientId, e.Height }, "subscription_recipient_id_height_idx");

                entity.HasIndex(e => new { e.SenderId, e.Height }, "subscription_sender_id_height_idx");

                entity.HasIndex(e => e.TimeNext, "subscription_time_next_index");

                entity.Property(e => e.DbId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("db_id");

                entity.Property(e => e.Amount)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("amount");

                entity.Property(e => e.Frequency)
                    .HasColumnType("int(11)")
                    .HasColumnName("frequency");

                entity.Property(e => e.Height)
                    .HasColumnType("int(11)")
                    .HasColumnName("height");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.Latest)
                    .IsRequired()
                    .HasColumnName("latest")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.RecipientId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("recipient_id");

                entity.Property(e => e.SenderId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("sender_id");

                entity.Property(e => e.TimeNext)
                    .HasColumnType("int(11)")
                    .HasColumnName("time_next");
            });

            modelBuilder.Entity<Trade>(entity =>
            {
                entity.HasKey(e => e.DbId)
                    .HasName("PRIMARY");

                entity.ToTable("trade");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => new { e.AskOrderId, e.BidOrderId }, "trade_ask_bid_idx")
                    .IsUnique();

                entity.HasIndex(e => new { e.AssetId, e.Height }, "trade_asset_id_idx");

                entity.HasIndex(e => new { e.BuyerId, e.Height }, "trade_buyer_id_idx");

                entity.HasIndex(e => new { e.SellerId, e.Height }, "trade_seller_id_idx");

                entity.Property(e => e.DbId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("db_id");

                entity.Property(e => e.AskOrderHeight)
                    .HasColumnType("int(11)")
                    .HasColumnName("ask_order_height");

                entity.Property(e => e.AskOrderId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("ask_order_id");

                entity.Property(e => e.AssetId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("asset_id");

                entity.Property(e => e.BidOrderHeight)
                    .HasColumnType("int(11)")
                    .HasColumnName("bid_order_height");

                entity.Property(e => e.BidOrderId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("bid_order_id");

                entity.Property(e => e.BlockId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("block_id");

                entity.Property(e => e.BuyerId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("buyer_id");

                entity.Property(e => e.Height)
                    .HasColumnType("int(11)")
                    .HasColumnName("height");

                entity.Property(e => e.Price)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("price");

                entity.Property(e => e.Quantity)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("quantity");

                entity.Property(e => e.SellerId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("seller_id");

                entity.Property(e => e.Timestamp)
                    .HasColumnType("int(11)")
                    .HasColumnName("timestamp");
            });

            modelBuilder.Entity<TradeAssetDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("trade_asset_detail");

                entity.Property(e => e.AskOrderHeight)
                    .HasColumnType("int(11)")
                    .HasColumnName("ask_order_height");

                entity.Property(e => e.AskOrderId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("ask_order_id");

                entity.Property(e => e.AssetId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("asset_id");

                entity.Property(e => e.AssetName)
                    .HasMaxLength(10)
                    .HasColumnName("asset_name")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.AssetQuantity)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("asset_quantity");

                entity.Property(e => e.BidOrderHeight)
                    .HasColumnType("int(11)")
                    .HasColumnName("bid_order_height");

                entity.Property(e => e.BidOrderId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("bid_order_id");

                entity.Property(e => e.BlockId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("block_id");

                entity.Property(e => e.BuyerId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("buyer_id");

                entity.Property(e => e.DbId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("db_id");

                entity.Property(e => e.Decimals)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("decimals");

                entity.Property(e => e.Height)
                    .HasColumnType("int(11)")
                    .HasColumnName("height");

                entity.Property(e => e.Price)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("price");

                entity.Property(e => e.Quantity)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("quantity");

                entity.Property(e => e.SellerId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("seller_id");

                entity.Property(e => e.Timestamp)
                    .HasColumnType("int(11)")
                    .HasColumnName("timestamp");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasKey(e => e.DbId)
                    .HasName("PRIMARY");

                entity.ToTable("transaction");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.BlockId, "constraint_ff");

                entity.HasIndex(e => e.BlockTimestamp, "transaction_block_timestamp_idx");

                entity.HasIndex(e => e.FullHash, "transaction_full_hash_idx")
                    .IsUnique();

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

                entity.Property(e => e.AttachmentBytes)
                    .HasColumnType("blob")
                    .HasColumnName("attachment_bytes");

                entity.Property(e => e.BlockId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("block_id");

                entity.Property(e => e.BlockTimestamp)
                    .HasColumnType("int(11)")
                    .HasColumnName("block_timestamp");

                entity.Property(e => e.Deadline)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("deadline");

                entity.Property(e => e.EcBlockHeight)
                    .HasColumnType("int(11)")
                    .HasColumnName("ec_block_height");

                entity.Property(e => e.EcBlockId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("ec_block_id");

                entity.Property(e => e.Fee)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("fee");

                entity.Property(e => e.FullHash)
                    .HasMaxLength(32)
                    .HasColumnName("full_hash");

                entity.Property(e => e.HasEncryptedMessage).HasColumnName("has_encrypted_message");

                entity.Property(e => e.HasEncrypttoselfMessage).HasColumnName("has_encrypttoself_message");

                entity.Property(e => e.HasMessage).HasColumnName("has_message");

                entity.Property(e => e.HasPublicKeyAnnouncement).HasColumnName("has_public_key_announcement");

                entity.Property(e => e.Height)
                    .HasColumnType("int(11)")
                    .HasColumnName("height");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.RecipientId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("recipient_id");

                entity.Property(e => e.ReferencedTransactionFullhash)
                    .HasMaxLength(32)
                    .HasColumnName("referenced_transaction_fullhash");

                entity.Property(e => e.SenderId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("sender_id");

                entity.Property(e => e.SenderPublicKey)
                    .HasMaxLength(32)
                    .HasColumnName("sender_public_key");

                entity.Property(e => e.Signature)
                    .HasMaxLength(64)
                    .HasColumnName("signature");

                entity.Property(e => e.Subtype)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("subtype");

                entity.Property(e => e.Timestamp)
                    .HasColumnType("int(11)")
                    .HasColumnName("timestamp");

                entity.Property(e => e.Type)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("type");

                entity.Property(e => e.Version)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("version");

                entity.HasOne(d => d.Block)
                    .WithMany(p => p.Transactions)
                    .HasPrincipalKey(p => p.Id)
                    .HasForeignKey(d => d.BlockId)
                    .HasConstraintName("constraint_ff");
            });

            modelBuilder.Entity<TransactionAccountName>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("transaction_account_names");

                entity.Property(e => e.Amount)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("amount");

                entity.Property(e => e.AttachmentBytes)
                    .HasColumnType("blob")
                    .HasColumnName("attachment_bytes");

                entity.Property(e => e.BlockId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("block_id");

                entity.Property(e => e.BlockTimestamp)
                    .HasColumnType("int(11)")
                    .HasColumnName("block_timestamp");

                entity.Property(e => e.DbId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("db_id");

                entity.Property(e => e.Deadline)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("deadline");

                entity.Property(e => e.EcBlockHeight)
                    .HasColumnType("int(11)")
                    .HasColumnName("ec_block_height");

                entity.Property(e => e.EcBlockId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("ec_block_id");

                entity.Property(e => e.Fee)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("fee");

                entity.Property(e => e.FullHash)
                    .HasMaxLength(32)
                    .HasColumnName("full_hash");

                entity.Property(e => e.HasEncryptedMessage).HasColumnName("has_encrypted_message");

                entity.Property(e => e.HasEncrypttoselfMessage).HasColumnName("has_encrypttoself_message");

                entity.Property(e => e.HasMessage).HasColumnName("has_message");

                entity.Property(e => e.HasPublicKeyAnnouncement).HasColumnName("has_public_key_announcement");

                entity.Property(e => e.Height)
                    .HasColumnType("int(11)")
                    .HasColumnName("height");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.RecipientId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("recipient_id");

                entity.Property(e => e.RecipientName)
                    .HasMaxLength(100)
                    .HasColumnName("recipient_name")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.ReferencedTransactionFullhash)
                    .HasMaxLength(32)
                    .HasColumnName("referenced_transaction_fullhash");

                entity.Property(e => e.SenderId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("sender_id");

                entity.Property(e => e.SenderName)
                    .HasMaxLength(100)
                    .HasColumnName("sender_name")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.SenderPublicKey)
                    .HasMaxLength(32)
                    .HasColumnName("sender_public_key");

                entity.Property(e => e.Signature)
                    .HasMaxLength(64)
                    .HasColumnName("signature");

                entity.Property(e => e.Subtype)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("subtype");

                entity.Property(e => e.Timestamp)
                    .HasColumnType("int(11)")
                    .HasColumnName("timestamp");

                entity.Property(e => e.Type)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("type");

                entity.Property(e => e.Version)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("version");
            });

            modelBuilder.Entity<UnconfirmedTransaction>(entity =>
            {
                entity.HasKey(e => e.DbId)
                    .HasName("PRIMARY");

                entity.ToTable("unconfirmed_transaction");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => new { e.TransactionHeight, e.FeePerByte, e.Timestamp }, "unconfirmed_transaction_height_fee_timestamp_idx");

                entity.HasIndex(e => e.Id, "unconfirmed_transaction_id_idx")
                    .IsUnique();

                entity.Property(e => e.DbId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("db_id");

                entity.Property(e => e.Expiration)
                    .HasColumnType("int(11)")
                    .HasColumnName("expiration");

                entity.Property(e => e.FeePerByte)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("fee_per_byte");

                entity.Property(e => e.Height)
                    .HasColumnType("int(11)")
                    .HasColumnName("height");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.Timestamp)
                    .HasColumnType("int(11)")
                    .HasColumnName("timestamp");

                entity.Property(e => e.TransactionBytes)
                    .HasColumnType("blob")
                    .HasColumnName("transaction_bytes");

                entity.Property(e => e.TransactionHeight)
                    .HasColumnType("int(11)")
                    .HasColumnName("transaction_height");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
