﻿// <auto-generated />
using System;
using BackEnd.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BackEnd.Migrations
{
    [DbContext(typeof(Ensenanza_VoluntariaContext))]
    [Migration("20210425182950_identityMigration")]
    partial class identityMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BackEnd.Entities.CalificacionTutorium", b =>
                {
                    b.Property<int>("IdCalificacionTutoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_CALIFICACION_TUTORIA")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("Calificacion")
                        .HasColumnType("numeric(5,0)")
                        .HasColumnName("CALIFICACION");

                    b.Property<int?>("IdTutoriaCursos")
                        .HasColumnType("int")
                        .HasColumnName("ID_TUTORIA_CURSOS");

                    b.HasKey("IdCalificacionTutoria")
                        .HasName("PK__CALIFICA__B4B4AD862AA6096E");

                    b.HasIndex("IdTutoriaCursos");

                    b.ToTable("CALIFICACION_TUTORIA");
                });

            modelBuilder.Entity("BackEnd.Entities.Curso", b =>
                {
                    b.Property<int>("IdCurso")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_CURSO")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("NOMBRE");

                    b.HasKey("IdCurso")
                        .HasName("PK__CURSOS__9B4AE798C8CA9992");

                    b.ToTable("CURSOS");
                });

            modelBuilder.Entity("BackEnd.Entities.Institucion", b =>
                {
                    b.Property<int>("IdInstitucion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_INSTITUCION")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("NOMBRE");

                    b.HasKey("IdInstitucion")
                        .HasName("PK__INSTITUC__569ED1531AB758CB");

                    b.ToTable("INSTITUCION");
                });

            modelBuilder.Entity("BackEnd.Entities.MaterialTutorium", b =>
                {
                    b.Property<int>("IdMaterialTutoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_MATERIAL_TUTORIA")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DireccionArchivo")
                        .IsRequired()
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)")
                        .HasColumnName("DIRECCION_ARCHIVO");

                    b.Property<int?>("IdTutoriaCursos")
                        .HasColumnType("int")
                        .HasColumnName("ID_TUTORIA_CURSOS");

                    b.HasKey("IdMaterialTutoria")
                        .HasName("PK__MATERIAL__4C474AED2081ED1D");

                    b.HasIndex("IdTutoriaCursos");

                    b.ToTable("MATERIAL_TUTORIA");
                });

            modelBuilder.Entity("BackEnd.Entities.TutoriaCurso", b =>
                {
                    b.Property<int>("IdTutoriaCursos")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_TUTORIA_CURSOS")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("DESCRIPCION");

                    b.Property<string>("FechaHora")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("FECHA_HORA");

                    b.Property<int?>("IdCurso")
                        .HasColumnType("int")
                        .HasColumnName("ID_CURSO");

                    b.Property<int?>("IdInstitucion")
                        .HasColumnType("int")
                        .HasColumnName("ID_INSTITUCION");

                    b.HasKey("IdTutoriaCursos")
                        .HasName("PK__TUTORIA___106444E1CA548DB8");

                    b.HasIndex("IdCurso");

                    b.HasIndex("IdInstitucion");

                    b.ToTable("TUTORIA_CURSOS");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("BackEnd.Entities.CalificacionTutorium", b =>
                {
                    b.HasOne("BackEnd.Entities.TutoriaCurso", "IdTutoriaCursosNavigation")
                        .WithMany("CalificacionTutoria")
                        .HasForeignKey("IdTutoriaCursos")
                        .HasConstraintName("R_54");

                    b.Navigation("IdTutoriaCursosNavigation");
                });

            modelBuilder.Entity("BackEnd.Entities.MaterialTutorium", b =>
                {
                    b.HasOne("BackEnd.Entities.TutoriaCurso", "IdTutoriaCursosNavigation")
                        .WithMany("MaterialTutoria")
                        .HasForeignKey("IdTutoriaCursos")
                        .HasConstraintName("R_50");

                    b.Navigation("IdTutoriaCursosNavigation");
                });

            modelBuilder.Entity("BackEnd.Entities.TutoriaCurso", b =>
                {
                    b.HasOne("BackEnd.Entities.Curso", "IdCursoNavigation")
                        .WithMany("TutoriaCursos")
                        .HasForeignKey("IdCurso")
                        .HasConstraintName("R_49");

                    b.HasOne("BackEnd.Entities.Institucion", "IdInstitucionNavigation")
                        .WithMany("TutoriaCursos")
                        .HasForeignKey("IdInstitucion")
                        .HasConstraintName("R_46");

                    b.Navigation("IdCursoNavigation");

                    b.Navigation("IdInstitucionNavigation");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BackEnd.Entities.Curso", b =>
                {
                    b.Navigation("TutoriaCursos");
                });

            modelBuilder.Entity("BackEnd.Entities.Institucion", b =>
                {
                    b.Navigation("TutoriaCursos");
                });

            modelBuilder.Entity("BackEnd.Entities.TutoriaCurso", b =>
                {
                    b.Navigation("CalificacionTutoria");

                    b.Navigation("MaterialTutoria");
                });
#pragma warning restore 612, 618
        }
    }
}
