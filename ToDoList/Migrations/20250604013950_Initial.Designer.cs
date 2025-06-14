﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ToDoList.Data;

#nullable disable

namespace ToDoList.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250604013950_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ToDoList.Models.ToDoItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ToDoItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2025, 6, 4, 9, 39, 50, 160, DateTimeKind.Local).AddTicks(9716),
                            Description = "Adjust the final designs of the UI",
                            DueDate = new DateTime(2025, 6, 11, 1, 39, 50, 160, DateTimeKind.Utc).AddTicks(9729),
                            IsCompleted = false,
                            Priority = 2,
                            Title = "Complete the project"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2025, 6, 4, 9, 39, 50, 160, DateTimeKind.Local).AddTicks(9736),
                            Description = "Cooking oil, chicken, milk",
                            DueDate = new DateTime(2025, 6, 7, 1, 39, 50, 160, DateTimeKind.Utc).AddTicks(9737),
                            IsCompleted = false,
                            Priority = 1,
                            Title = "Refill food supplies"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
