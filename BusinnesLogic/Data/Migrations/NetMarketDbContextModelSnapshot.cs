﻿// <auto-generated />
using BusinnesLogic.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BusinnesLogic.Data.Migrations
{
    [DbContext(typeof(NetMarketDbContext))]
    partial class NetMarketDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CoreData.Entities.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NombreCategoria")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("CoreData.Entities.Marca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MarcaProducto")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Marca");
                });

            modelBuilder.Entity("CoreData.Entities.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Categoria")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("IdCategoria")
                        .HasColumnType("int");

                    b.Property<int>("IdMarca")
                        .HasColumnType("int");

                    b.Property<string>("Imagen")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Marca")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreProducto")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdCategoria");

                    b.HasIndex("IdMarca");

                    b.ToTable("Producto");
                });

            modelBuilder.Entity("CoreData.Entities.Producto", b =>
                {
                    b.HasOne("CoreData.Entities.Categoria", "CategoriaLink")
                        .WithMany()
                        .HasForeignKey("IdCategoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoreData.Entities.Marca", "MarcaLink")
                        .WithMany()
                        .HasForeignKey("IdMarca")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CategoriaLink");

                    b.Navigation("MarcaLink");
                });
#pragma warning restore 612, 618
        }
    }
}
