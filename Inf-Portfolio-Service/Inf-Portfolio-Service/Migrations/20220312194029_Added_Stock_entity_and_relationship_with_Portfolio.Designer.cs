// <auto-generated />
using System;
using Inf_Portfolio_Service.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Inf_Portfolio_Service.Migrations
{
    [DbContext(typeof(PortfolioDbContext))]
    [Migration("20220312194029_Added_Stock_entity_and_relationship_with_Portfolio")]
    partial class Added_Stock_entity_and_relationship_with_Portfolio
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Inf_Portfolio_Service.Models.Portfolio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Portfolios");
                });

            modelBuilder.Entity("Inf_Portfolio_Service.Models.Stock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Bought")
                        .HasColumnType("float");

                    b.Property<double>("Current")
                        .HasColumnType("float");

                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PortfolioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Symbol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Yield")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("PortfolioId");

                    b.ToTable("Stocks");
                });

            modelBuilder.Entity("Inf_Portfolio_Service.Models.Stock", b =>
                {
                    b.HasOne("Inf_Portfolio_Service.Models.Portfolio", "Portfolio")
                        .WithMany("Stocks")
                        .HasForeignKey("PortfolioId")
                        .HasPrincipalKey("Guid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
