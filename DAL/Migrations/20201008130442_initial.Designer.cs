﻿// <auto-generated />
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(GestorContext))]
    [Migration("20201008130442_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Models.Programador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasComment("Apellido del progrador")
                        .HasMaxLength(20);

                    b.Property<string>("DNI_NIE")
                        .IsRequired()
                        .HasColumnType("nvarchar(9)")
                        .HasMaxLength(9);

                    b.Property<int>("Edad")
                        .HasColumnType("int")
                        .HasMaxLength(120);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<int>("TipoProgramadorId")
                        .HasColumnType("int")
                        .HasComment("ID(PK) a tipo de programador");

                    b.HasKey("Id");

                    b.HasIndex("TipoProgramadorId");

                    b.ToTable("Programadores","Core");

                    b.HasComment("Tabla de programadores");
                });

            modelBuilder.Entity("Models.TipoProgramadores", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("TipoProgramadores","Masters");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nombre = "Back-End"
                        },
                        new
                        {
                            Id = 2,
                            Nombre = "Front-End"
                        },
                        new
                        {
                            Id = 3,
                            Nombre = "Full-Stack"
                        });
                });

            modelBuilder.Entity("Models.Programador", b =>
                {
                    b.HasOne("Models.TipoProgramadores", "TipoProgramador")
                        .WithMany()
                        .HasForeignKey("TipoProgramadorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
