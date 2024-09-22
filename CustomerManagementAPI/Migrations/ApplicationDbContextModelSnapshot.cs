﻿// <auto-generated />
using System;
using CustomerManagementAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CustomerManagementAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CustomerManagementAPI.Models.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("IncidentName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("IncidentName");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0442326b-5e02-4d78-948f-b30e743a9d0e"),
                            Name = "Account1"
                        },
                        new
                        {
                            Id = new Guid("675895dc-8d7a-485a-9abd-37125a5fa7d2"),
                            Name = "Account2"
                        });
                });

            modelBuilder.Entity("CustomerManagementAPI.Models.Contact", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Contacts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d9e902be-00b7-49b0-9802-c5d214119254"),
                            AccountId = new Guid("0442326b-5e02-4d78-948f-b30e743a9d0e"),
                            Email = "john.doe@example.com",
                            FirstName = "John",
                            LastName = "Doe"
                        },
                        new
                        {
                            Id = new Guid("0fb62a27-a254-42f4-a7bf-415718782228"),
                            AccountId = new Guid("675895dc-8d7a-485a-9abd-37125a5fa7d2"),
                            Email = "jane.doe@example.com",
                            FirstName = "Jane",
                            LastName = "Doe"
                        });
                });

            modelBuilder.Entity("CustomerManagementAPI.Models.Incident", b =>
                {
                    b.Property<string>("IncidentName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("IncidentName");

                    b.ToTable("Incidents");
                });

            modelBuilder.Entity("CustomerManagementAPI.Models.Account", b =>
                {
                    b.HasOne("CustomerManagementAPI.Models.Incident", "Incident")
                        .WithMany("Accounts")
                        .HasForeignKey("IncidentName")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Incident");
                });

            modelBuilder.Entity("CustomerManagementAPI.Models.Contact", b =>
                {
                    b.HasOne("CustomerManagementAPI.Models.Account", "Account")
                        .WithMany("Contacts")
                        .HasForeignKey("AccountId");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("CustomerManagementAPI.Models.Account", b =>
                {
                    b.Navigation("Contacts");
                });

            modelBuilder.Entity("CustomerManagementAPI.Models.Incident", b =>
                {
                    b.Navigation("Accounts");
                });
#pragma warning restore 612, 618
        }
    }
}
