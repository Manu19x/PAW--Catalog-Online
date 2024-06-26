﻿// <auto-generated />
using Catalog.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Catalog.Migrations
{
    [DbContext(typeof(CatalogContext))]
    [Migration("20240529124135_v3")]
    partial class v3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Catalog.Models.Curs", b =>
                {
                    b.Property<int>("CursID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CursID"));

                    b.Property<string>("Descriere")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeCurs")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProfesorID")
                        .HasColumnType("int");

                    b.HasKey("CursID");

                    b.HasIndex("ProfesorID");

                    b.ToTable("Cursuri");
                });

            modelBuilder.Entity("Catalog.Models.InscriereCurs", b =>
                {
                    b.Property<int>("StudentID")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<int>("CursID")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<decimal>("Nota")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("StudentID", "CursID");

                    b.HasIndex("CursID");

                    b.ToTable("InscrieriCursuri");
                });

            modelBuilder.Entity("Catalog.Models.Moderator", b =>
                {
                    b.Property<int>("ModeratorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ModeratorID"));

                    b.Property<string>("Nume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ModeratorID");

                    b.HasIndex("UserID");

                    b.ToTable("Moderatori");
                });

            modelBuilder.Entity("Catalog.Models.Profesor", b =>
                {
                    b.Property<int>("ProfesorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProfesorID"));

                    b.Property<string>("Departament")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ProfesorID");

                    b.HasIndex("UserID");

                    b.ToTable("Profesori");
                });

            modelBuilder.Entity("Catalog.Models.Secretar", b =>
                {
                    b.Property<int>("SecretarID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SecretarID"));

                    b.Property<string>("Nume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("SecretarID");

                    b.HasIndex("UserID");

                    b.ToTable("Secretari");
                });

            modelBuilder.Entity("Catalog.Models.Student", b =>
                {
                    b.Property<int>("StudentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentID"));

                    b.Property<string>("Nume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("StudentID");

                    b.HasIndex("UserID");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Catalog.Models.UserAccount", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("UserAccounts");
                });

            modelBuilder.Entity("Catalog.Models.Curs", b =>
                {
                    b.HasOne("Catalog.Models.Profesor", "Profesor")
                        .WithMany("Cursuri")
                        .HasForeignKey("ProfesorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profesor");
                });

            modelBuilder.Entity("Catalog.Models.InscriereCurs", b =>
                {
                    b.HasOne("Catalog.Models.Curs", "Curs")
                        .WithMany("InscrieriCursuri")
                        .HasForeignKey("CursID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Catalog.Models.Student", "Student")
                        .WithMany("InscrieriCursuri")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Curs");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Catalog.Models.Moderator", b =>
                {
                    b.HasOne("Catalog.Models.UserAccount", "UserAccount")
                        .WithMany("Moderatori")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserAccount");
                });

            modelBuilder.Entity("Catalog.Models.Profesor", b =>
                {
                    b.HasOne("Catalog.Models.UserAccount", "UserAccount")
                        .WithMany("Profesori")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserAccount");
                });

            modelBuilder.Entity("Catalog.Models.Secretar", b =>
                {
                    b.HasOne("Catalog.Models.UserAccount", "UserAccount")
                        .WithMany("Secretari")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserAccount");
                });

            modelBuilder.Entity("Catalog.Models.Student", b =>
                {
                    b.HasOne("Catalog.Models.UserAccount", "UserAccount")
                        .WithMany("Students")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserAccount");
                });

            modelBuilder.Entity("Catalog.Models.Curs", b =>
                {
                    b.Navigation("InscrieriCursuri");
                });

            modelBuilder.Entity("Catalog.Models.Profesor", b =>
                {
                    b.Navigation("Cursuri");
                });

            modelBuilder.Entity("Catalog.Models.Student", b =>
                {
                    b.Navigation("InscrieriCursuri");
                });

            modelBuilder.Entity("Catalog.Models.UserAccount", b =>
                {
                    b.Navigation("Moderatori");

                    b.Navigation("Profesori");

                    b.Navigation("Secretari");

                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
