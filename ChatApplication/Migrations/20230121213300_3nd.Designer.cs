﻿// <auto-generated />
using System;
using ChatApplication.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ChatApplication.Migrations
{
    [DbContext(typeof(MvcDbContext))]
    [Migration("20230121213300_3nd")]
    partial class _3nd
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ChatApplication.Models.EmployeeModel", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ChatApplication.Models.MessageModel", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MessageId"));

                    b.Property<int>("EmployeeModelEmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("MesBody")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MesTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RecieverEmployeeId")
                        .HasColumnType("int");

                    b.HasKey("MessageId");

                    b.HasIndex("EmployeeModelEmployeeId");

                    b.HasIndex("RecieverEmployeeId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("ChatApplication.Models.MessageModel", b =>
                {
                    b.HasOne("ChatApplication.Models.EmployeeModel", "EmployeeModel")
                        .WithMany("Messages")
                        .HasForeignKey("EmployeeModelEmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ChatApplication.Models.EmployeeModel", "Reciever")
                        .WithMany()
                        .HasForeignKey("RecieverEmployeeId");

                    b.Navigation("EmployeeModel");

                    b.Navigation("Reciever");
                });

            modelBuilder.Entity("ChatApplication.Models.EmployeeModel", b =>
                {
                    b.Navigation("Messages");
                });
#pragma warning restore 612, 618
        }
    }
}
