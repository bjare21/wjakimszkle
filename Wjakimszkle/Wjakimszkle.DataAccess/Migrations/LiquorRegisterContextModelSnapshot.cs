﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Wjakimszkle.DataAccess;

namespace Wjakimszkle.DataAccess.Migrations
{
    [DbContext(typeof(LiquorRegisterContext))]
    partial class LiquorRegisterContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DishDrinkType", b =>
                {
                    b.Property<int>("DishesId")
                        .HasColumnType("int");

                    b.Property<int>("DrinkTypesId")
                        .HasColumnType("int");

                    b.HasKey("DishesId", "DrinkTypesId");

                    b.HasIndex("DrinkTypesId");

                    b.ToTable("DishDrinkType");
                });

            modelBuilder.Entity("DrinkTypeGlass", b =>
                {
                    b.Property<int>("DrinkTypesId")
                        .HasColumnType("int");

                    b.Property<int>("GlassesId")
                        .HasColumnType("int");

                    b.HasKey("DrinkTypesId", "GlassesId");

                    b.HasIndex("GlassesId");

                    b.ToTable("DrinkTypeGlass");
                });

            modelBuilder.Entity("Wjakimszkle.DataAccess.Entities.Dish", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Dishes");
                });

            modelBuilder.Entity("Wjakimszkle.DataAccess.Entities.Drink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("AlcoholByVolume")
                        .HasColumnType("real");

                    b.Property<int?>("DrinkTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.HasIndex("DrinkTypeId");

                    b.ToTable("Drinks");
                });

            modelBuilder.Entity("Wjakimszkle.DataAccess.Entities.DrinkType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DrinkTypes");
                });

            modelBuilder.Entity("Wjakimszkle.DataAccess.Entities.Glass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Glasses");
                });

            modelBuilder.Entity("Wjakimszkle.DataAccess.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DishDrinkType", b =>
                {
                    b.HasOne("Wjakimszkle.DataAccess.Entities.Dish", null)
                        .WithMany()
                        .HasForeignKey("DishesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Wjakimszkle.DataAccess.Entities.DrinkType", null)
                        .WithMany()
                        .HasForeignKey("DrinkTypesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DrinkTypeGlass", b =>
                {
                    b.HasOne("Wjakimszkle.DataAccess.Entities.DrinkType", null)
                        .WithMany()
                        .HasForeignKey("DrinkTypesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Wjakimszkle.DataAccess.Entities.Glass", null)
                        .WithMany()
                        .HasForeignKey("GlassesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Wjakimszkle.DataAccess.Entities.Drink", b =>
                {
                    b.HasOne("Wjakimszkle.DataAccess.Entities.DrinkType", "DrinkType")
                        .WithMany("Drinks")
                        .HasForeignKey("DrinkTypeId");

                    b.Navigation("DrinkType");
                });

            modelBuilder.Entity("Wjakimszkle.DataAccess.Entities.DrinkType", b =>
                {
                    b.Navigation("Drinks");
                });
#pragma warning restore 612, 618
        }
    }
}
