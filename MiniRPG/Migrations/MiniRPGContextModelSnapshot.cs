﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MiniRPG.Bancos;

#nullable disable

namespace MiniRPG.Migrations
{
    [DbContext(typeof(MiniRPGContext))]
    partial class MiniRPGContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MiniRPG.ModelosPrincipais.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Classe")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ContadorDeBatalhas")
                        .HasColumnType("int");

                    b.Property<int>("Def")
                        .HasColumnType("int");

                    b.Property<int>("Dmg")
                        .HasColumnType("int");

                    b.Property<int>("Gold")
                        .HasColumnType("int");

                    b.Property<int>("Health")
                        .HasColumnType("int");

                    b.Property<string>("Itens")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Lvl")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Xp")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
