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

        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Reservas_Turnos>()
            .HasOne(r => r.Usuario)
            .WithMany()
            .HasForeignKey(r => r.Dni)
            .OnDelete(DeleteBehavior.Restrict);


        // Otros mapeos y configuraciones...

        base.OnModelCreating(modelBuilder);


        modelBuilder.Entity<Usuario>(entity =>
        {
            //entity.HasKey(e => e.IdUsuario).HasName("DESKTOP-0DV3D4L\\MSSQLSERVER01");
            entity.HasKey(e => e.IdUsuario).HasName("localhost, 57000");

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
    public virtual DbSet<Mascotas> Mascotas { get; set; }
    public virtual DbSet<Reservas_Turnos> Reservas_Turnos { get; set; }
    public virtual DbSet<Turnos> Turnos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
    {
        //optionsBuilder.UseSqlServer("Data Source = DESKTOP-0DV3D4L\\MSSQLSERVER01; initial catalog = Veterinaria ;Integrated Security = true ;Encrypt=true; TrustServerCertificate=true");
        // optionsBuilder.UseSqlServer("Data Source = localhost; initial catalog = VETERINARIA; User ID = SA; Password = Melody1234; Encrypt = true; TrustServerCertificate = true;");
        optionsBuilder.UseSqlServer("Data Source = localhost, 57000; initial catalog = Veterinaria; User ID=SA;Password=Matiasd123;Encrypt=true; TrustServerCertificate=true;");
    }

}

    

    

