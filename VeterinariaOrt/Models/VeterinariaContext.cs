using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

namespace VeterinariaOrt.Models;

public partial class VeterinariaContext : DbContext
{
    public VeterinariaContext()
    {
    }

    public VeterinariaContext(DbContextOptions<VeterinariaContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Reservas_Turnos>()
        //.HasOne(r => r.Usuario)
        //.WithMany()
        //.HasForeignKey(r => r.Dni)
        //.OnDelete(DeleteBehavior.Restrict);

        //modelBuilder.Entity<Reservas_Turnos>()
        //    .HasOne(r => r.Id_Mascota)
        //    .WithMany()
        //    .HasForeignKey(r => r.IdMascota)
        //    .OnDelete(DeleteBehavior.Restrict);

        //// Otros mapeos y configuraciones...

        //base.OnModelCreating(modelBuilder);


        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__USUARIO__5B65BF97CCA9C4A1");

            entity.ToTable("Usuario");

            entity.Property(e => e.Clave)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Mail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
            .IsUnicode(false);


        });
    }
        public virtual DbSet<Usuario> Usuario { get; set; }
    public virtual DbSet<Veterinarios> Veterinarios { get; set; }
    public virtual DbSet<Mascotas> Mascotas { get; set; }
    public virtual DbSet<Reservas_Turnos> Reservas_Turnos { get; set; }
    public virtual DbSet<Turnos> Turnos { get; set; }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

}

    

    

