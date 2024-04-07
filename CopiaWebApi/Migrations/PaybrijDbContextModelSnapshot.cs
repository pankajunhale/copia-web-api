﻿// <auto-generated />
using CopiaWebApi.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CopiaWebApi.Migrations
{
    [DbContext(typeof(PaybrijDbContext))]
    partial class PaybrijDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.HasIndex("InputFileId")
                        .IsUnique();

                    b.HasIndex("OutputFileId")
                        .IsUnique();

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

            modelBuilder.Entity("CopiaWebApi.Entities.InputOutputMapper", b =>
                {
                    b.HasOne("CopiaWebApi.Entities.InputFile", null)
                        .WithOne("InputOutputMappers")
                        .HasForeignKey("CopiaWebApi.Entities.InputOutputMapper", "InputFileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CopiaWebApi.Entities.OutputFile", null)
                        .WithOne("InputOutputMappers")
                        .HasForeignKey("CopiaWebApi.Entities.InputOutputMapper", "OutputFileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CopiaWebApi.Entities.InputFile", b =>
                {
                    b.Navigation("InputOutputMappers")
                        .IsRequired();
                });

            modelBuilder.Entity("CopiaWebApi.Entities.OutputFile", b =>
                {
                    b.Navigation("InputOutputMappers")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
