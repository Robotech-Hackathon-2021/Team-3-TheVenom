﻿// <auto-generated />
using Hackathon.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Hackathon.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20211112152450_orderTableUpdated")]
    partial class orderTableUpdated
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Hackathon.Model.Anonymous", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Anonymouss");
                });

            modelBuilder.Entity("Hackathon.Model.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Items")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Total")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Hackathon.Model.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StudAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudDOB")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudFatherName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudGender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudPhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudRollNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudYearAndBranch")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Hackathon.Model.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TeacherAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeacherDOB")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeacherDegree")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeacherEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeacherGender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeacherID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeacherName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeacherPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeacherPhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });
#pragma warning restore 612, 618
        }
    }
}
