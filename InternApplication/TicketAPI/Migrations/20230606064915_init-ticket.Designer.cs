﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TicketAPI.Models;

#nullable disable

namespace TicketAPI.Migrations
{
    [DbContext(typeof(TicketContext))]
    [Migration("20230606064915_init-ticket")]
    partial class initticket
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TicketAPI.Models.Ticket", b =>
                {
                    b.Property<int>("ticketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ticketId"), 1L, 1);

                    b.Property<string>("ticketDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ticketNumber")
                        .HasColumnType("int");

                    b.Property<string>("ticketTitle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ticketId");

                    b.ToTable("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
