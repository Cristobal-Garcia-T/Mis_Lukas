using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MisLukas.Models;

public class Cuenta
{
    // Keys
    [Key]
    public int IdCuenta { get; set; }
    public int IdUsuario { get; set; }
    
    // Atributos
    public string NombreCuenta { get; set; } = null!;
    public string Tipo { get; set; } = null!;
    public double Saldo { get; set; }

    // Relaciones
    public Usuario Usuario { get; set; } = null!;
    public List<Gasto> Gastos { get; set; } = new();
    public List<Ingreso> Ingresos { get; set; } = new();
}