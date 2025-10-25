using Microsoft.EntityFrameworkCore;

namespace MisLukas.Models;

public class SqLiteContext : DbContext
{
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Cuenta> Cuentas { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Gasto> Gastos { get; set; }
    public DbSet<Ingreso> Ingresos { get; set; }
    public DbSet<Presupuesto> Presupuestos { get; set; }
    public DbSet<Deuda> Deudas { get; set; }
    public DbSet<ArchivoAdjunto> Archivos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=MisLukas.db");
    }
}