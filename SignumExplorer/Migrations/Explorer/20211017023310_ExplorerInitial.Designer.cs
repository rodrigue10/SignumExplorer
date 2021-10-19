﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SignumExplorer.Context;

#nullable disable

namespace SignumExplorer.Migrations.Explorer
{
    [DbContext(typeof(ExplorerContext))]
    [Migration("20211017023310_ExplorerInitial")]
    partial class ExplorerInitial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("utf8mb4_general_ci")
                .HasAnnotation("ProductVersion", "6.0.0-rc.1.21452.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.HasCharSet(modelBuilder, "utf8mb4");

            modelBuilder.Entity("SignumExplorer.Models.MultiOutTransaction", b =>
                {
                    b.Property<long>("DbId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint(20)")
                        .HasColumnName("db_id");

                    b.Property<long>("Amount")
                        .HasColumnType("bigint(20)")
                        .HasColumnName("amount");

                    b.Property<long>("Fee")
                        .HasColumnType("bigint");

                    b.Property<int>("Height")
                        .HasColumnType("int(11)")
                        .HasColumnName("height");

                    b.Property<long>("Id")
                        .HasColumnType("bigint(20)")
                        .HasColumnName("id");

                    b.Property<long>("RecipientId")
                        .HasColumnType("bigint(20)")
                        .HasColumnName("recipient_id");

                    b.Property<long>("SenderId")
                        .HasColumnType("bigint(20)")
                        .HasColumnName("sender_id");

                    b.Property<sbyte>("Subtype")
                        .HasColumnType("tinyint(4)")
                        .HasColumnName("subtype");

                    b.Property<int>("Timestamp")
                        .HasColumnType("int(11)")
                        .HasColumnName("timestamp");

                    b.Property<long>("TotalAmount")
                        .HasColumnType("bigint(20)")
                        .HasColumnName("total_amount");

                    b.Property<sbyte>("Type")
                        .HasColumnType("tinyint(4)")
                        .HasColumnName("type");

                    b.HasKey("DbId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "Height", "Timestamp" }, "transaction_height_timestamp");

                    b.HasIndex(new[] { "Id" }, "transaction_id_idx")
                        .IsUnique();

                    b.HasIndex(new[] { "RecipientId", "Amount", "Height" }, "transaction_recipient_id_amount_height_idx");

                    b.HasIndex(new[] { "RecipientId" }, "transaction_recipient_id_idx");

                    b.HasIndex(new[] { "SenderId" }, "transaction_sender_id_idx");

                    b.ToTable("multi_out_transaction", (string)null);

                    MySqlEntityTypeBuilderExtensions.UseCollation(b, "utf8mb4_unicode_ci");
                });
#pragma warning restore 612, 618
        }
    }
}