﻿// <auto-generated />
using System;
using MedAdvisor.DataAccess.MySql.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MedAdvisor.DataAccess.MySql.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("AllergyUser", b =>
                {
                    b.Property<Guid>("AllergiesId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("UsersUserId")
                        .HasColumnType("char(36)");

                    b.HasKey("AllergiesId", "UsersUserId");

                    b.HasIndex("UsersUserId");

                    b.ToTable("AllergyUser", (string)null);
                });

            modelBuilder.Entity("DiagnosesUser", b =>
                {
                    b.Property<Guid>("DiagnosesId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("UsersUserId")
                        .HasColumnType("char(36)");

                    b.HasKey("DiagnosesId", "UsersUserId");

                    b.HasIndex("UsersUserId");

                    b.ToTable("DiagnosesUser", (string)null);
                });

            modelBuilder.Entity("MedAdvisor.Models.Allergy", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Code")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Allergies");
                });

            modelBuilder.Entity("MedAdvisor.Models.Diagnoses", b =>
                {
                    b.Property<Guid>("DiagnosesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Code")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("DiagnosesId");

                    b.ToTable("Diagnosess");
                });

            modelBuilder.Entity("MedAdvisor.Models.Document", b =>
                {
                    b.Property<Guid>("DocumentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Catagory")
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.Property<string>("filePath")
                        .HasColumnType("longtext");

                    b.HasKey("DocumentId");

                    b.HasIndex("UserId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("MedAdvisor.Models.Medicine", b =>
                {
                    b.Property<Guid>("MedicineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Code")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("MedicineId");

                    b.ToTable("Medicines");
                });

            modelBuilder.Entity("MedAdvisor.Models.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("longblob");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("longblob");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MedAdvisor.Models.UserProfile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("CPRNumber")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("longtext");

                    b.Property<string>("Country")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("EmergencyContactName")
                        .HasColumnType("longtext");

                    b.Property<string>("EmergencyContactPhoneNo")
                        .HasColumnType("longtext");

                    b.Property<string>("EmergencyPhone")
                        .HasColumnType("longtext");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("InsuranceCompany")
                        .HasColumnType("longtext");

                    b.Property<string>("InsuranceType")
                        .HasColumnType("longtext");

                    b.Property<string>("Nationality")
                        .HasColumnType("longtext");

                    b.Property<bool>("OrganDonor")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("PolicyNumber")
                        .HasColumnType("longtext");

                    b.Property<string>("Relationship")
                        .HasColumnType("longtext");

                    b.Property<string>("StreetAddress")
                        .HasColumnType("longtext");

                    b.Property<string>("TelephoneNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Zip")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserProfiles");
                });

            modelBuilder.Entity("MedAdvisor.Models.Vaccine", b =>
                {
                    b.Property<Guid>("VaccineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Code")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("VaccineId");

                    b.ToTable("Vaccines");
                });

            modelBuilder.Entity("MedicineUser", b =>
                {
                    b.Property<Guid>("MedicinesMedicineId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("UsersUserId")
                        .HasColumnType("char(36)");

                    b.HasKey("MedicinesMedicineId", "UsersUserId");

                    b.HasIndex("UsersUserId");

                    b.ToTable("MedicineUser", (string)null);
                });

            modelBuilder.Entity("UserVaccine", b =>
                {
                    b.Property<Guid>("UsersUserId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("VaccinesVaccineId")
                        .HasColumnType("char(36)");

                    b.HasKey("UsersUserId", "VaccinesVaccineId");

                    b.HasIndex("VaccinesVaccineId");

                    b.ToTable("VaccineUser", (string)null);
                });

            modelBuilder.Entity("AllergyUser", b =>
                {
                    b.HasOne("MedAdvisor.Models.Allergy", null)
                        .WithMany()
                        .HasForeignKey("AllergiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedAdvisor.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DiagnosesUser", b =>
                {
                    b.HasOne("MedAdvisor.Models.Diagnoses", null)
                        .WithMany()
                        .HasForeignKey("DiagnosesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedAdvisor.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MedAdvisor.Models.Document", b =>
                {
                    b.HasOne("MedAdvisor.Models.User", "User")
                        .WithMany("Documents")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MedAdvisor.Models.UserProfile", b =>
                {
                    b.HasOne("MedAdvisor.Models.User", "User")
                        .WithOne("Profile")
                        .HasForeignKey("MedAdvisor.Models.UserProfile", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MedicineUser", b =>
                {
                    b.HasOne("MedAdvisor.Models.Medicine", null)
                        .WithMany()
                        .HasForeignKey("MedicinesMedicineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedAdvisor.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UserVaccine", b =>
                {
                    b.HasOne("MedAdvisor.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedAdvisor.Models.Vaccine", null)
                        .WithMany()
                        .HasForeignKey("VaccinesVaccineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MedAdvisor.Models.User", b =>
                {
                    b.Navigation("Documents");

                    b.Navigation("Profile");
                });
#pragma warning restore 612, 618
        }
    }
}
