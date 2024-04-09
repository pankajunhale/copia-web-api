﻿// <auto-generated />
using CopiaWebApi.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CopiaWebApi.Migrations
{
    [DbContext(typeof(PaybrijDbContext))]
    [Migration("20240409033420_set null to outoutfile nav prop")]
    partial class setnulltooutoutfilenavprop
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.3");

            modelBuilder.Entity("CopiaWebApi.Entities.InputFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Index")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsHeader")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("InputFiles");
                });

            modelBuilder.Entity("CopiaWebApi.Entities.InputOutputMapper", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("InputFileId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OutputFileId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("InputOutputMappers");
                });

            modelBuilder.Entity("CopiaWebApi.Entities.OutputFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("TagName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("OutputFiles");
                });
#pragma warning restore 612, 618
        }
    }
}
