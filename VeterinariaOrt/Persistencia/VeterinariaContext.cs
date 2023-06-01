using System.Collections.Generic;
using VeterinariaOrt.Models;
using Microsoft.EntityFrameworkCore;

public class VeterinariaContext : DbContext
{
    public DbSet<Clientes> Clientes { get; set; }
    public DbSet<Mascotas> Mascotas { get; set; }
    public DbSet<Reservas_Turnos> Reservas_Turnos { get; set; }
    public DbSet<Turnos> Turnos { get; set; }
    public DbSet<Veterinarios> Veterinarios { get; set; }



    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source = DESKTOP-PLMOM31; initial catalog = Veterinaria ;Integrated Security = true ;Encrypt=true; TrustServerCertificate=true");
    }
}