using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BackEnd.Entities
{
    public partial class Ensenanza_VoluntariaContext : IdentityDbContext
    {
        public Ensenanza_VoluntariaContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<Ensenanza_VoluntariaContext>();
            optionsBuilder.UseSqlServer(Utilities.Util.ConnectionString);
        }

        public Ensenanza_VoluntariaContext(DbContextOptions<Ensenanza_VoluntariaContext> options)
            : base(options)
        {
        }
        public virtual DbSet<CalificacionTutorium> CalificacionTutoria { get; set; }
        public virtual DbSet<Curso> Cursos { get; set; }
        public virtual DbSet<Institucion> Institucions { get; set; }
        public virtual DbSet<MaterialTutorium> MaterialTutoria { get; set; }
        public virtual DbSet<TutoriaCurso> TutoriaCursos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Utilities.Util.ConnectionString);
            optionsBuilder.EnableSensitiveDataLogging(true);
            base.OnConfiguring(optionsBuilder);

            /*if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-34I9BUG\\SQLEXPRESS;Database=Ensenanza_Voluntaria;Trusted_Connection=True;");
            }*/
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<CalificacionTutorium>(entity =>
            {
                entity.HasKey(e => e.IdCalificacionTutoria)
                    .HasName("PK__CALIFICA__B4B4AD862AA6096E");

                entity.ToTable("CALIFICACION_TUTORIA");

                entity.Property(e => e.IdCalificacionTutoria).HasColumnName("ID_CALIFICACION_TUTORIA");

                entity.Property(e => e.Calificacion)
                    .HasColumnType("numeric(5, 0)")
                    .HasColumnName("CALIFICACION");

                entity.Property(e => e.IdTutoriaCursos).HasColumnName("ID_TUTORIA_CURSOS");

                entity.HasOne(d => d.IdTutoriaCursosNavigation)
                    .WithMany(p => p.CalificacionTutoria)
                    .HasForeignKey(d => d.IdTutoriaCursos)
                    .HasConstraintName("R_54");
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.HasKey(e => e.IdCurso)
                    .HasName("PK__CURSOS__9B4AE798C8CA9992");

                entity.ToTable("CURSOS");

                entity.Property(e => e.IdCurso).HasColumnName("ID_CURSO");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");
            });

            modelBuilder.Entity<Institucion>(entity =>
            {
                entity.HasKey(e => e.IdInstitucion)
                    .HasName("PK__INSTITUC__569ED1531AB758CB");

                entity.ToTable("INSTITUCION");

                entity.Property(e => e.IdInstitucion).HasColumnName("ID_INSTITUCION");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");
            });

            modelBuilder.Entity<MaterialTutorium>(entity =>
            {
                entity.HasKey(e => e.IdMaterialTutoria)
                    .HasName("PK__MATERIAL__4C474AED2081ED1D");

                entity.ToTable("MATERIAL_TUTORIA");

                entity.Property(e => e.IdMaterialTutoria).HasColumnName("ID_MATERIAL_TUTORIA");

                entity.Property(e => e.DireccionArchivo)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("DIRECCION_ARCHIVO");

                entity.Property(e => e.IdTutoriaCursos).HasColumnName("ID_TUTORIA_CURSOS");

                entity.HasOne(d => d.IdTutoriaCursosNavigation)
                    .WithMany(p => p.MaterialTutoria)
                    .HasForeignKey(d => d.IdTutoriaCursos)
                    .HasConstraintName("R_50");
            });

            modelBuilder.Entity<TutoriaCurso>(entity =>
            {
                entity.HasKey(e => e.IdTutoriaCursos)
                    .HasName("PK__TUTORIA___106444E1CA548DB8");

                entity.ToTable("TUTORIA_CURSOS");

                entity.Property(e => e.IdTutoriaCursos).HasColumnName("ID_TUTORIA_CURSOS");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION");

                entity.Property(e => e.FechaHora)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("FECHA_HORA");

                entity.Property(e => e.IdCurso).HasColumnName("ID_CURSO");

                entity.Property(e => e.IdInstitucion).HasColumnName("ID_INSTITUCION");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.TutoriaCursos)
                    .HasForeignKey(d => d.IdCurso)
                    .HasConstraintName("R_49");

                entity.HasOne(d => d.IdInstitucionNavigation)
                    .WithMany(p => p.TutoriaCursos)
                    .HasForeignKey(d => d.IdInstitucion)
                    .HasConstraintName("R_46");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
