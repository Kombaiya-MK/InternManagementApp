﻿// <auto-generated />
using InternLogAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InternLogAPI.Migrations
{
    [DbContext(typeof(logContext))]
    partial class logContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("InternLogAPI.Models.Log", b =>
                {
                    b.Property<int>("logId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("logId"), 1L, 1);

                    b.Property<int>("internID")
                        .HasColumnType("int");

                    b.Property<string>("loggInTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("loggOutTime")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("logId");

                    b.ToTable("logs");
                });
#pragma warning restore 612, 618
        }
    }
}