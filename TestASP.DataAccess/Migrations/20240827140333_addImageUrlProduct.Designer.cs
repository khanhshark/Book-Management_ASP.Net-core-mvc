﻿// <auto-generated />
using BookASP.DataAccess.data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookASP.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240827140333_addImageUrlProduct")]
    partial class addImageUrlProduct
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookASP.Model.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DisplayOrder = 1,
                            Name = "main"
                        },
                        new
                        {
                            Id = 2,
                            DisplayOrder = 2,
                            Name = "name"
                        });
                });

            modelBuilder.Entity("BookASP.Model.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ListPrice")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("Price100")
                        .HasColumnType("int");

                    b.Property<int>("Price50")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "F. Scott Fitzgerald",
                            CategoryId = 1,
                            Description = "A novel by F. Scott Fitzgerald.",
                            ISBN = "978-0743273565",
                            ImageUrl = "",
                            ListPrice = 20,
                            Price = 18,
                            Price100 = 10,
                            Price50 = 15,
                            Title = "The Great Gatsby"
                        },
                        new
                        {
                            Id = 2,
                            Author = "Harper Lee",
                            CategoryId = 1,
                            Description = "A novel by Harper Lee.",
                            ISBN = "978-0061120084",
                            ImageUrl = "",
                            ListPrice = 25,
                            Price = 22,
                            Price100 = 12,
                            Price50 = 18,
                            Title = "To Kill a Mockingbird"
                        },
                        new
                        {
                            Id = 3,
                            Author = "George Orwell",
                            CategoryId = 1,
                            Description = "A novel by George Orwell.",
                            ISBN = "978-0451524935",
                            ImageUrl = "",
                            ListPrice = 15,
                            Price = 13,
                            Price100 = 8,
                            Price50 = 11,
                            Title = "1984"
                        });
                });

            modelBuilder.Entity("BookASP.Model.Product", b =>
                {
                    b.HasOne("BookASP.Model.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
