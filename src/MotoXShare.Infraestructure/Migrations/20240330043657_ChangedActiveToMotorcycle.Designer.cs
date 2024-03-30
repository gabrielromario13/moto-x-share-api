﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MotoXShare.Infraestructure.Context;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MotoXShare.Infraestructure.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20240330043657_ChangedActiveToMotorcycle")]
    partial class ChangedActiveToMotorcycle
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MotoXShare.Domain.Model.DeliveryRider", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CNH")
                        .HasColumnType("text");

                    b.Property<string>("CNHImage")
                        .HasColumnType("text");

                    b.Property<int>("CNHType")
                        .HasColumnType("integer");

                    b.Property<string>("CNPJ")
                        .HasColumnType("text");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("DeliveryRider");
                });

            modelBuilder.Entity("MotoXShare.Domain.Model.Motorcycle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<string>("Model")
                        .HasColumnType("text");

                    b.Property<string>("Plate")
                        .HasColumnType("text");

                    b.Property<short>("Year")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.ToTable("Motorcycle");
                });

            modelBuilder.Entity("MotoXShare.Domain.Model.Rental", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("DeliveryRiderId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("EndDatePrevision")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("MotorcycleId")
                        .HasColumnType("uuid");

                    b.Property<int>("Plan")
                        .HasColumnType("integer");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("DeliveryRiderId");

                    b.HasIndex("MotorcycleId");

                    b.ToTable("Rental");
                });

            modelBuilder.Entity("MotoXShare.Domain.Model.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("MotoXShare.Domain.Model.Rental", b =>
                {
                    b.HasOne("MotoXShare.Domain.Model.DeliveryRider", "DeliveryRider")
                        .WithMany()
                        .HasForeignKey("DeliveryRiderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MotoXShare.Domain.Model.Motorcycle", "Motorcycle")
                        .WithMany()
                        .HasForeignKey("MotorcycleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DeliveryRider");

                    b.Navigation("Motorcycle");
                });
#pragma warning restore 612, 618
        }
    }
}