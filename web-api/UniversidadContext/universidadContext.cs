using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using universidad.Models;

namespace universidad.UniversidadContext
{
    public partial class universidadContext : DbContext
    {
        public universidadContext()
        {
        }

        public universidadContext(DbContextOptions<universidadContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clase> Clases { get; set; } = null!;
        public virtual DbSet<Estudiante> Estudiantes { get; set; } = null!;
        public virtual DbSet<Materia> Materias { get; set; } = null!;
        public virtual DbSet<MateriasProfesore> MateriasProfesores { get; set; } = null!;
        public virtual DbSet<Profesore> Profesores { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Clase>(entity =>
            {
                entity.HasKey(e => e.IdClase)
                    .HasName("PRIMARY");

                entity.ToTable("clases");

                entity.Property(e => e.IdClase).HasColumnName("id_clase");

                entity.Property(e => e.IdEstudiante).HasColumnName("id_estudiante");

                entity.Property(e => e.IdMateriasProfesores).HasColumnName("id_materias_profesores");
            });

            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.ToTable("estudiantes");

                entity.HasIndex(e => e.Email, "email")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email).HasColumnName("email");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .HasColumnName("nombre");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .HasColumnName("password");
            });

            modelBuilder.Entity<Materia>(entity =>
            {
                entity.ToTable("materias");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Creditos).HasColumnName("creditos");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<MateriasProfesore>(entity =>
            {
                entity.ToTable("materias_profesores");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdMateria).HasColumnName("id_materia");

                entity.Property(e => e.IdProfesor).HasColumnName("id_profesor");
            });

            modelBuilder.Entity<Profesore>(entity =>
            {
                entity.ToTable("profesores");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .HasColumnName("nombre");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
