﻿// <auto-generated />
using System;
using ADP_HomeWork.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ADP_HomeWork.Migrations
{
    [DbContext(typeof(NewsDataContext))]
    partial class NewsDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ADP_HomeWork.DataBase.Tables.Agency", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CityID");

                    b.Property<int>("LanguageID");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.HasIndex("CityID");

                    b.HasIndex("LanguageID");

                    b.ToTable("Agencies");
                });

            modelBuilder.Entity("ADP_HomeWork.DataBase.Tables.City", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("ADP_HomeWork.DataBase.Tables.Language", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("ADP_HomeWork.DataBase.Tables.News", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abstract");

                    b.Property<int>("AgencyID");

                    b.Property<DateTime>("Date");

                    b.Property<string>("ImagePath");

                    b.Property<int>("Ranking");

                    b.Property<string>("Text");

                    b.Property<string>("Title");

                    b.Property<int>("TotalReads");

                    b.HasKey("ID");

                    b.HasIndex("AgencyID");

                    b.ToTable("News");
                });

            modelBuilder.Entity("ADP_HomeWork.DataBase.Tables.Agency", b =>
                {
                    b.HasOne("ADP_HomeWork.DataBase.Tables.City", "City")
                        .WithMany()
                        .HasForeignKey("CityID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ADP_HomeWork.DataBase.Tables.Language", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ADP_HomeWork.DataBase.Tables.News", b =>
                {
                    b.HasOne("ADP_HomeWork.DataBase.Tables.Agency", "Agency")
                        .WithMany()
                        .HasForeignKey("AgencyID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
