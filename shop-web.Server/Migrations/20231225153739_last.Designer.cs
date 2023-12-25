﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using shop_web.Server.Entities;

#nullable disable

namespace shop_web.Server.Migrations
{
    [DbContext(typeof(ProductDbContext))]
    [Migration("20231225153739_last")]
    partial class last
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("shop_web.Server.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Count = 5,
                            Description = "Смартфон от компании Apple, 128 GB памяти. Цвет черный.",
                            Name = "iPhone 14",
                            Price = 999m
                        },
                        new
                        {
                            Id = 2,
                            Count = 5,
                            Description = "Смартфон от компании Apple, 512 GB памяти. Цвет серый.",
                            Name = "iPhone 14 Pro",
                            Price = 1099m
                        },
                        new
                        {
                            Id = 3,
                            Count = 5,
                            Description = "Ноубук от компании Apple, 1 TB памяти. Цвет серебристый.",
                            Name = "MacBook Pro 2022",
                            Price = 1399m
                        },
                        new
                        {
                            Id = 4,
                            Count = 5,
                            Description = "Компьютер от компании Apple, 512 GB памяти. Цвет серебристый.",
                            Name = "Mac Mini",
                            Price = 699m
                        });
                });

            modelBuilder.Entity("shop_web.Server.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "abc@abc",
                            Name = "Alex",
                            Password = "admin123"
                        });
                });

            modelBuilder.Entity("shop_web.Server.Entities.UserProducts", b =>
                {
                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.Property<int>("ProductsId")
                        .HasColumnType("int");

                    b.HasKey("UsersId", "ProductsId");

                    b.HasIndex("ProductsId");

                    b.ToTable("UserProducts");
                });

            modelBuilder.Entity("shop_web.Server.Entities.UserProducts", b =>
                {
                    b.HasOne("shop_web.Server.Entities.Product", "Product")
                        .WithMany("UserProducts")
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("shop_web.Server.Entities.User", "User")
                        .WithMany("UserProducts")
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("shop_web.Server.Entities.Product", b =>
                {
                    b.Navigation("UserProducts");
                });

            modelBuilder.Entity("shop_web.Server.Entities.User", b =>
                {
                    b.Navigation("UserProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
