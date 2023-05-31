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
        optionsBuilder.UseSqlServer("Data Source = SQL2016DEV\\DESARROLLO; initial catalog = Audit; User ID=USR_DESA;Password=USR_DESA;Encrypt=true; TrustServerCertificate=true");
    }
}