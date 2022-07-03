﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RT.Contacts.DataAccess.Concrete;

#nullable disable

namespace RT.Contacts.DataAccess.Migrations
{
    [DbContext(typeof(PostgreSqlEfDbContext))]
    [Migration("20220702130502_Reports")]
    partial class Reports
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("RT.Contacts.Domain.Entities.Contact", b =>
                {
                    b.Property<int>("UUID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UUID"));

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Firma")
                        .HasColumnType("text");

                    b.Property<string>("Soyad")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UUID");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("RT.Contacts.Domain.Entities.ContactDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("BilgiIcerigi")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("BilgiTipi")
                        .HasColumnType("integer");

                    b.Property<int>("ContactUUID")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ContactUUID");

                    b.ToTable("ContactDetails");
                });

            modelBuilder.Entity("RT.Contacts.Domain.Entities.Report", b =>
                {
                    b.Property<int>("UUID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UUID"));

                    b.Property<int?>("KayitliKisiSayisi")
                        .HasColumnType("integer");

                    b.Property<int?>("KayitliTelefonNumarasiSayisi")
                        .HasColumnType("integer");

                    b.Property<string>("Konum")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("RaporDurumu")
                        .HasColumnType("integer");

                    b.Property<DateTime>("RaporTarihi")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("UUID");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("RT.Contacts.Domain.Entities.ContactDetail", b =>
                {
                    b.HasOne("RT.Contacts.Domain.Entities.Contact", null)
                        .WithMany("IletisimBilgileri")
                        .HasForeignKey("ContactUUID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RT.Contacts.Domain.Entities.Contact", b =>
                {
                    b.Navigation("IletisimBilgileri");
                });
#pragma warning restore 612, 618
        }
    }
}
