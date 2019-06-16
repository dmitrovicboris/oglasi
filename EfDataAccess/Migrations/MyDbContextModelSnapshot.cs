﻿// <auto-generated />
using System;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EfDataAccess.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Automobil", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateModified");

                    b.Property<DateTime>("Godiste");

                    b.Property<int>("GorivoId");

                    b.Property<int>("KategorijaId");

                    b.Property<int>("KorisnikId");

                    b.Property<int>("MarkaId");

                    b.Property<int?>("ModelId");

                    b.Property<string>("Naziv")
                        .HasColumnType("text");

                    b.Property<string>("Opis")
                        .HasColumnType("text");

                    b.Property<decimal>("Price");

                    b.Property<int?>("TipId");

                    b.Property<bool>("Vlasnik")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.HasKey("Id");

                    b.HasIndex("GorivoId");

                    b.HasIndex("KategorijaId");

                    b.HasIndex("KorisnikId");

                    b.HasIndex("MarkaId");

                    b.HasIndex("ModelId");

                    b.HasIndex("TipId");

                    b.ToTable("Automobili");
                });

            modelBuilder.Entity("Domain.Gorivo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime?>("DateModified");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.HasIndex("Naziv")
                        .IsUnique();

                    b.ToTable("VrsteGoriva");
                });

            modelBuilder.Entity("Domain.Kategorija", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime?>("DateModified");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.HasIndex("Naziv")
                        .IsUnique();

                    b.ToTable("Kategorije");
                });

            modelBuilder.Entity("Domain.Korisnik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime?>("DateModified");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Password");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Korisnici");
                });

            modelBuilder.Entity("Domain.Marka", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime?>("DateModified");

                    b.Property<string>("MarkaAutomobila")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.HasIndex("MarkaAutomobila")
                        .IsUnique();

                    b.ToTable("Marke");
                });

            modelBuilder.Entity("Domain.ModelAutomobila", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime?>("DateModified");

                    b.Property<int>("MarkaId");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.HasIndex("MarkaId");

                    b.HasIndex("Model")
                        .IsUnique();

                    b.ToTable("Modeli");
                });

            modelBuilder.Entity("Domain.Prijave", b =>
                {
                    b.Property<int>("AutomobilId");

                    b.Property<int>("KorisnikId");

                    b.HasKey("AutomobilId", "KorisnikId");

                    b.HasIndex("KorisnikId");

                    b.ToTable("Prijave");
                });

            modelBuilder.Entity("Domain.Slike", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AutomobilId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateModified");

                    b.Property<string>("Putanja")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AutomobilId");

                    b.ToTable("Slike");
                });

            modelBuilder.Entity("Domain.Tip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime?>("DateModified");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.HasIndex("Type")
                        .IsUnique();

                    b.ToTable("Tipovi");
                });

            modelBuilder.Entity("Domain.Automobil", b =>
                {
                    b.HasOne("Domain.Gorivo", "Gorivo")
                        .WithMany("Automobils")
                        .HasForeignKey("GorivoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Kategorija", "Kategorija")
                        .WithMany("Automobils")
                        .HasForeignKey("KategorijaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Korisnik", "Korisnik")
                        .WithMany("Automobils")
                        .HasForeignKey("KorisnikId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Marka", "Marka")
                        .WithMany("Automobils")
                        .HasForeignKey("MarkaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.ModelAutomobila", "Model")
                        .WithMany("Automobils")
                        .HasForeignKey("ModelId");

                    b.HasOne("Domain.Tip", "Tip")
                        .WithMany("Automobils")
                        .HasForeignKey("TipId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.ModelAutomobila", b =>
                {
                    b.HasOne("Domain.Marka", "Marka")
                        .WithMany("Modeli")
                        .HasForeignKey("MarkaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Prijave", b =>
                {
                    b.HasOne("Domain.Automobil", "Automobil")
                        .WithMany("Prijave")
                        .HasForeignKey("AutomobilId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Korisnik", "Korisnik")
                        .WithMany("Prijave")
                        .HasForeignKey("KorisnikId");
                });

            modelBuilder.Entity("Domain.Slike", b =>
                {
                    b.HasOne("Domain.Automobil", "Automobil")
                        .WithMany("Slike")
                        .HasForeignKey("AutomobilId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}