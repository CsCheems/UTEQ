﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UTEQ.Datos;

#nullable disable

namespace UTEQ.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220829231051_actualCurso")]
    partial class actualCurso
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("UTEQ.Models.Cursos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ImagenUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ModalidadId")
                        .HasColumnType("int");

                    b.Property<float>("costo")
                        .HasColumnType("real");

                    b.Property<float>("costopref")
                        .HasColumnType("real");

                    b.Property<string>("criterioeval")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fecha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("horario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lugar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombrecurso")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("requisitos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("totalhoras")
                        .HasColumnType("real");

                    b.Property<string>("urltemario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ModalidadId");

                    b.ToTable("Cursos");
                });

            modelBuilder.Entity("UTEQ.Models.Modalidad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("nombreModalidad")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Modalidad");
                });

            modelBuilder.Entity("UTEQ.Models.Cursos", b =>
                {
                    b.HasOne("UTEQ.Models.Modalidad", "Modalidad")
                        .WithMany()
                        .HasForeignKey("ModalidadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Modalidad");
                });
#pragma warning restore 612, 618
        }
    }
}
