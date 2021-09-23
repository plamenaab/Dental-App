﻿// <auto-generated />
using System;
using DentalApp.Data.Access.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DentalApp.Data.Access.Migrations
{
    [DbContext(typeof(MainDbContext))]
    partial class MainDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DentalApp.Data.Model.Appointment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AppointmentStatus");

                    b.Property<DateTime>("AppointmentTakenDate");

                    b.Property<DateTime>("DateTime");

                    b.Property<int>("DoctorID");

                    b.Property<int>("PatientID");

                    b.Property<double>("ProcedureCost");

                    b.Property<string>("ProcedureDescription");

                    b.Property<string>("ProcedureName");

                    b.HasKey("ID")
                        .HasName("PK_Appointments_ID");

                    b.HasIndex("DoctorID");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("DentalApp.Data.Model.Doctor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(40);

                    b.Property<string>("Email");

                    b.Property<DateTime>("EndTime");

                    b.Property<double>("FirstConsultationFee");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<double>("FollowupConsultationFee");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<string>("Password");

                    b.Property<string>("Phone");

                    b.Property<string>("ProfessionalStatement");

                    b.Property<int>("RoleID");

                    b.Property<string>("SpecialtyName")
                        .HasMaxLength(40);

                    b.Property<DateTime>("StartTime");

                    b.Property<string>("UserName");

                    b.HasKey("ID")
                        .HasName("PK_Doctors_ID");

                    b.HasIndex("RoleID");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("DentalApp.Data.Model.Patient", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("Email")
                        .HasMaxLength(70);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<int>("Gender")
                        .HasMaxLength(1);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Password");

                    b.Property<string>("Phone");

                    b.Property<int>("RoleID");

                    b.Property<string>("UserName");

                    b.HasKey("ID")
                        .HasName("PK_Patients_ID");

                    b.HasIndex("RoleID");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("DentalApp.Data.Model.Role", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("DentalApp.Data.Model.Appointment", b =>
                {
                    b.HasOne("DentalApp.Data.Model.Doctor", "Doctor")
                        .WithMany("Appointments")
                        .HasForeignKey("DoctorID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DentalApp.Data.Model.Patient", "Patient")
                        .WithMany("Appointments")
                        .HasForeignKey("DoctorID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("DentalApp.Data.Model.Doctor", b =>
                {
                    b.HasOne("DentalApp.Data.Model.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("DentalApp.Data.Model.Patient", b =>
                {
                    b.HasOne("DentalApp.Data.Model.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
